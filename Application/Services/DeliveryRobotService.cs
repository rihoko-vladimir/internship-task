using System;
using Entities.Entities;
using Program.Interfaces;

namespace Program.Services
{
    public class DeliveryRobotService : IRobot
    {
        private readonly IDistanceCalculator _distanceCalculator;

        public DeliveryRobotService(IDistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
        }

        public void Delivery()
        {
            foreach (var robotCommand in _distanceCalculator.GetRoute())
                switch (robotCommand)
                {
                    case RobotCommand.DropPizza:
                    {
                        Console.Write("D");
                        break;
                    }
                    case RobotCommand.MoveEast:
                    {
                        Console.Write("E");
                        break;
                    }
                    case RobotCommand.MoveNorth:
                    {
                        Console.Write("N");
                        break;
                    }
                    case RobotCommand.MoveSouth:
                    {
                        Console.Write("S");
                        break;
                    }
                    case RobotCommand.MoveWest:
                    {
                        Console.Write("W");
                        break;
                    }
                    default:
                    {
                        throw new ArgumentException();
                    }
                }
        }
    }
}