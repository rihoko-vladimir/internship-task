using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Entities;
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
            foreach (var sortedPoint in sortedPoints) Console.WriteLine(sortedPoint);
            route.AddRange(CalculateToNextPoint(new Coordinate
            {
                XCoordinate = 0,
                YCoordinate = 0
            }, sortedPoints[0]));
            Console.WriteLine();
            for (var i = 0; i < sortedPoints.Count - 1; i++)
                route.AddRange(CalculateToNextPoint(sortedPoints[i], sortedPoints[i + 1]));
            return route;
        }


        private List<Coordinate> GetSortedStopPoints()
        {
            return _parser.GetParsedData().StopPoints.OrderBy(point => point.XCoordinate)
                .ThenBy(point => point.YCoordinate).ToList();
        }

        private ICollection<RobotCommand> CalculateToNextPoint(Coordinate startCoordinate, Coordinate nextCoordinate)
        {
            ICollection<RobotCommand> commands = new LinkedList<RobotCommand>();
            if (startCoordinate.XCoordinate < nextCoordinate.XCoordinate)
                for (var i = startCoordinate.XCoordinate; i < nextCoordinate.XCoordinate; i++)
                    commands.Add(RobotCommand.MoveEast);
            if (startCoordinate.YCoordinate < nextCoordinate.YCoordinate)
                for (var i = startCoordinate.YCoordinate; i < nextCoordinate.YCoordinate; i++)
                    commands.Add(RobotCommand.MoveNorth);
            if (startCoordinate.XCoordinate > nextCoordinate.XCoordinate)
                for (var i = startCoordinate.XCoordinate; i > nextCoordinate.XCoordinate; i--)
                    commands.Add(RobotCommand.MoveWest);
            if (startCoordinate.YCoordinate > nextCoordinate.YCoordinate)
                for (var i = startCoordinate.YCoordinate; i > nextCoordinate.YCoordinate; i--)
                    commands.Add(RobotCommand.MoveSouth);
            commands.Add(RobotCommand.DropPizza);
            return commands;
        }

        private record Position
        {
            public int XCoordinate { get; set; }
            public int YCoordinate { get; set; }
        }
    }
}