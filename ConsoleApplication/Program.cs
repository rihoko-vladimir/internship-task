using System;
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
                Launch(args[0]);
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