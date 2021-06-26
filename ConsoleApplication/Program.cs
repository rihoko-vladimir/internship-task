using System;
using System.Linq;
using Program.Interfaces;
using Program.Services;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IDataSource dataSource;
            IApplication application = new MainApplication();
            if (args.Length!=0)
            {
                dataSource = new ArgumentsDataSource(string.Join(" ", args));
            }
            else
            {
                dataSource = new ConsoleDataSource();
            }
            application.Initialise(dataSource).Run();
        }
    }
}