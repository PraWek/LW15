using System;
using System.Collections.Generic;

namespace MyLogging
{
    /// <summary>
    /// логгер приложения
    /// </summary>
    public sealed class MyLogger
    {
        private readonly IReadOnlyCollection<ILogRepository> _repositories;

        /// <summary>
        /// создает логгер
        /// </summary>
        /// <param name="repositories">репозитории</param>
        /// <exception cref="ArgumentNullException">repositories равен null</exception>
        public MyLogger(IEnumerable<ILogRepository> repositories)
        {
            _repositories = repositories?.ToList()
                ?? throw new ArgumentNullException(nameof(repositories));
        }

        /// <summary>
        /// записывает информационное сообщение
        /// </summary>
        /// <param name="message">сообщение</param>
        public void Info(string message)
        {
            Log("info", message);
        }

        /// <summary>
        /// записывает сообщение об ошибке
        /// </summary>
        /// <param name="message">сообщение</param>
        public void Error(string message)
        {
            Log("error", message);
        }

        private void Log(string level, string message)
        {
            var entry = new LogEntry(level, message);

            foreach (var repository in _repositories)
                repository.Save(entry);
        }
    }
}
