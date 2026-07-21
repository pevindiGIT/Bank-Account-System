using BankAccountSystem.Models;
using BankAccountSystem.Services;

BankService bank = new BankService();

while (true)
{
    Console.WriteLine("\n====== BANK SYSTEM ======");

    Console.WriteLine("1. Create Account");
    Console.WriteLine("2. Deposit");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. Check Balance");
    Console.WriteLine("5. Display Accounts");
    Console.WriteLine("6. Exit");

    Console.Write("Choose : ");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:

            CreateAccount(bank);

            break;

        case 2:

            Deposit(bank);

            break;

        case 3:

            Withdraw(bank);

            break;

        case 4:

            CheckBalance(bank);

            break;

        case 5:

            DisplayAccounts(bank);

            break;

        case 6:

            return;

        default:

            Console.WriteLine("Invalid Option");

            break;
    }
}

static void CreateAccount(BankService bank)
{
    Console.Write("Account Number : ");

    int number = Convert.ToInt32(Console.ReadLine());

    Console.Write("Holder Name : ");

    string name = Console.ReadLine();

    BankAccount account = new BankAccount(number, name);

    bank.AddAccount(account);

    Console.WriteLine("Account Created Successfully");
}

static void Deposit(BankService bank)
{
    try
    {
        Console.Write("Account Number : ");

        int number = Convert.ToInt32(Console.ReadLine());

        var account = bank.FindAccount(number);

        if (account == null)
        {
            Console.WriteLine("Account not found");
            return;
        }

        Console.Write("Amount : ");

        decimal amount = Convert.ToDecimal(Console.ReadLine());

        account.Deposit(amount);

        Console.WriteLine("Deposit Successful");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void Withdraw(BankService bank)
{
    try
    {
        Console.Write("Account Number : ");

        int number = Convert.ToInt32(Console.ReadLine());

        var account = bank.FindAccount(number);

        if (account == null)
        {
            Console.WriteLine("Account not found");
            return;
        }

        Console.Write("Amount : ");

        decimal amount = Convert.ToDecimal(Console.ReadLine());

        account.Withdraw(amount);

        Console.WriteLine("Withdrawal Successful");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void CheckBalance(BankService bank)
{
    Console.Write("Account Number : ");

    int number = Convert.ToInt32(Console.ReadLine());

    var account = bank.FindAccount(number);

    if (account == null)
    {
        Console.WriteLine("Account not found");
        return;
    }

    Console.WriteLine($"Current Balance : {account.GetBalance()}");
}

static void DisplayAccounts(BankService bank)
{
    foreach (var account in bank.Accounts)
    {
        Console.WriteLine("--------------------------------");

        Console.WriteLine($"Account : {account.AccountNumber}");

        Console.WriteLine($"Name : {account.HolderName}");

        Console.WriteLine($"Balance : {account.GetBalance()}");
    }
}