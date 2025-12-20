using System;

namespace MyLogging
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
            var logger = CreateLogger();

            logger.Info("The application is running");
            DoWork(logger);
            logger.Info("The application is running");

            Console.WriteLine("logs are recorded, press enter to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// создает экземпляр логгера
        /// </summary>
        /// <returns>логгер</returns>
        private static MyLogger CreateLogger()
        {
            return new MyLogger(new ILogRepository[]
            {
                new TextFileLogRepository("log.txt"),
                new JsonFileLogRepository("log.json")
            });
        }

        /// <summary>
        /// имитирует рабочий процесс
        /// </summary>
        /// <param name="logger">логгер</param>
        private static void DoWork(MyLogger logger)
        {
            try
            {
                logger.Info("performing the operation");
                ThrowIfNeeded();
                logger.Info("the operation was completed successfully");
            }
            catch (Exception ex)
            {
                logger.Error($"execution error: {ex.Message}");
            }
        }

        /// <summary>
        /// генерирует исключение для примера
        /// </summary>
        /// <exception cref="InvalidOperationException">пример ошибки</exception>
        private static void ThrowIfNeeded()
        {
            throw new InvalidOperationException("test exception");
        }
    }
}
