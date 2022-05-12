namespace Patterns;

public static class ListPattern
{
    static string[] records =
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


    public static void Examples()
    {
        // <DeclareArrays>
        int[] one = { 1 };
        int[] odd = { 1, 3, 5 };
        int[] even = { 2, 4, 6 };
        int[] fib = { 1, 1, 2, 3, 5 };
        // </DeclareArrays>

        Console.WriteLine("Match entire array");
        // <MatchEntireArray>
        Console.WriteLine(odd is [1, 3, 5]); // true
        Console.WriteLine(even is [1, 3, 5]); // false (values)
        Console.WriteLine(one is [1, 3, 5]); // false (length)
        // </MatchEntireArray>

        Console.WriteLine("Match elements");
        // <MatchElements>
        Console.WriteLine(odd is [1, _, _]); // true
        Console.WriteLine(odd is [_, 3, _]); // true
        Console.WriteLine(even is [_, _, 5]); // false (last value)
        // </MatchElements>

        Console.WriteLine("Match range");
        // <MatchRange>
        Console.WriteLine(odd is [1, .., 3, _]); // true
        Console.WriteLine(fib is [1, .., 3, _]); // true

        Console.WriteLine(odd is [1, _, 5, ..]); // true
        Console.WriteLine(fib is [1, _, 5, ..]); // false
        // </MatchRange>

        Console.WriteLine("Relational pattern");
        // <RelationalMatch>
        Console.WriteLine(odd is [_, >1, ..]); // true
        Console.WriteLine(even is [_, >1, ..]); // true
        Console.WriteLine(fib is [_, > 1, ..]); // false
        // </RelationalMatch>

        // <DataRecordExample>
        decimal balance = 0m;
        foreach (var record in ReadRecords())
        {
            balance += record switch
            {
                [_, "DEPOSIT", _, var amount]     => decimal.Parse(amount),
                [_, "WITHDRAWAL", .., var amount] => -decimal.Parse(amount),
                [_, "INTEREST", var amount]       => decimal.Parse(amount),
                [_, "FEE", var fee]               => decimal.Parse(fee),
                _                                 => throw new InvalidOperationException($"Record {record} is not in the expected format!"),
            };
            Console.WriteLine($"Record: {record}, New balance: {balance:C}");
        }
        // </DataRecordExample>

        IEnumerable<string[]> ReadRecords()
        {
            foreach (var record in records)
                yield return record.Split(',', StringSplitOptions.TrimEntries); ;
        }
    }
}
