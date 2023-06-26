using System.Linq;

namespace PropertyValidation;

// <BaseClassValidation>
public class BankAccount(string accountID, string owner)
{
    public string AccountID { get; } = ValidAccountNumber(accountID) 
        ? accountID 
        : throw new ArgumentException("Invalid account number", nameof(accountID));

    public string Owner { get; } = string.IsNullOrWhiteSpace(owner) 
        ? throw new ArgumentException("Owner name cannot be empty", nameof(owner)) 
        : owner;

    public override string ToString() => $"Account ID: {AccountID}, Owner: {Owner}";

    public static bool ValidAccountNumber(string accountID) => 
    accountID?.Length == 10 && accountID.All(c => char.IsDigit(c));
}
// </BaseClassValidation>
