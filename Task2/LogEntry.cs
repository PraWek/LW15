using System;

namespace MyLogging
{
    /// <summary>
    /// запись лога
    /// </summary>
    public sealed class LogEntry
    {
        /// <summary>
        /// время записи
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// уровень сообщения
        /// </summary>
        public string Level { get; }

        /// <summary>
        /// текст сообщения
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// создает запись лога
        /// </summary>
        /// <param name="level">уровень</param>
        /// <param name="message">сообщение</param>
        public LogEntry(string level, string message)
        {
            Timestamp = DateTime.UtcNow;
            Level = level;
            Message = message;
        }
    }
}
