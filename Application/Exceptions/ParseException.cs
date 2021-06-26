using System;

namespace Program.Exceptions
{
    internal class ParseException : Exception
    {
        public ParseException(string invalidData):base(invalidData)
        {
        }
    }
}