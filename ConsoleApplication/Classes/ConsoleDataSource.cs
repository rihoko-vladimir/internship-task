using System;
using ConsoleApplication.Interfaces;

namespace ConsoleApplication.Classes
{
    public class ConsoleDataSource : IDataSource
    {
        public string GetData()
        {
            var userData = Console.ReadLine();
            UserDataValidator(userData);
            return userData;
        }

        private void UserDataValidator(string userData)
        {
            if (userData.Length==0)
            {
                throw new ArgumentException("Input string cannot be empty");
            }
        }
    }
}