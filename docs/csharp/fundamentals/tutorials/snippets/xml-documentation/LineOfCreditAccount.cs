namespace OOProgramming;

/// <summary>
/// Represents a line of credit account that extends <see cref="BankAccount"/> with credit limit functionality.
/// Allows negative balances up to a specified credit limit and applies monthly interest charges on outstanding balances.
/// </summary>
/// <remarks>
/// A line of credit account differs from a regular bank account in that it allows the balance to go negative
/// up to a predefined credit limit. When the balance is negative (indicating borrowed money), the account
/// accrues monthly interest charges at a rate of 7% annually. Overdraft fees of $20 are applied when
/// withdrawals exceed the available credit limit.
/// </remarks>
class LineOfCreditAccount : BankAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LineOfCreditAccount"/> class with the specified owner name, initial balance, and credit limit.
    /// </summary>
    /// <param name="name">The name of the account owner.</param>
    /// <param name="initialBalance">The initial deposit amount for the account.</param>
    /// <param name="creditLimit">The maximum credit limit available for borrowing. This value should be positive and represents the maximum negative balance allowed.</param>
    /// <remarks>
    /// The constructor converts the credit limit to a negative minimum balance by passing -creditLimit to the base constructor.
    /// This allows the account to have a negative balance up to the specified credit limit. For example, a credit limit of $1000
    /// means the account can have a balance as low as -$1000.
    /// </remarks>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
    {
    }

    /// <inheritdoc/>
    /// <remarks>
    /// For line of credit accounts, month-end processing includes calculating and applying interest charges on negative balances.
    /// Interest is calculated at an annual rate of 7% (0.07) applied monthly to the outstanding balance. The interest charge
    /// is applied as a withdrawal transaction with the note "Charge monthly interest". If the balance is positive or zero,
    /// no interest charges are applied.
    /// </remarks>
    public override void PerformMonthEndTransactions()
    {
        if (Balance < 0)
        {
            // Negate the balance to get a positive interest charge:
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
        }
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Line of credit accounts handle overdrafts by applying a fixed $20 overdraft fee when withdrawals exceed the available
    /// credit limit. Unlike the base implementation which throws an exception, this method returns a fee transaction that
    /// gets added to the account. This allows the withdrawal to proceed while documenting the penalty for exceeding the limit.
    /// </remarks>
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
        isOverdrawn
        ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
        : default;
}
