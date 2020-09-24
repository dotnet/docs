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

        public override void PerformMonthEndTransactions(decimal? optionalDeposit)
        {
            base.PerformMonthEndTransactions(optionalDeposit);
        }
    }
}
