namespace ConsoleApplication
{
    public interface IApplication
    {
        void Run();
        IApplication Initialise(IDataSource dataSource);
    }
}