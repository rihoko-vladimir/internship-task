using ConsoleApplication.Interfaces;

namespace ConsoleApplication.Classes
{
    public class ArgumentsDataSource : IDataSource
    {
        public ArgumentsDataSource(string arguments)
        {
            Data = arguments;
        }

        public string Data { get; }
    }
}