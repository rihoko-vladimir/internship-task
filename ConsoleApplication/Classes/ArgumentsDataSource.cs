using ConsoleApplication.Interfaces;

namespace ConsoleApplication.Classes
{
    public class ArgumentsDataSource : IDataSource
    {
        private readonly string _arguments;
        public ArgumentsDataSource(string arguments)
        {
            _arguments = arguments;
        }

        public string GetData()
        {
            return _arguments;
        }
    }
}