using System.Collections.Generic;
using System.Text.RegularExpressions;
using Entities.Entities;
using Program.Exceptions;
using Program.Interfaces;

namespace Program.Services
{
    public class ParserService : IParser
    {
        private readonly string _rawData;

        public ParserService(string rawData)
        {
            _rawData = rawData;
        }

        public ParsedProperties GetParsedData()
        {
            var stopPoints = ParsePoints();
            var field = ParseField();
            VerifyValidility(stopPoints, field);
            return new ParsedProperties
            {
                StopPoints = stopPoints,
                Field = field
            };
        }

        private void VerifyValidility(ICollection<Coordinate> stopPoints, Field field)
        {
            if (field.XSize < 0) throw new InvalidFieldCoordinateException("X coordinate cannot be less than zero");

            if (field.YSize < 0) throw new InvalidFieldCoordinateException("Y coordinate cannot be less than zero");
            foreach (var stopPoint in stopPoints)
            {
                if (stopPoint.XCoordinate > field.XSize)
                    throw new InvalidCoordinatesException("X coordinate of point is not in the field range");

                if (stopPoint.YCoordinate > field.YSize)
                    throw new InvalidCoordinatesException("Y coordinate of point is not in the field range");
                if (stopPoint.XCoordinate < 0 || stopPoint.YCoordinate < 0)
                    throw new InvalidCoordinatesException("Point coordinate cannot be negative");
            }
        }

        private Field ParseField()
        {
            var x = -1;
            var y = -1;
            var isX = true;
            var regexForRawField = new Regex(@"-?\d*x-?\d*");
            var regexForDigits = new Regex(@"-?[0-9]+");
            foreach (Match match in regexForDigits.Matches(regexForRawField.Match(_rawData).Value))
                if (isX)
                {
                    int.TryParse(match.Value, out x);
                    isX = false;
                }
                else
                {
                    int.TryParse(match.Value, out y);
                }

            return new Field
            {
                XSize = x,
                YSize = y
            };
        }

        private ICollection<Coordinate> ParsePoints()
        {
            ICollection<Coordinate> points = new List<Coordinate>();
            var expressionMain = new Regex(@"\((.*?)\)");
            var expressionForNumber = new Regex(@"-?[0-9]+");
            var matches = expressionMain.Matches(_rawData);
            foreach (Match match in matches)
            {
                var isX = true;
                var x = -1;
                var y = -1;
                foreach (Match numberMatch in expressionForNumber.Matches(match.Value))
                    if (isX)
                    {
                        int.TryParse(numberMatch.Value, out x);
                        isX = false;
                    }
                    else
                    {
                        int.TryParse(numberMatch.Value, out y);
                    }

                points.Add(new Coordinate
                {
                    XCoordinate = x,
                    YCoordinate = y
                });
            }

            return points;
        }
    }
}