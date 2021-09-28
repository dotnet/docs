using System;
using System.Collections.Generic;
using System.Text;

namespace OOProgramming
{
    class LineOfCreditAccount : BankAccount
    {
        // <ConstructLineOfCredit>
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }
        // </ConstructLineOfCredit>

        // <ApplyMonthendInterest>
        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }
        // </ApplyMonthendInterest>

        // <AddOverdraftFee>
        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
            isOverdrawn
            ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
            : default;
        // </AddOverdraftFee>
    }
}
