namespace BankAccountSystem.Models
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }

        public class HolderName { get; set; }

        private decimal balance;

        public BankAccount(int accountNumber, string holdName)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            balance = 0;

        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Deposit amount must be greater than zero.");

            balance += amount; 
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Withdrawal amount must be greater than zero.");

            if (amount > balance)
                throw new Exception("Insufficient funds.");

            balance -= amount;
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
}