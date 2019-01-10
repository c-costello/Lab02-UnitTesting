using System;
using Xunit;
using AtmApp;

namespace AtmTests
{
    public class UnitTest1
    {
        //AddMoney tests
        [Fact]
        public void CanAddTwoNumbers()
        {
            Program.balance = 5000;
            Assert.Equal(6000, Program.AddMoney(1000));
        }

        [Fact]
        public void CannotAddNegatives()
        {
            Program.balance = 5000;
            Assert.Equal(5000, Program.AddMoney(-500));
        }

        //SubtractMoney tests
        [Fact]
        public void CanSubtractTwoNumbers()
        {
            Program.balance = 5000;
            Assert.Equal(4000, Program.SubtractMoney(1000));
        }
        [Fact]
        public void CannotWithdrawNegatives()

        {
            Program.balance = 5000;
            Assert.Equal(5000, Program.SubtractMoney(-500));
        }
        [Fact]
        public void CannotWithdrawMoreThanBalance()
        {
            Program.balance = 5000;
            Assert.Equal(5000, Program.SubtractMoney(6000));
        }

        //UserPrompt tests
        [Fact]
        public void CanAcceptOne()
        {
            Assert.Equal(1, Program.UserPrompt("1"));
        }
        [Fact]
        public void CanAcceptTwo()
        {
            Assert.Equal(2, Program.UserPrompt("2"));
        }
        [Fact]
        public void CanAcceptThree()
        {
            Assert.Equal(3, Program.UserPrompt("3"));
        }
        [Fact]
        public void CanAcceptFour()
        {
            Assert.Equal(4, Program.UserPrompt("4"));
        }
        //ExceptionCheck tests
        [Fact]
        public void CanHandleNumbers()
        {
            Assert.False(Program.ExceptionCheck("12", true));
        }
        [Fact]
        public void DoesNotPassStrings()
        {
            Assert.True(Program.ExceptionCheck("twelve", true));
        }
    }
}
