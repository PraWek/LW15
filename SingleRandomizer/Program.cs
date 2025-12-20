using System;
using System.Threading.Tasks;
using Utilities;

class Program
{
    static void Main()
    {
        Parallel.For(0, 5, _ =>
        {
            var value = SingleRandomizer.Instance.Next(1, 100);
            Console.WriteLine(value);
        });
    }
}
