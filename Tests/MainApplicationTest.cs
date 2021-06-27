using System;
using ConsoleApplication.Classes;
using ConsoleApplication.Interfaces;
using Program.Interfaces;
using Program.Services;
using Xunit;

namespace Tests
{
    public class MainApplicationTest
    {
        [Fact]
        public void RunWithCorrectDataTest()
        {
            IParser parser = new ParserService("5x5 (0, 0) (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)");
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            IRobot robot = new DeliveryRobotService(calculator);
            IApplication mainApplication = new MainApplication(robot);
            try
            {
                mainApplication.Run();
            }
            catch (Exception e)
            {
                Assert.False(false, $"Actually, something breaks: {e}");
            }
        }
    }
}