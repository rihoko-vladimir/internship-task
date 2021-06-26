using ConsoleApplication.Interfaces;
using Program.Interfaces;
using Program.Services;

namespace ConsoleApplication.Classes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IDataSource dataSource;
            if (args.Length != 0)
                dataSource = new ArgumentsDataSource(string.Join("", args));
            else
                dataSource = new ConsoleDataSource();
            IParser parser = new ParserService(dataSource.Data);
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            IRobot robot = new DeliveryRobotService(calculator);
            IApplication application = new MainApplication(robot);
            application.Run();
        }
    }
}