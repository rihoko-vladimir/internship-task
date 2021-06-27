using ConsoleApplication.Classes;
using ConsoleApplication.Interfaces;
using Xunit;

namespace Tests
{
    public class ArgumentDataSourceTest
    {
        [Fact]
        public void TestArgumentsAreTheSame()
        {
            var testArgument = "hello world";
            IDataSource dataSource = new ArgumentsDataSource(testArgument);
            var returnedArgument = dataSource.Data;
            Assert.Equal(testArgument, returnedArgument);
        }
    }
}