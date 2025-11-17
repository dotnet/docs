namespace OOProgramming;

/// <summary>
/// Represents a gift card account that extends <see cref="BankAccount"/> with optional recurring monthly deposits.
/// Designed for prepaid gift cards that can optionally receive automatic monthly top-ups.
/// </summary>
/// <remarks>
/// A gift card account is a specialized prepaid account that can be loaded with an initial balance and optionally
/// configured to receive automatic monthly deposits. This account type is ideal for gift cards, allowances, or
/// subscription-based funding scenarios. The account uses the standard minimum balance of $0 from the base
/// <see cref="BankAccount"/> class, preventing overdrafts while allowing the balance to reach zero.
/// Monthly deposits, when configured, provide a convenient way to automatically replenish the account balance.
/// </remarks>
public class GiftCardAccount : BankAccount
{
    private readonly decimal _monthlyDeposit = 0m;

    /// <summary>
    /// Initializes a new instance of the <see cref="GiftCardAccount"/> class with the specified owner name, initial balance, and optional monthly deposit amount.
    /// </summary>
    /// <param name="name">The name of the account owner or gift card recipient.</param>
    /// <param name="initialBalance">The initial amount loaded onto the gift card.</param>
    /// <param name="monthlyDeposit">The optional amount to be automatically deposited each month. Defaults to 0 (no monthly deposits).</param>
    /// <remarks>
    /// This constructor creates a gift card account with an initial balance and an optional recurring monthly deposit.
    /// The monthly deposit parameter allows for automatic top-ups, making this suitable for allowance accounts or
    /// subscription-based gift cards. If monthlyDeposit is 0 or not specified, no automatic deposits will occur.
    /// The account inherits standard banking functionality from <see cref="BankAccount"/> with a minimum balance of $0.
    /// </remarks>
    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
        => _monthlyDeposit = monthlyDeposit;

    /// <inheritdoc/>
    /// <remarks>
    /// For gift card accounts, month-end processing includes applying automatic monthly deposits when configured.
    /// If a monthly deposit amount was specified during account creation and is greater than zero, the amount is
    /// automatically deposited with the note "Add monthly deposit". This feature enables recurring funding scenarios
    /// such as monthly allowances or subscription top-ups. If no monthly deposit was configured (_monthlyDeposit is 0),
    /// no transactions are added during month-end processing.
    /// </remarks>
    public override void PerformMonthEndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
        }
    }
}
