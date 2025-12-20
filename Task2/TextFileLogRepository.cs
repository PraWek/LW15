using System.IO;
using System.Text;

namespace MyLogging
{
    /// <summary>
    /// репозиторий логов в текстовый файл
    /// </summary>
    public sealed class TextFileLogRepository : ILogRepository
    {
        private readonly string _path;

        /// <summary>
        /// создает репозиторий
        /// </summary>
        /// <param name="path">путь к файлу</param>
        public TextFileLogRepository(string path)
        {
            _path = path;
        }

        /// <summary>
        /// сохраняет запись лога
        /// </summary>
        /// <param name="entry">запись</param>
        public void Save(LogEntry entry)
        {
            var line = $"{entry.Timestamp:o} [{entry.Level}] {entry.Message}";
            File.AppendAllText(_path, line + "\n", Encoding.UTF8);
        }
    }
}
