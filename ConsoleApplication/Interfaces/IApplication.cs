namespace ConsoleApplication.Interfaces
{
    public interface IApplication
    {
        void Run();
        IApplication Initialise(IDataSource dataSource);
    }
}