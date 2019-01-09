using System;

namespace AtmApp
{
    public class Program
    {
        public static int balance = 5000;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Interface();
        }
        public static void Interface()
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
                    ExitProgram();
                    break;

                default:
                    ExitProgram();
                    break;
            }


        }
        public static int UserPrompt()
        {
            string userResponseStr;
            bool running = true;
            do
            {
            Console.WriteLine("What would you like to do today? ( 1/2/3/4)");
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Deposit Money");
            Console.WriteLine("4. Exit");
            userResponseStr = Console.ReadLine();
                running = false;
                try
                {
                    int check = Convert.ToInt32(userResponseStr);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("That's not a valid response!");
                    running = true;               

                }
                catch (Exception)
                {
                    Console.WriteLine("Oops! Something went wrong!");
                    running = true;
                    throw;
                }
            } while (running == true);
            int userResponse = Convert.ToInt32(userResponseStr);
            return userResponse;
        }

        public static void ReadBalance()
        {
            Console.WriteLine($"Your Balance is: ${balance}");
            Interface();
        }
        public static void WithdrawMoney()
        {
            Console.WriteLine("How much would you like to withdraw?");
            string userResponseStr = Console.ReadLine();
            int userResponse = Convert.ToInt32(userResponseStr);
            SubtractMoney(userResponse);
            ReadBalance();
            Interface();
        }
        public static void DepositMoney()
        {
            Console.WriteLine("How much would you like to deposit?");
            string userResponseStr = Console.ReadLine();
            int userResponse = Convert.ToInt32(userResponseStr);
            AddMoney(userResponse);
            ReadBalance();
            Interface();
        }
        public static void ExitProgram()
        {
            Environment.Exit(0);
        }

        public static int AddMoney(int moneyAmount)
        {
            if (moneyAmount < 0 )
            {
                Console.WriteLine("Oops! No negative Numbers!");                
            }
            else
            {
            balance = balance + moneyAmount;
            }
            return balance;
        }

        public static int SubtractMoney(int moneyAmount)
        {
            if (moneyAmount < 0 || moneyAmount > balance)
            {
                Console.WriteLine("Oops! No negative Numbers!");
            }
            else
            {
                balance = balance - moneyAmount;
            }
            return balance;
        }
    }
}
