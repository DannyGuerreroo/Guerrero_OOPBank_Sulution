namespace BankMockIT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer account = new Customer();

            decimal amount; // Variable used when user defines amount of money to deposit/withdraw

            // Initializng the balances
            account.DepositToChecking(2000);
            account.DepositToSavings(3000);

            bool Looper = true;
            while (Looper == true) // A loop so user can keep selecting options
            {
                Console.WriteLine("\nChoose an option from the following: (Type the number)");
                Console.WriteLine("1: Check account balances");
                Console.WriteLine("2: Deposit $ to checking account");
                Console.WriteLine("3: Withdraw $ from checking account");
                Console.WriteLine("4: Deposit $ to savings account");
                Console.WriteLine("5: Withdraw $ from savings account");
                Console.WriteLine("6: Quit Program \n");

                char sInput = Console.ReadKey().KeyChar; // Reading user input
                Console.WriteLine("\n");

                switch (sInput) // Option selected based on user input
                {
                    case '1': // Prints the account's checking and savings balances.
                        account.CheckBalances();
                        break;

                    case '2': // Deposits money to checking account
                        Console.WriteLine("Input the amount you would like to deposit to checking:\n");
                        string dcinput = Console.ReadLine();

                        if (decimal.TryParse(dcinput, out amount))
                        {
                            account.DepositToChecking(amount);
                            Console.WriteLine("$" + amount + " was deposited into checking.\n"); 
                        }
                        else { Console.WriteLine("Invalid amount entered.\n"); }
                        break;

                    case '3': // Withdraws money from checking account
                        Console.WriteLine("Input the amount you would like to withdraw from checking:\n");
                        string wcinput = Console.ReadLine();

                        if (decimal.TryParse(wcinput, out amount))
                        {
                            account.WithdrawFromChecking(amount);
                            Console.WriteLine("$" + amount + " was withdrawn from checking.\n");
                        }
                        else { Console.WriteLine("Invalid amount entered.\n"); }
                        break;

                    case '4': // Deposits money to checking account
                        Console.WriteLine("Input the amount you would like to deposit to checking:\n");
                        string dsinput = Console.ReadLine();

                        if (decimal.TryParse(dsinput, out amount))
                        {
                            account.DepositToSavings(amount);
                            Console.WriteLine("$" + amount + " was deposited into savings.\n");
                        }
                        else { Console.WriteLine("Invalid amount entered.\n"); }
                        break;

                    case '5': // Withdraws money from checking account
                        Console.WriteLine("Input the amount you would like to withdraw from savings:\n");
                        string wsinput = Console.ReadLine();

                        if (decimal.TryParse(wsinput, out amount))
                        {
                            account.WithdrawFromSavings(amount);
                        }
                        else { Console.WriteLine("Invalid amount entered.\n"); }
                        break;

                    case '6': // Stops the loop bool
                        Console.WriteLine("Thanks for using the OOPBank, Goodbye.");
                        Looper = false;
                        break;
                    default: // In case user inputs incorrect value, tells them to retry
                        Console.WriteLine("Incorrect Value Error: Please try again.\n");
                        break;
                }
            }
        }
    }
}