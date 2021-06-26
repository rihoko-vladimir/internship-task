using System;

namespace Program.Exceptions
{
    internal class InvalidFieldCoordinateException : Exception
    {
        public InvalidFieldCoordinateException(string errorDescription) : base(
            errorDescription)
        {
        }
    }
}