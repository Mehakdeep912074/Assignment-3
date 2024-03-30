using System;

public enum AccountType
{
    Checking,
    Savings
}

public class BankAccount
{
    // Properties
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }
    public AccountType Type { get; private set; }

    // Constructor for Checking Account
    public BankAccount(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        Type = AccountType.Checking;
    }

    // Constructor for Savings Account
    public BankAccount(string accountNumber, decimal initialBalance, AccountType type)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        Type = type;
    }

    // Deposit method
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"{amount:C} deposited into account {AccountNumber}. New balance: {Balance:C}");
    }

    // Withdraw method
    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds!");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"{amount:C} withdrawn from account {AccountNumber}. New balance: {Balance:C}");
        }
    }

    // Method overloading for Deposit
    public void Deposit(decimal amount, string description)
    {
        Deposit(amount); // Reuse the existing Deposit method
        Console.WriteLine($"Description: {description}");
    }

    // Method overloading for Withdraw
    public void Withdraw(decimal amount, string description)
    {
        Withdraw(amount); // Reuse the existing Withdraw method
        Console.WriteLine($"Description: {description}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating Checking Account
        BankAccount checkingAccount = new BankAccount("9417939", 3000.00m);
        Console.WriteLine($"Checking Account Number: {checkingAccount.AccountNumber}, Balance: {checkingAccount.Balance:C}");

        // Deposit into Checking Account
        checkingAccount.Deposit(500.00m);

        // Withdraw from Checking Account
        checkingAccount.Withdraw(900.00m);

        // Creating Savings Account
        BankAccount savingsAccount = new BankAccount("9567894", 8000.00m, AccountType.Savings);
        Console.WriteLine($"Savings Account Number: {savingsAccount.AccountNumber}, Balance: {savingsAccount.Balance:C}");

        // Deposit into Savings Account with description
        savingsAccount.Deposit(1000.00m, "Salary credited");

        // Withdraw from Savings Account with description
        savingsAccount.Withdraw(500.00m, "Monthly expenses");

        Console.ReadLine();
    }
}
