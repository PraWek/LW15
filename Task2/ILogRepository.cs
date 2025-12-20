namespace MyLogging
{
    /// <summary>
    /// репозиторий логов
    /// </summary>
    public interface ILogRepository
    {
        /// <summary>
        /// сохраняет запись лога
        /// </summary>
        /// <param name="entry">запись</param>
        void Save(LogEntry entry);
    }
}
