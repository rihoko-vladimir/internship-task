using System.Collections.Generic;
using System.Linq;
using Entities.Entities;
using Program.Exceptions;
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
            VerifyPointsAreInField(_parser.Coordinates, _parser.Field);
            var route = new List<RobotCommand>();
            var sortedPoints = GetSortedStopPoints();
            route.AddRange(CalculateToNextPoint(new Coordinate
            {
                XCoordinate = 0,
                YCoordinate = 0
            }, sortedPoints[0]));
            for (var i = 0; i < sortedPoints.Count - 1; i++)
                route.AddRange(CalculateToNextPoint(sortedPoints[i], sortedPoints[i + 1]));
            return route;
        }

        private void VerifyPointsAreInField(ICollection<Coordinate> parserCoordinates, Field parserField)
        {
            foreach (var parserCoordinate in parserCoordinates)
                if (parserCoordinate.XCoordinate > parserField.XSize ||
                    parserCoordinate.YCoordinate > parserField.YSize)
                    throw new InvalidCoordinatesException("Point is out of field range");
        }


        private List<Coordinate> GetSortedStopPoints()
        {
            return _parser.Coordinates.OrderBy(point => point.XCoordinate)
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
    }
}