using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using Xunit;
using Program = console_calculator.Program;
namespace test_1
{
    
    public class UnitTest1
    {
        Program x = new Program();
        [Fact]
        public void Test1()
        {
            Assert.Equal("4", x.Calculate("2 + 2"));
        }
        [Fact]
        public void Test2()
        {
            Assert.Equal("4", x.Calculate("2 * 2"));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal("5", x.Calculate("10 / 2"));
        }
        [Fact]
        public void Test4()
        {
            Assert.Equal("1", x.Calculate("2 - 1"));
        }


    }
}
