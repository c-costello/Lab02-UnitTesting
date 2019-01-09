using System;

namespace AtmApp
{
    public class Program
    {
        public static decimal balance = 5000;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATM!");
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
                if (userResponseStr == "")
               {
                    ExitProgram();
               }
                running = false;
                try
                {
                    int check = Convert.ToInt32(userResponseStr);
                }
                catch (FormatException)
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
            bool running = true;
            string userResponseStr;
            do
            {
                running = false;
                Console.WriteLine("How much would you like to withdraw?");
                userResponseStr = Console.ReadLine();
                try
                {
                    decimal check = Convert.ToDecimal(userResponseStr);
                }
                catch (FormatException)
                {

                    Console.WriteLine("That's not a number!");
                    running = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("That's too much money. Deposit a smaller amount?");
                    Console.Write("y/n: ");
                    string response = Console.ReadLine();
                    if (response == "y")
                    {
                        running = true;  
                    } 
                    else
                    {
                        Interface();
                    }
                }


            } while (running == true);
            decimal userResponse = Convert.ToDecimal(userResponseStr);
            SubtractMoney(userResponse);
            ReadBalance();
            Interface();
        }
        public static void DepositMoney()
        {
            bool running = true;
            string userResponseStr;
            do
            {
                running = false;
                Console.WriteLine("How much would you like to deposit?");
                userResponseStr = Console.ReadLine();
                try
                {
                    decimal check = Convert.ToDecimal(userResponseStr);
                }
                catch (FormatException)
                {

                    Console.WriteLine("That's not a number!");
                    running = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("That's too much money. Deposit a smaller amount?");
                    Console.Write("y/n: ");
                    string response = Console.ReadLine();
                    if (response == "y")
                    {
                        running = true;
                    }
                    else
                    {
                        Interface();
                    }
                }


            } while (running == true);




            decimal userResponse = Convert.ToDecimal(userResponseStr);
            AddMoney(userResponse);
            ReadBalance();
            Interface();
        }
        public static void ExitProgram()
        {
            Environment.Exit(0);
        }

        public static decimal AddMoney(decimal moneyAmount)
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
        public static decimal SubtractMoney(decimal moneyAmount)
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
