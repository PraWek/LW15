using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileSystemWatcher
{
    /// <summary>
    /// наблюдатель директории на основе периодического опроса
    /// </summary>
    public sealed class PollingDirectoryWatcher : IDisposable
    {
        private readonly string _path;
        private readonly TimeSpan _interval;
        private readonly List<IDirectoryObserver> _observers;
        private Timer _timer;
        private DirectorySnapshot _snapshot;

        /// <summary>
        /// создает наблюдатель директории
        /// </summary>
        /// <param name="path">путь к директории</param>
        /// <param name="interval">интервал опроса</param>
        /// <exception cref="DirectoryNotFoundException">директория не существует</exception>
        public PollingDirectoryWatcher(string path, TimeSpan interval)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException(path);

            _path = path;
            _interval = interval;
            _observers = new List<IDirectoryObserver>();
            _snapshot = new DirectorySnapshot(path);
        }

        /// <summary>
        /// добавляет наблюдателя
        /// </summary>
        /// <param name="observer">наблюдатель</param>
        /// <exception cref="ArgumentNullException">observer равен null</exception>
        public void Subscribe(IDirectoryObserver observer)
        {
            if (observer == null)
                throw new ArgumentNullException(nameof(observer));

            _observers.Add(observer);
        }

        /// <summary>
        /// удаляет наблюдателя
        /// </summary>
        /// <param name="observer">наблюдатель</param>
        public void Unsubscribe(IDirectoryObserver observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// запускает наблюдение
        /// </summary>
        public void Start()
        {
            _timer = new Timer(_ => Poll(), null, TimeSpan.Zero, _interval);
        }

        /// <summary>
        /// останавливает наблюдение
        /// </summary>
        public void Stop()
        {
            _timer?.Dispose();
            _timer = null;
        }

        /// <summary>
        /// освобождает ресурсы
        /// </summary>
        public void Dispose()
        {
            Stop();
        }

        private void Poll()
        {
            var current = new DirectorySnapshot(_path);

            foreach (var created in current.Files.Keys.Except(_snapshot.Files.Keys))
                Notify(new DirectoryChange(created, DirectoryChangeType.Created));

            foreach (var deleted in _snapshot.Files.Keys.Except(current.Files.Keys))
                Notify(new DirectoryChange(deleted, DirectoryChangeType.Deleted));

            foreach (var common in current.Files.Keys.Intersect(_snapshot.Files.Keys))
                if (current.Files[common] != _snapshot.Files[common])
                    Notify(new DirectoryChange(common, DirectoryChangeType.Modified));

            _snapshot = current;
        }

        private void Notify(DirectoryChange change)
        {
            foreach (var observer in _observers)
                observer.OnDirectoryChanged(change);
        }
    }
}
