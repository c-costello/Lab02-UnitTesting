using System;

namespace AtmApp
{
    class Program
    {
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

                case 2:

                case 3:

                case 4:

                default:
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
    }
}
