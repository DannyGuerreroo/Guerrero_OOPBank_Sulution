﻿using OOPBank;

namespace OOPBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            CheckingAcc checkingAcc = new CheckingAcc();
            SavingsAcc savingsAcc = new SavingsAcc();

            Customer account = new Customer(checkingAcc, savingsAcc);
            Bank bank = new Bank();
            Vault vault = new Vault(bank);

            decimal amount; // Variable used when user defines amount of money to deposit/withdraw

            // Initializing the balances
            account.SetMemberName("Danny");
            checkingAcc.Deposit(2000);
            savingsAcc.Deposit(3000);

            bank.AddMember(checkingAcc); // Testing bank/vault functionality
            bank.AddMember(savingsAcc);

            Console.WriteLine(checkingAcc.MemberName);
            Console.WriteLine(savingsAcc.MemberName);
            vault.CheckVaultBalance(bank.members);




            bool Looper = true;
            while (Looper == true) // A loop so user can keep selecting options
            {
                Console.WriteLine("\nChoose an option from the following: (Type the number)");
                Console.WriteLine("1: Check account balances");
                Console.WriteLine("2: Deposit $ to checking account");
                Console.WriteLine("3: Withdraw $ from checking account (Savings account will be drawn from to cover amounts over checking balance");
                Console.WriteLine("4: Deposit $ to savings account");
                Console.WriteLine("5: Withdraw $ from savings account (The savings account has a $10 minimum requirement)");
                Console.WriteLine("6: Quit Program \n");

                char sInput = Console.ReadKey().KeyChar; // Reading user input
                Console.WriteLine("\n");

                switch (sInput) // Option selected based on user input
                {
                    case '1': // Prints the account's checking and savings balances.
                        account.CheckBalances();
                        break;

                    case '2': // Deposits money to checking account
                        account.DepositToChecking();
                        break;

                    case '3': // Withdraws money from checking account
                        Console.WriteLine("Input the amount you would like to withdraw from checking:\n");
                        string wcinput = Console.ReadLine();
                        amount = account.ParseAmount(wcinput);
                        if (amount > 0)
                        {
                            account.WithdrawFromChecking(amount);
                        }
                        else { Console.WriteLine("Invalid amount entered.\n"); }
                        break;

                    case '4': // Deposits money to savings account
                        account.DepositToSavings();
                        break;

                    case '5': // Withdraws money from savings account
                        Console.WriteLine("Input the amount you would like to withdraw from savings:\n");
                        string wsinput = Console.ReadLine();
                        amount = account.ParseAmount(wsinput);
                        if (amount > 0)
                        {
                            account.WithdrawFromSavings(amount);
                        }
                        else { Console.WriteLine("Invalid amount entered.\n"); }
                        break;

                    case '6': // Stops the loop
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