using System;
using ConsoleApplication.Interfaces;

namespace ConsoleApplication.Classes
{
    public class ConsoleDataSource : IDataSource
    {
        public string Data
        {
            get
            {
                var userData = Console.ReadLine();
                Validate(userData);
                return userData;
            }
        }

        private void Validate(string userData)
        {
            if (string.IsNullOrWhiteSpace(userData)) throw new ArgumentException("Input string cannot be empty");
        }
    }
}