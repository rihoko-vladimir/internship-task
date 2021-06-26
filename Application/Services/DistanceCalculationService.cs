using System.Collections.Generic;
using System.Linq;
using Entities.Entities;
using Entities.Interfaces;
using Program.Interfaces;

namespace Program.Services
{
    public class DistanceCalculationService : IDistanceCalculator
    {
        private readonly IParser _parser;

        public DistanceCalculationService(IParser parser)
        {
            _parser = parser;
        }

        public ICollection<RobotCommand> GetRoute()
        {
            return CalculateWholeRoute();
        }

        private ICollection<RobotCommand> CalculateWholeRoute()
        {
            var route = new List<RobotCommand>();
            var sortedPoints = GetSortedStopPoints();
            route.AddRange(CalculateToNextPoint(new Coordinate(0,0), sortedPoints[0]));
            for (var i = 0; i < sortedPoints.Count - 1; i++)
                route.AddRange(CalculateToNextPoint(sortedPoints[i], sortedPoints[i + 1]));
            return route;
        }


        private List<ICoordinate> GetSortedStopPoints()
        {
            return _parser.GetParsedData().StopPoints.OrderBy(point => point.XCoordinate)
                .ThenBy(point => point.YCoordinate).ToList();
        }

        private ICollection<RobotCommand> CalculateToNextPoint(ICoordinate startCoordinate, ICoordinate nextCoordinate)
        {
            ICollection<RobotCommand> commands = new LinkedList<RobotCommand>();
            var currentPosition = new Position
                {XCoordinate = startCoordinate.XCoordinate, YCoordinate = startCoordinate.YCoordinate};
            while (currentPosition.XCoordinate <= nextCoordinate.XCoordinate &&
                   currentPosition.YCoordinate <= nextCoordinate.YCoordinate)
            {
                if (currentPosition.XCoordinate == nextCoordinate.XCoordinate &&
                    currentPosition.YCoordinate == nextCoordinate.YCoordinate)
                {
                    commands.Add(RobotCommand.DropPizza);
                    break;
                }

                if (currentPosition.XCoordinate < nextCoordinate.XCoordinate)
                {
                    commands.Add(RobotCommand.MoveEast);
                    currentPosition.XCoordinate++;
                }

                if (currentPosition.XCoordinate > nextCoordinate.XCoordinate)
                {
                    commands.Add(RobotCommand.MoveWest);
                    currentPosition.XCoordinate--;
                }

                if (currentPosition.YCoordinate < nextCoordinate.YCoordinate)
                {
                    commands.Add(RobotCommand.MoveNorth);
                    currentPosition.YCoordinate++;
                }

                if (currentPosition.YCoordinate > nextCoordinate.YCoordinate)
                {
                    commands.Add(RobotCommand.MoveSouth);
                    currentPosition.YCoordinate--;
                }
            }

            return commands;
        }

        private record Position : ICoordinate
        {
            public int XCoordinate { get; set; }
            public int YCoordinate { get; set; }
        }
    }
}