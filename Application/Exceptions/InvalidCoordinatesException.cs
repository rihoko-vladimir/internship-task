using System;

namespace Program.Exceptions
{
    public class InvalidCoordinatesException : Exception
    {
        public InvalidCoordinatesException(string errorDescription) : base(errorDescription)
        {
        }
    }
}