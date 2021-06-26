using System;
using System.Linq;
using Program.Interfaces;
using Program.Services;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length!=0)
            {
                var concatenatedArgs = string.Join(" ",args);
                Launch(concatenatedArgs);
                return;
            }

            Console.WriteLine("Enter your data:");
            var userData = Console.ReadLine();
            Launch(userData);
        }

        private static void Launch(string inputData)
        {
            IParser parser = new ParserService(inputData);
            IDistanceCalculator distanceCalculator = new DistanceCalculationService(parser);
            IRobot robot = new DeliveryRobotService(distanceCalculator);
            robot.Delivery();
        }
    }
}