using System;

namespace FileSystemWatcher
{
    /// <summary>
    /// описание изменения в директории
    /// </summary>
    public sealed class DirectoryChange
    {
        /// <summary>
        /// путь к файлу
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// тип изменения
        /// </summary>
        public DirectoryChangeType ChangeType { get; }

        /// <summary>
        /// время фиксации изменения
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// создает экземпляр изменения
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <param name="changeType">тип изменения</param>
        public DirectoryChange(string path, DirectoryChangeType changeType)
        {
            Path = path;
            ChangeType = changeType;
            Timestamp = DateTime.UtcNow;
        }
    }
}
