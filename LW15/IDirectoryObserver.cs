namespace FileSystemWatcher
{
    /// <summary>
    /// наблюдатель изменений директории
    /// </summary>
    public interface IDirectoryObserver
    {
        /// <summary>
        /// вызывается при обнаружении изменений
        /// </summary>
        /// <param name="change">информация об изменении</param>
        void OnDirectoryChanged(DirectoryChange change);
    }
}
