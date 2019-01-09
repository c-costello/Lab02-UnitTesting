using System;

namespace AtmApp
{
    public class Program
    {
        public static decimal balance = 5000;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATM!");
            //calls the interface
            Interface();
        }
        //method that handles the interface and allows the user to see their options. Handles their selections
        public static void Interface()
        {
            //user instructions and prompts to select a method 
            Console.WriteLine("What would you like to do today? ( 1/2/3/4)");
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Deposit Money");
            Console.WriteLine("4. Exit");
            string userResponseStr = Console.ReadLine();
            //exception catcher and other error handler. UserPrompt processes the input
            int userResponse = UserPrompt(userResponseStr);
            //case switch that handles the UserResponse and calls the selected method
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
        //method handles the user input and converts the string to a decimal
        public static int UserPrompt(string userInput)
        {
            string userResponseStr = userInput;
            //if user hits enter, the program ends
            if (userResponseStr == "")
            {
                ExitProgram();
            }  
            //try catch block to check for Format and OverFlow exceptions
            //if an exception is caught, Interface is called and re-prompts user to select their method
            try
            {
                int check = Convert.ToInt32(userResponseStr);
            }
            catch (FormatException)
            {
                Console.WriteLine("That's not a valid response!");
                Interface();              

            }
            catch (Exception)
            {
                Console.WriteLine("Oops! Something went wrong!");
                Interface();
                throw;
            }
            //if no exceptions are caught, the method converts the string without issue 
            int userResponse = Convert.ToInt32(userResponseStr);
            return userResponse;
        }
        //reads the given balance. Balance always starts at 5000
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
                //try catch block to check for Format and OverFlow exceptions
                //if an exception is caught, Interface is called and re-prompts user to select their method
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
                    //if the user inputs a number to large for decimal to handle, the user is prompted to re-enter their amount, or got back to interface 
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
            //if no exception is caught, the method then converts the string to a decimal without issues
            decimal userResponse = Convert.ToDecimal(userResponseStr);
            //SubtractMoney handles the actual math
            SubtractMoney(userResponse);
            //ReadBalance is called to let the user know how much money is left
            ReadBalance();
            //Lastly, interface is called 
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
