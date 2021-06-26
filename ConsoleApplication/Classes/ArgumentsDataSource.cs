namespace ConsoleApplication
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