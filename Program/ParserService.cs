using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Entities;

namespace Program
{
    public class ParserService : IParserService
    {
        private string _rawData;
        public ParserService(string rawData)
        {
            _rawData = rawData;
        }
        public CalculatedProperties GetParsedData()
        {
            List<IStopPoint> stopPoints  = _ParsePoints();
            IFieldDefinition field = _ParseField();
            _VerifyValidility(stopPoints, field);
            return new CalculatedProperties(field,stopPoints);
        }

        private void _VerifyValidility(List<IStopPoint> stopPoints, IFieldDefinition field)
        {
            if (field.XSize<0)
            {
                throw new InvalidFieldCoordinateException("X coordinate cannot be less than zero");
            }

            if (field.YSize<0)
            {
                throw new InvalidFieldCoordinateException("Y coordinate cannot be less than zero");
            }
            foreach (IStopPoint stopPoint in stopPoints)
            {
                if (stopPoint.XCoordinate>field.XSize)
                {
                    throw new InvalidCoordinatesException("X coordinate of point is not in the field range");
                }

                if (stopPoint.YCoordinate>field.YSize)
                {
                    throw new InvalidCoordinatesException("Y coordinate of point is not in the field range");
                }
            }
        }

        private IFieldDefinition _ParseField()
        {
            
        }

        private List<IStopPoint> _ParsePoints()
        {
            throw new System.NotImplementedException();
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