using System;

namespace FileSystemWatcher
{
    /// <summary>
    /// наблюдатель, выводящий изменения в консоль
    /// </summary>
    public sealed class ConsoleObserver : IDirectoryObserver
    {
        /// <summary>
        /// обрабатывает изменение директории
        /// </summary>
        /// <param name="change">информация об изменении</param>
        public void OnDirectoryChanged(DirectoryChange change)
        {
            Console.WriteLine($"{change.ChangeType}: {change.Path}");
        }
    }
}
