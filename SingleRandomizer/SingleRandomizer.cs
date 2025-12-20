using System;

namespace Utilities
{
    /// <summary>
    /// генератор случайных чисел в единственном экземпляре
    /// </summary>
    public sealed class SingleRandomizer
    {
        private static readonly Lazy<SingleRandomizer> _instance =
            new Lazy<SingleRandomizer>(() => new SingleRandomizer());

        private readonly Random _random;
        private readonly object _sync;

        /// <summary>
        /// предоставляет экземпляр генератора
        /// </summary>
        public static SingleRandomizer Instance => _instance.Value;

        private SingleRandomizer()
        {
            _random = new Random();
            _sync = new object();
        }

        /// <summary>
        /// возвращает следующее случайное число
        /// </summary>
        /// <returns>случайное число</returns>
        public int Next()
        {
            lock (_sync)
                return _random.Next();
        }

        /// <summary>
        /// возвращает случайное число в заданном диапазоне
        /// </summary>
        /// <param name="minValue">минимальное значение</param>
        /// <param name="maxValue">максимальное значение</param>
        /// <returns>случайное число</returns>
        /// <exception cref="ArgumentOutOfRangeException">некорректный диапазон</exception>
        public int Next(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException(nameof(minValue));

            lock (_sync)
                return _random.Next(minValue, maxValue);
        }
    }
}
