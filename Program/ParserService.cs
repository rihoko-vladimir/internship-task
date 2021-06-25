using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Program
{
    public class ParserService : IParserService
    {
        private readonly string _rawData;

        public ParserService(string rawData)
        {
            _rawData = rawData;
        }

        public CalculatedProperties GetParsedData()
        {
            var stopPoints = _ParsePoints();
            var field = _ParseField();
            _VerifyValidility(stopPoints, field);
            return new CalculatedProperties(field, stopPoints);
        }

        private void _VerifyValidility(List<IStopPoint> stopPoints, IFieldDefinition field)
        {
            if (field.XSize < 0) throw new InvalidFieldCoordinateException("X coordinate cannot be less than zero");

            if (field.YSize < 0) throw new InvalidFieldCoordinateException("Y coordinate cannot be less than zero");
            foreach (var stopPoint in stopPoints)
            {
                if (stopPoint.XCoordinate > field.XSize)
                    throw new InvalidCoordinatesException("X coordinate of point is not in the field range");

                if (stopPoint.YCoordinate > field.YSize)
                    throw new InvalidCoordinatesException("Y coordinate of point is not in the field range");
            }
        }

        private IFieldDefinition _ParseField()
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

        private List<IStopPoint> _ParsePoints()
        {
            throw new NotImplementedException();
        }
    }

    internal class InvalidFieldCoordinateException : Exception
    {
        public InvalidFieldCoordinateException(string xCoordinateCannotBeLessThanZero) : base(
            xCoordinateCannotBeLessThanZero)
        {
        }
    }

    internal class InvalidCoordinatesException : Exception
    {
        public InvalidCoordinatesException(string xCoordinateIsInvalid)
        {
            throw new NotImplementedException();
        }
    }
}