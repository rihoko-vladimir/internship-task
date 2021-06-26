using System;
using Microsoft.VisualBasic.CompilerServices;
using Program.Interfaces;
using Program.Services;

namespace ConsoleApplication
{
    public class MainApplication : IApplication
    {
        private string _rawString = "";
        public void Run()
        {
            if (_rawString.Length==0)
            {
                throw new InitialisationException("You must invoke Initialise method before calling Run");
            }
            IParser parser = new ParserService(_rawString);
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            IRobot robot = new DeliveryRobotService(calculator);
            robot.Delivery();
        }

        public IApplication Initialise(IDataSource dataSource)
        {
            _rawString = dataSource.GetData();
            return this;
        }

        private class InitialisationException : Exception
        {
            public InitialisationException(string message) : base(message)
            {
            }
        }
    }
}