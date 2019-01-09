using System;
using Xunit;
using AtmApp;

namespace AtmTests
{
    public class UnitTest1
    {
        [Fact]
        public void CannotAddNegatives()
        {
            Assert.Equal(5000, Program.AddMoney(-500));
        }
    }
}
