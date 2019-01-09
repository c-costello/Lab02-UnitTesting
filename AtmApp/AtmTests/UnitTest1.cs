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
        [Fact]
        public void CannotWithdrawNegatives()
        {
            Assert.Equal(5000, Program.SubtractMoney(-500));
        }
        [Fact]
        public void CannotWithdrawMoreThanBalance()
        {
            Assert.Equal(5000, Program.SubtractMoney(6000));
        }
    }
}
