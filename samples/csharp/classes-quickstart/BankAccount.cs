using System;
using System.Collections.Generic;

namespace classes
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
#region BalanceComputation
        public decimal Balance 
        {
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                    balance += item.Amount;
                return balance;
            }
        }
#endregion

        private static int accountNumberSeed = 1234567890;
#region Constructor
        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            
            this.Owner = name;
            MakeDeposit(initialDeposit, DateTime.Now, "Initial balance");
        }
#endregion

#region TransactionDeclaration
        private List<Transaction> allTransactions = new List<Transaction>();
#endregion

#region DepositAndWithdrawal
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
#endregion

#region History
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");

            return report.ToString();
        }
#endregion
    }
}
