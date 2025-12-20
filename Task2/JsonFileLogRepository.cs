using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MyLogging
{
    /// <summary>
    /// репозиторий логов в json файл
    /// </summary>
    public sealed class JsonFileLogRepository : ILogRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// создает репозиторий
        /// </summary>
        /// <param name="path">путь к файлу</param>
        public JsonFileLogRepository(string path)
        {
            _path = path;
            _options = new JsonSerializerOptions { WriteIndented = true };
        }

        /// <summary>
        /// сохраняет запись лога
        /// </summary>
        /// <param name="entry">запись</param>
        public void Save(LogEntry entry)
        {
            var entries = Load();
            entries.Add(entry);

            var json = JsonSerializer.Serialize(entries, _options);
            File.WriteAllText(_path, json);
        }

        private List<LogEntry> Load()
        {
            if (!File.Exists(_path))
                return new List<LogEntry>();

            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<LogEntry>>(json) ?? new List<LogEntry>();
        }
    }
}
