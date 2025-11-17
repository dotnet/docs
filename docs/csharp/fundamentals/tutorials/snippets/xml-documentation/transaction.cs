namespace OOProgramming;

/// <summary>
/// Represents an immutable financial transaction with an amount, date, and descriptive notes.
/// </summary>
/// <param name="Amount">The transaction amount. Positive values represent credits/deposits, negative values represent debits/withdrawals.</param>
/// <param name="Date">The date and time when the transaction occurred.</param>
/// <param name="Notes">Descriptive notes or memo text associated with the transaction.</param>
public record Transaction(decimal Amount, DateTime Date, string Notes);
