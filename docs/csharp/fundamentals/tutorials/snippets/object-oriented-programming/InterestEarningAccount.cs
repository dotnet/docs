using System;
using System.Collections.Generic;
using System.Text;

namespace OOProgramming
{
    public class InterestEarningAccount : BankAccount
    {
        // <DerivedConstructor>
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance) 
        { 
        }
        // </DerivedConstructor>

        // <ApplyMonthendInterest>
        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
        // </ApplyMonthendInterest>
    }
}
