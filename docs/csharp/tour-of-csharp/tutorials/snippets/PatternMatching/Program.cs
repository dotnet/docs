// <InputData>
string bankRecords = """
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
// </InputData>

await IsTextValueExample(bankRecords);
Console.WriteLine();
await IsEnumValueExample(bankRecords);
Console.WriteLine();
await SwitchEnumValueExample(bankRecords);
Console.WriteLine();
await ExampleProgram.Main();
Console.WriteLine();

static async Task IsTextValueExample(string inputText1)
{
    // <IsOnTextValue>
    double currentBalance = 0.0;
    var reader = new StringReader(inputText1);

    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        if (string.IsNullOrWhiteSpace(line)) continue;
        // Split the line based on comma delimiter and trim each part
        string[] parts = line.Split(',');

        string? transactionType = parts[0]?.Trim();
        if (double.TryParse(parts[1].Trim(), out double amount))
        {
            // Update the balance based on transaction type
            if (transactionType?.ToUpper() is "DEPOSIT")
                currentBalance += amount;
            else if (transactionType?.ToUpper() is "WITHDRAWAL")
                currentBalance -= amount;

            Console.WriteLine($"{line.Trim()} => Parsed Amount: {amount}, New Balance: {currentBalance}");
        }
    }
    // </IsOnTextValue>
}

static async Task IsEnumValueExample(string inputText1)
{
    // <IsEnumValue>
    double currentBalance = 0.0;

    await foreach(var transaction in TransactionRecords(inputText1))
    {
        if (transaction.type == TransactionType.Deposit)
            currentBalance += transaction.amount;
        else if (transaction.type == TransactionType.Withdrawal)
            currentBalance -= transaction.amount;
        Console.WriteLine($"{transaction.type} => Parsed Amount: {transaction.amount}, New Balance: {currentBalance}");
    }

    static async IAsyncEnumerable<(TransactionType type, double amount)> TransactionRecords(string inputText)
    {
        var reader = new StringReader(inputText);
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
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
            yield return (default, 0.0);
        }
    }
    // </IsEnumValue>
}

static async Task SwitchEnumValueExample(string inputText1)
{
    // <SwitchEnumValue>
    double currentBalance = 0.0;

    await foreach (var transaction in TransactionRecords(inputText1))
    {
        currentBalance += transaction switch
        {   (TransactionType.Deposit, var amount) => amount,
            (TransactionType.Withdrawal, var amount) => -amount,
            _ => 0.0
        };
        Console.WriteLine($"{transaction.type} => Parsed Amount: {transaction.amount}, New Balance: {currentBalance}");
    }

    static async IAsyncEnumerable<(TransactionType type, double amount)> TransactionRecords(string inputText)
    {
        var reader = new StringReader(inputText);
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
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
            yield return (default, 0.0);
        }
    }
    // </SwitchEnumValue>
}

// <FinalProgram>
public static class ExampleProgram
{
    static string bankRecords = """
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

    public static async Task Main()
    {
        double currentBalance = 0.0;

        await foreach (var transaction in TransactionRecordType(bankRecords))
        {
            currentBalance += transaction switch
            {
                Deposit d => d.Amount,
                Withdrawal w => -w.Amount,
                _ => 0.0
            };
            Console.WriteLine($" {transaction} => New Balance: {currentBalance}");
        }
    }

    public static async IAsyncEnumerable<object?> TransactionRecordType(string inputText)
    {
        var reader = new StringReader(inputText);
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            string[] parts = line.Split(',');

            string? transactionType = parts[0]?.Trim();
            if (double.TryParse(parts[1].Trim(), out double amount))
            {
                // Update the balance based on transaction type
                if (transactionType?.ToUpper() is "DEPOSIT")
                    yield return new Deposit(amount, parts[2]);
                else if (transactionType?.ToUpper() is "WITHDRAWAL")
                    yield return new Withdrawal(amount, parts[2]);
            }
            yield return default;
        }
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal
}


public record Deposit(double Amount, string description);
public record Withdrawal(double Amount, string description);

// </FinalProgram>
