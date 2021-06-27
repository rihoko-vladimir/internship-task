using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Entities;
using Program.Interfaces;
using Program.Services;
using Xunit;

namespace Tests
{
    public class DistanceCalculationTest
    {
        [Fact]
        public void TestCorrectRouteCalculation()
        {
            IParser parser = new ParserService("5x5 (0, 0) (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)");
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            var correctRoute = new List<RobotCommand>
            {
                RobotCommand.DropPizza,
                RobotCommand.MoveNorth,
                RobotCommand.DropPizza,
                RobotCommand.MoveEast,
                RobotCommand.MoveNorth,
                RobotCommand.MoveNorth,
                RobotCommand.DropPizza,
                RobotCommand.MoveEast,
                RobotCommand.DropPizza,
                RobotCommand.MoveEast,
                RobotCommand.MoveSouth,
                RobotCommand.DropPizza,
                RobotCommand.MoveEast,
                RobotCommand.MoveSouth,
                RobotCommand.DropPizza,
                RobotCommand.MoveNorth,
                RobotCommand.DropPizza,
                RobotCommand.DropPizza,
                RobotCommand.MoveNorth,
                RobotCommand.MoveNorth,
                RobotCommand.DropPizza
            };
            var calculatedRoute = calculator.GetRoute();
            Assert.True(!calculatedRoute.Except(correctRoute).Any());
        }

        [Fact]
        public void TestIncorrectDataBehaviour()
        {
            IParser parser = new ParserService("sdkjlhrknvsrkykjdgsdjfgknsdglds");
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            Assert.ThrowsAny<Exception>(calculator.GetRoute);
        }
    }
}