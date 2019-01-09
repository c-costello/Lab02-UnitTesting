using System;

namespace AtmApp
{
    class Program
    {
        public static int balance = 5000;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Interface();
        }
        static void Interface()
        {
            int userResponse = UserPrompt();

            switch (userResponse)
            {
                case 1:
                    ReadBalance();
                    break;

                case 2:
                    WithdrawMoney();
                    break;
                case 3:
                    DepositMoney();
                    break;
                case 4:
                    // ExitProgram();
                    break;
                default:
                    // ExitProgram();
                    break;
            }


        }
        static int UserPrompt()
        {
            Console.WriteLine("What would you like to do today? ( 1/2/3/4)");
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Exit");
            string userResponseStr = Console.ReadLine();
            int userResponse = Convert.ToInt32(userResponseStr);
            return userResponse;
        }

        static void ReadBalance()
        {
            Console.WriteLine($"Your Balance is: ${balance}");
        }
        static void WithdrawMoney()
        {
            Console.WriteLine("How much would you like to withdraw?");
            string userResponseStr = Console.ReadLine();
            int userResponse = Convert.ToInt32(userResponseStr);
            balance = balance - userResponse;
            ReadBalance();
            Interface();
        }
        static void DepositMoney()
        {
            Console.WriteLine("How much would you like to deposit?");
            string userResponseStr = Console.ReadLine();
            int userResponse = Convert.ToInt32(userResponseStr);
            balance = balance + userResponse;
            ReadBalance();
            Interface();
        }
    }
}
