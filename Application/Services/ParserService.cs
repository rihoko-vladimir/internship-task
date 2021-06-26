using System;
using System.Collections.Generic;
using System.Linq;
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

        public Field Field => ParseField();
        public ICollection<Coordinate> Coordinates => ParsePoints();

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

            var field = new Field
            {
                XSize = x,
                YSize = y
            };
            VerifyField(field);
            return field;
        }

        private ICollection<Coordinate> ParsePoints()
        {
            ICollection<Coordinate> points = new List<Coordinate>();
            var expressionMain = new Regex(@"\((.*?)\)");
            var expressionForNumber = new Regex(@"-?[0-9]+");
            var matches = expressionMain.Matches(_rawData);
            if (matches.Count == 0) throw new ParseException("Invalid data");
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

            VerifyPoints(points);

            return points;
        }

        private void VerifyField(Field field)
        {
            if (field.XSize < 0) throw new InvalidFieldCoordinateException("X coordinate cannot be less than zero");

            if (field.YSize < 0) throw new InvalidFieldCoordinateException("Y coordinate cannot be less than zero");
        }

        private void VerifyPoints(ICollection<Coordinate> stopPoints)
        {
            if (stopPoints.Any(stopPoint => stopPoint.XCoordinate < 0 || stopPoint.YCoordinate < 0))
                throw new InvalidCoordinatesException("Point coordinate cannot be negative");
        }
    }
}