using System;
using System.Diagnostics;

namespace Obacher.Decade
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePainter painter = new ConsolePainter();
            Simulations simulations = new Simulations();

            const decimal count = int.MaxValue;
            Stopwatch stopWatch = Stopwatch.StartNew();
            simulations.Start((int)count);
            stopWatch.Stop();

            Console.WriteLine("Elapsed Time: " + stopWatch.Elapsed);
            Console.WriteLine("Winning Hands: " + simulations.WinningCount);
            Console.WriteLine("Odds: " + (simulations.WinningCount / count) * 100);
            Console.ReadKey();
        }
    }
}
