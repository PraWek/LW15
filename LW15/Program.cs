using System;

namespace FileSystemWatcher
{
    /// <summary>
    /// точка входа приложения
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// запускает приложение
        /// </summary>
        /// <param name="args">аргументы командной строки</param>
        private static void Main(string[] args)
        {
            var path = args.Length > 0 ? args[0] : Environment.CurrentDirectory;

            using var watcher = new PollingDirectoryWatcher(
                path,
                TimeSpan.FromSeconds(1));

            watcher.Subscribe(new ConsoleObserver());
            watcher.Start();

            Console.WriteLine("наблюдение запущено, нажмите enter для выхода");
            Console.ReadLine();
        }
    }
}
