namespace FirstEnumExample;

// <IsEnumValue>
public static class ExampleProgram
{
    const string bankRecords = """
    DEPOSIT,   10000, Initial balance
    DEPOSIT,     500, regular deposit
    WITHDRAWAL, 1000, rent
    DEPOSIT,    2000, freelance payment
    WITHDRAWAL,  300, groceries
    DEPOSIT,     700, gift from friend
    WITHDRAWAL,  150, utility bill
    DEPOSIT,    1200, tax refund
    WITHDRAWAL,  500, car maintenance
    DEPOSIT,     400, cashback reward
    WITHDRAWAL,  250, dining out
    DEPOSIT,    3000, bonus payment
    WITHDRAWAL,  800, loan repayment
    DEPOSIT,     600, stock dividends
    WITHDRAWAL,  100, subscription fee
    DEPOSIT,    1500, side hustle income
    WITHDRAWAL,  200, fuel expenses
    DEPOSIT,     900, refund from store
    WITHDRAWAL,  350, shopping
    DEPOSIT,    2500, project milestone payment
    WITHDRAWAL,  400, entertainment
    """;

    public static void Main()
    {
        double currentBalance = 0.0;

        foreach (var transaction in TransactionRecords(bankRecords))
        {
            if (transaction.type == TransactionType.Deposit)
                currentBalance += transaction.amount;
            else if (transaction.type == TransactionType.Withdrawal)
                currentBalance -= transaction.amount;
            Console.WriteLine($"{transaction.type} => Parsed Amount: {transaction.amount}, New Balance: {currentBalance}");
        }
    }

    static IEnumerable<(TransactionType type, double amount)> TransactionRecords(string inputText)
    {
        var reader = new StringReader(inputText);
        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            string[] parts = line.Split(',');

            string? transactionType = parts[0]?.Trim();
            if (double.TryParse(parts[1].Trim(), out double amount))
            {
                // Update the balance based on transaction type
                if (transactionType?.ToUpper() is "DEPOSIT")
                    yield return (TransactionType.Deposit, amount);
                else if (transactionType?.ToUpper() is "WITHDRAWAL")
                    yield return (TransactionType.Withdrawal, amount);
            }
            else {
            yield return (TransactionType.Invalid, 0.0);
            }
        }
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal,
    Invalid
}
// </IsEnumValue>
