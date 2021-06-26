using System;
using Entities.Entities;

namespace Program.Extensions
{
    public static class RobotCommandExtension
    {
        public static string ToFriendlyString(this RobotCommand command)
        {
            switch (command)
            {
                case RobotCommand.DropPizza:
                {
                    return "D";
                }
                case RobotCommand.MoveEast:
                {
                    return "E";
                }
                case RobotCommand.MoveNorth:
                {
                    return "N";
                }
                case RobotCommand.MoveSouth:
                {
                    return "S";
                }
                case RobotCommand.MoveWest:
                {
                    return "W";
                }
                default:
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}