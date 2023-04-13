using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSuperBank
{
    public class BankAccount
    {   
        // properties
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;

                }
                return balance;


            }
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();

        //constructor
        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        // Methods
        public void MakeDeposit(decimal amount, DateTime date, string note)
        { 
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not Sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            // HEADER
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                // ROWS
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }



    }
}
