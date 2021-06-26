using System;
using Program.Interfaces;
using Program.Services;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IParser parser =
                new ParserService("5x5 (0, 0) (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)");
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            foreach (var robotCommand in calculator.GetRoute())
            {
                Console.WriteLine(robotCommand);
            }
        }
    }
}