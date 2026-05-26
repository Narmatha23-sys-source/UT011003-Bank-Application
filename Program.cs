using System;
using System.Collections.Generic;

namespace Banking_Application
{
    class BankAccount
    {
        public string AccountHolder { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public List<string> Transactions { get; private set; }

        // Constructor
        public BankAccount(string accountHolder, string accountNumber, decimal initialBalance)
        {
            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
            Balance = initialBalance;

            Transactions = new List<string>();

            Transactions.Add(
                $"Account created with Rs.{initialBalance:F2} on {DateTime.Now:dd/MM/yyyy HH:mm}");
        }

        // Deposit Method
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;

                Transactions.Add(
                    $"Deposited Rs.{amount:F2} on {DateTime.Now:dd/MM/yyyy HH:mm}");

                Console.WriteLine("Deposit successful");
            }
            else
            {
                Console.WriteLine("Deposit amount must be greater than 0");
            }
        }

        // Withdraw Method
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than 0");
                return false;
            }

            if (amount <= Balance)
            {
                Balance -= amount;

                Transactions.Add(
                    $"Withdrawn Rs.{amount:F2} on {DateTime.Now:dd/MM/yyyy HH:mm}");

                Console.WriteLine("Withdrawal successful");
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient balance");
                return false;
            }
        }

        // Display Account Details
        public void DisplayDetails()
        {
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine("Account Holder : " + AccountHolder);
            Console.WriteLine("Account Number : " + AccountNumber);
            Console.WriteLine("Balance        : Rs." + Balance.ToString("F2"));
        }

        // Show Transactions
        public void ShowTransactions()
        {
            Console.WriteLine("\n--- Transaction History ---");

            if (Transactions.Count == 0)
            {
                Console.WriteLine("No transactions yet");
            }
            else
            {
                foreach (string transaction in Transactions)
                {
                    Console.WriteLine(transaction);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShowWelcome();

            Console.Write("Enter Account Holder Name : ");
            string name = Console.ReadLine();

            Console.WriteLine("Welcome" +".."+ name);

            Console.Write("Enter Account Number : ");
            string accNo = Console.ReadLine();

            decimal bal = ReadDecimal("Enter Opening Balance : ");

            BankAccount account = new BankAccount(name, accNo, bal);

            bool running = true;

            while (running)
            {
                Console.Clear();

                ShowMenu();

                int choice = ReadInt("Choose an option : ");

                running = HandleChoice(choice, account);

                if (running)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        // Welcome Screen
        static void ShowWelcome()
        {
            Console.WriteLine("================================");
            Console.WriteLine("      Bank of Commercial");
            Console.WriteLine("================================");
            Console.WriteLine("   Welcome to Our Bank System");
            Console.WriteLine("================================");
        }

        // Menu
        static void ShowMenu()
        {
            Console.WriteLine("\n========== MENU ==========");
            Console.WriteLine("1. View Account Details");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Transaction History");
            Console.WriteLine("6. Exit");
            Console.WriteLine("==========================");
        }

        // Handle Menu Choice
        static bool HandleChoice(int choice, BankAccount account)
        {
            switch (choice)
            {
                case 1:

                    account.DisplayDetails();
                    break;

                    if (choice == 1)
                    {
                        Console.WriteLine("showing account details");
                    }

                case 2:
                    Console.WriteLine(
                        $"Current Balance : Rs.{account.Balance:F2}");
                    break;

                case 3:
                    decimal dep = ReadDecimal("Enter Deposit Amount : ");
                    account.Deposit(dep);

                    Console.WriteLine(
                        $"New Balance : Rs.{account.Balance:F2}");
                    break;

                case 4:
                    decimal withdrawal =
                        ReadDecimal("Enter Withdrawal Amount : ");

                    if (account.Withdraw(withdrawal))
                    {
                        Console.WriteLine(
                            $"Remaining Balance : Rs.{account.Balance:F2}");
                    }
                    break;

                case 5:
                    account.ShowTransactions();
                    break;

                case 6:
                    Console.WriteLine("\nThank you for using our bank.");
                    return false;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            return true;
        }

        // Read Integer Input
        static int ReadInt(string prompt)
        {
            Console.Write(prompt);

            int value;

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Enter a number : ");
            }

            return value;
        }

        // Read Decimal Input
        static decimal ReadDecimal(string prompt)
        {
            Console.Write(prompt);

            decimal value;

            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Enter a valid amount : ");
            }

            return value;
        }
    }
}