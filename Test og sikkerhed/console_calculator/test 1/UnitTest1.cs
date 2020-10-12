using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using console_calculator;
using Xunit;

namespace test_1
{
    
    public class UnitTest1
    {
        Program x = new Program();
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, x.Calculate("2 + 2"));
        }
    }
}
