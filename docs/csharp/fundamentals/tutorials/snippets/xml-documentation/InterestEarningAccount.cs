namespace OOProgramming;

/// <summary>
/// Represents an interest-earning bank account that extends <see cref="BankAccount"/> with monthly interest payments.
/// Earns interest on balances above $500 at a rate of 2% annually, applied monthly.
/// </summary>
/// <remarks>
/// An interest-earning account is a specialized savings account that rewards customers for maintaining higher balances.
/// Interest is only earned when the account balance exceeds $500, encouraging customers to maintain substantial deposits.
/// The annual interest rate of 2% is applied monthly to qualifying balances, providing a simple savings incentive.
/// This account type uses the standard minimum balance of $0 from the base <see cref="BankAccount"/> class.
/// </remarks>
public class InterestEarningAccount : BankAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InterestEarningAccount"/> class with the specified owner name and initial balance.
    /// </summary>
    /// <param name="name">The name of the account owner.</param>
    /// <param name="initialBalance">The initial deposit amount for the account.</param>
    /// <remarks>
    /// This constructor calls the base <see cref="BankAccount"/> constructor with a default minimum balance of $0.
    /// Interest earnings will begin in the first month-end processing cycle if the balance exceeds $500.
    /// The account uses the same transaction tracking and balance calculation mechanisms as the base account type.
    /// </remarks>
    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }

    /// <inheritdoc/>
    /// <remarks>
    /// For interest-earning accounts, month-end processing includes calculating and applying interest payments on qualifying balances.
    /// Interest is only earned when the account balance exceeds $500. The interest calculation uses an annual rate of 2% (0.02)
    /// applied to the full balance. The interest payment is deposited as a regular transaction with the note "apply monthly interest".
    /// If the balance is $500 or below, no interest is earned and no transactions are added during month-end processing.
    /// </remarks>
    public override void PerformMonthEndTransactions()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.Now, "apply monthly interest");
        }
    }
}
