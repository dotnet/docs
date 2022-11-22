namespace patterns;

static class ListPattern
{
    static string[] s_records =
    {
        "04-01-2020, DEPOSIT, Initial deposit, 2250.00",
        "04-15-2020, DEPOSIT, Refund, 125.65",
        "04-18-2020, DEPOSIT, Paycheck, 125.65",
        "04-22-2020, WITHDRAWAL, Debit, Groceries, 255.73",
        "05-01-2020, WITHDRAWAL, #1102, Rent, apt, 2100.00",
        "05-02-2020, INTEREST,  0.65",
        "05-07-2020, WITHDRAWAL, Debit, Movies, 12.57",
        "04-15-2020, FEE, 5.55",
    };

    
    public static void Example()
    {
        // <ListPattern>
        decimal balance = 0m;
        foreach (string[] transaction in ReadRecords())
        {
            balance += transaction switch
            {
                [_, "DEPOSIT", _, var amount]     => decimal.Parse(amount),
                [_, "WITHDRAWAL", .., var amount] => -decimal.Parse(amount),
                [_, "INTEREST", var amount]       => decimal.Parse(amount),
                [_, "FEE", var fee]               => -decimal.Parse(fee),
                _                                 => throw new InvalidOperationException($"Record {string.Join(", ", transaction)} is not in the expected format!"),
            };
            Console.WriteLine($"Record: {string.Join(", ", transaction)}, New balance: {balance:C}");
        }
        // </ListPattern>

        IEnumerable<string[]> ReadRecords()
        {
            foreach (var record in s_records)
                yield return record.Split(',', StringSplitOptions.TrimEntries);
        }
    }
}
