using System;
using Program.Interfaces;
using Program.Services;
using Xunit;

namespace Tests
{
    public class RobotTest
    {
        [Fact]
        public void TestRobotWithValidData()
        {
            IParser parser = new ParserService("5x5 (0, 0) (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)");
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            IRobot robot = new DeliveryRobotService(calculator);
            Assert.Equal("DNDENNDEDESDESDNDDNND", robot.GetRobotRoute());
        }

        [Fact]
        public void TestRobotWithInvalidData()
        {
            IParser parser = new ParserService("RYJNERYNSANBRSBRAWGINCLWERCGEXGMWLGWMLHGWELV;MWJVWEGLWGM");
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            IRobot robot = new DeliveryRobotService(calculator);
            Assert.ThrowsAny<Exception>(robot.GetRobotRoute);
        }
    }
}