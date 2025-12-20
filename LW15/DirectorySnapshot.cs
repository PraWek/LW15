using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemWatcher
{
    /// <summary>
    /// снимок состояния директории
    /// </summary>
    internal sealed class DirectorySnapshot
    {
        /// <summary>
        /// карта файлов и времени их изменения
        /// </summary>
        public Dictionary<string, DateTime> Files { get; }

        /// <summary>
        /// создает снимок директории
        /// </summary>
        /// <param name="path">путь к директории</param>
        public DirectorySnapshot(string path)
        {
            Files = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);

            foreach (var file in Directory.GetFiles(path))
                Files[file] = File.GetLastWriteTimeUtc(file);
        }
    }
}
