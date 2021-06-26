using ConsoleApplication.Classes;
using ConsoleApplication.Interfaces;
using Xunit;

namespace Tests
{
    public class ArgumentDataSourceTest
    {
        [Fact]
        public void Test()
        {
            var testArgument = "hello world";
            IDataSource dataSource = new ArgumentsDataSource(testArgument);
            Assert.Equal(dataSource.Data,testArgument);
        }
    }
}