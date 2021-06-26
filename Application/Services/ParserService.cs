using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Entities.Entities;
using Entities.Interfaces;
using Program.Interfaces;

namespace Program.Services
{
    public class ParserService : IParserService
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
            return new ParsedProperties(field, stopPoints);
        }

        private void VerifyValidility(List<IStopPoint> stopPoints, IFieldDefinition field)
        {
            if (field.XSize < 0) throw new InvalidFieldCoordinateException("X coordinate cannot be less than zero");

            if (field.YSize < 0) throw new InvalidFieldCoordinateException("Y coordinate cannot be less than zero");
            foreach (var stopPoint in stopPoints)
            {
                if (stopPoint.XCoordinate > field.XSize)
                    throw new InvalidCoordinatesException("X coordinate of point is not in the field range");

                if (stopPoint.YCoordinate > field.YSize)
                    throw new InvalidCoordinatesException("Y coordinate of point is not in the field range");
                if (stopPoint.XCoordinate<0||stopPoint.YCoordinate<0)
                {
                    throw new InvalidCoordinatesException("Point coordinate cannot be negative");
                }
            }
        }

        private IFieldDefinition ParseField()
        {
            var x = -1;
            var y = -1;
            var tempBuilder = new StringBuilder();
            for (var i = 0; i < _rawData.Length; i++)
            {
                var currentCharacter = _rawData[i];
                if (currentCharacter == 'x')
                {
                    int.TryParse(tempBuilder.ToString(), out x);
                    tempBuilder.Clear();
                    continue;
                }

                if (currentCharacter == ' ')
                {
                    int.TryParse(tempBuilder.ToString(), out y);
                    break;
                }

                tempBuilder.Append(currentCharacter);
            }

            return new Field(x, y);
        }

        private List<IStopPoint> ParsePoints()
        {
            List<IStopPoint> points = new List<IStopPoint>();
            var expressionMain = new Regex(@"\((.*?)\)");
            var expressionForNumber = new Regex(@"-?[0-9]+");
            var matches = expressionMain.Matches(_rawData);
            foreach (Match match in matches)
            {
                var isX = true;
                var x = -1;
                var y = -1;
                foreach (Match numberMatch in expressionForNumber.Matches(match.Value))
                {
                    if (isX)
                    {
                        Int32.TryParse(numberMatch.Value, out x);
                        isX = false;
                    }
                    else
                    {
                        Int32.TryParse(numberMatch.Value, out y);
                    }
                }

                points.Add(new StopPoint(x, y));
            }

            return points;
        }
    }

    internal class InvalidFieldCoordinateException : Exception
    {
        public InvalidFieldCoordinateException(string errorDescription) : base(
            errorDescription)
        {
        }
    }

    internal class InvalidCoordinatesException : Exception
    {
        public InvalidCoordinatesException(string errorDescription) : base(errorDescription)
        {
        }
    }
}