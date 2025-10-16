namespace OOProgramming;

/// <summary>
/// Represents a bank account with basic banking operations including deposits, withdrawals, and transaction history.
/// Supports minimum balance constraints and provides extensible month-end processing capabilities.
/// </summary>
public class BankAccount
{
    /// <summary>
    /// Gets the unique account number for this bank account.
    /// </summary>
    /// <value>A string representation of the account number, generated sequentially.</value>
    public string Number { get; }
    
    /// <summary>
    /// Gets or sets the name of the account owner.
    /// </summary>
    /// <value>The full name of the person who owns this account.</value>
    public string Owner { get; set; }
    
    /// <summary>
    /// Gets the current balance of the account by calculating the sum of all transactions.
    /// </summary>
    /// <value>The current account balance as a decimal value.</value>
    public decimal Balance => _allTransactions.Sum(i => i.Amount);

    private static int s_accountNumberSeed = 1234567890;

    private readonly decimal _minimumBalance;

    /// <summary>
    /// Initializes a new instance of the BankAccount class with the specified owner name and initial balance.
    /// Uses a default minimum balance of 0.
    /// </summary>
    /// <param name="name">The name of the account owner.</param>
    /// <param name="initialBalance">The initial deposit amount for the account.</param>
    /// <remarks>
    /// This constructor is a convenience overload that calls the main constructor with a minimum balance of 0.
    /// If the initial balance is greater than 0, it will be recorded as the first transaction with the note "Initial balance".
    /// The account number is automatically generated using a static seed value that increments for each new account.
    /// </remarks>
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

    /// <summary>
    /// Initializes a new instance of the BankAccount class with the specified owner name, initial balance, and minimum balance constraint.
    /// </summary>
    /// <param name="name">The name of the account owner.</param>
    /// <param name="initialBalance">The initial deposit amount for the account.</param>
    /// <param name="minimumBalance">The minimum balance that must be maintained in the account.</param>
    /// <remarks>
    /// This is the primary constructor that sets up all account properties. The account number is generated automatically
    /// using a static seed value. If an initial balance is provided and is greater than 0, it will be added as the first
    /// transaction. The minimum balance constraint will be enforced on all future withdrawal operations through the
    /// <see cref="CheckWithdrawalLimit"/> method.
    /// </remarks>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        Owner = name;
        _minimumBalance = minimumBalance;
        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    private readonly List<Transaction> _allTransactions = [];

    /// <summary>
    /// Makes a deposit to the account by adding a positive transaction.
    /// </summary>
    /// <param name="amount">The amount to deposit. Must be positive.</param>
    /// <param name="date">The date when the deposit is made.</param>
    /// <param name="note">A descriptive note about the deposit transaction.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the deposit amount is zero or negative.</exception>
    /// <remarks>
    /// This method creates a new <see cref="Transaction"/> object with the specified amount, date, and note,
    /// then adds it to the internal transaction list. The transaction amount must be positive - negative amounts
    /// are not allowed for deposits. The account balance is automatically updated through the Balance property
    /// which calculates the sum of all transactions. There are no limits or restrictions on deposit amounts.
    /// </remarks>
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    /// <summary>
    /// Makes a withdrawal from the account by adding a negative transaction.
    /// Checks withdrawal limits and minimum balance constraints before processing.
    /// </summary>
    /// <param name="amount">The amount to withdraw. Must be positive.</param>
    /// <param name="date">The date when the withdrawal is made.</param>
    /// <param name="note">A descriptive note about the withdrawal transaction.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the withdrawal amount is zero or negative.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the withdrawal would cause the balance to fall below the minimum balance.</exception>
    /// <remarks>
    /// This method first validates that the withdrawal amount is positive, then checks if the withdrawal would
    /// violate the minimum balance constraint by calling <see cref="CheckWithdrawalLimit"/>. The withdrawal is
    /// recorded as a negative transaction amount. If the withdrawal limit check returns an overdraft transaction
    /// (such as a fee), that transaction is also added to the account. The method enforces business rules through
    /// the virtual CheckWithdrawalLimit method, allowing derived classes to implement different withdrawal policies.
    /// </remarks>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);
        _allTransactions.Add(withdrawal);
        if (overdraftTransaction != null)
            _allTransactions.Add(overdraftTransaction);
    }

    /// <summary>
    /// Checks whether a withdrawal would violate the account's minimum balance constraint.
    /// This method can be overridden in derived classes to implement different withdrawal limit policies.
    /// </summary>
    /// <param name="isOverdrawn">True if the withdrawal would cause the balance to fall below the minimum balance.</param>
    /// <returns>A Transaction object representing any overdraft fees or penalties, or null if no additional charges apply.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the withdrawal would cause an overdraft and the account type doesn't allow it.</exception>
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        else
        {
            return default;
        }
    }

    /// <summary>
    /// Generates a detailed account history report showing all transactions with running balance calculations.
    /// </summary>
    /// <returns>A formatted string containing the complete transaction history with dates, amounts, running balances, and notes.</returns>
    /// <remarks>
    /// This method creates a formatted report that includes a header row followed by all transactions in chronological order.
    /// Each row shows the transaction date (in short date format), the transaction amount, the running balance after that
    /// transaction, and any notes associated with the transaction. The running balance is calculated by iterating through
    /// all transactions and maintaining a cumulative total. The report uses tab characters for column separation and
    /// is suitable for display in console applications or simple text outputs.
    /// </remarks>
    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }

    // Added for OO tutorial:

    /// <summary>
    /// Performs month-end processing for the account. This virtual method can be overridden in derived classes
    /// to implement specific month-end behaviors such as interest calculations, fee assessments, or statement generation.
    /// </summary>
    /// <remarks>
    /// The base implementation of this method does nothing, providing a safe default for basic bank accounts.
    /// Derived classes such as savings accounts or checking accounts can override this method to implement
    /// account-specific month-end processing. Examples include calculating and applying interest payments,
    /// assessing monthly maintenance fees, generating account statements, or performing regulatory compliance checks.
    /// This method is typically called by banking systems at the end of each month as part of batch processing operations.
    /// </remarks>
    public virtual void PerformMonthEndTransactions() { }
}
