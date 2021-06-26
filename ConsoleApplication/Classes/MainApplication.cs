using ConsoleApplication.Interfaces;
using Program.Interfaces;

namespace ConsoleApplication.Classes
{
    public class MainApplication : IApplication
    {
        private readonly IRobot _robot;

        public MainApplication(IRobot robot)
        {
            _robot = robot;
        }

        public void Run()
        {
            _robot.Delivery();
        }
    }
}