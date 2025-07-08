using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

internal static partial class CompareExample
{
    // <Snippet5>
    const string Pattern = @"\b(\w+((\r?\n)|,?\s))*\w+[.?:;!]";

    static readonly HttpClient s_client = new();

    [GeneratedRegex(Pattern, RegexOptions.Singleline)]
    private static partial Regex GeneratedRegex();

    public async static Task RunIt()
    {
        Stopwatch sw;
        Match match;
        int ctr;

        string text =
                await s_client.GetStringAsync("https://www.gutenberg.org/cache/epub/64197/pg64197.txt");

        // Read first ten sentences with interpreted regex.
        Console.WriteLine("10 Sentences with Interpreted Regex:");
        sw = Stopwatch.StartNew();
        Regex int10 = new(Pattern, RegexOptions.Singleline);
        match = int10.Match(text);
        for (ctr = 0; ctr <= 9; ctr++)
        {
            if (match.Success)
                // Do nothing with the match except get the next match.
                match = match.NextMatch();
            else
                break;
        }
        sw.Stop();
        Console.WriteLine($"   {ctr} matches in {sw.Elapsed}");

        // Read first ten sentences with compiled regex.
        Console.WriteLine("10 Sentences with Compiled Regex:");
        sw = Stopwatch.StartNew();
        Regex comp10 = new Regex(Pattern,
                     RegexOptions.Singleline | RegexOptions.Compiled);
        match = comp10.Match(text);
        for (ctr = 0; ctr <= 9; ctr++)
        {
            if (match.Success)
                // Do nothing with the match except get the next match.
                match = match.NextMatch();
            else
                break;
        }
        sw.Stop();
        Console.WriteLine($"   {ctr} matches in {sw.Elapsed}");

        // Read first ten sentences with source-generated regex.
        Console.WriteLine("10 Sentences with Source-generated Regex:");
        sw = Stopwatch.StartNew();

        match = GeneratedRegex().Match(text);
        for (ctr = 0; ctr <= 9; ctr++)
        {
            if (match.Success)
                // Do nothing with the match except get the next match.
                match = match.NextMatch();
            else
                break;
        }
        sw.Stop();
        Console.WriteLine($"   {ctr} matches in {sw.Elapsed}");

        // Read all sentences with interpreted regex.
        Console.WriteLine("All Sentences with Interpreted Regex:");
        sw = Stopwatch.StartNew();
        Regex intAll = new(Pattern, RegexOptions.Singleline);
        match = intAll.Match(text);
        int matches = 0;
        while (match.Success)
        {
            matches++;
            // Do nothing with the match except get the next match.
            match = match.NextMatch();
        }
        sw.Stop();
        Console.WriteLine($"   {matches:N0} matches in {sw.Elapsed}");

        // Read all sentences with compiled regex.
        Console.WriteLine("All Sentences with Compiled Regex:");
        sw = Stopwatch.StartNew();
        Regex compAll = new(Pattern,
                        RegexOptions.Singleline | RegexOptions.Compiled);
        match = compAll.Match(text);
        matches = 0;
        while (match.Success)
        {
            matches++;
            // Do nothing with the match except get the next match.
            match = match.NextMatch();
        }
        sw.Stop();
        Console.WriteLine($"   {matches:N0} matches in {sw.Elapsed}");

        // Read all sentences with source-generated regex.
        Console.WriteLine("All Sentences with Source-generated Regex:");
        sw = Stopwatch.StartNew();
        match = GeneratedRegex().Match(text);
        matches = 0;
        while (match.Success)
        {
            matches++;
            // Do nothing with the match except get the next match.
            match = match.NextMatch();
        }
        sw.Stop();
        Console.WriteLine($"   {matches:N0} matches in {sw.Elapsed}");

        return;
    }
    /* The example displays output similar to the following:

       10 Sentences with Interpreted Regex:
           10 matches in 00:00:00.0104920
       10 Sentences with Compiled Regex:
           10 matches in 00:00:00.0234604
       10 Sentences with Source-generated Regex:
           10 matches in 00:00:00.0060982
       All Sentences with Interpreted Regex:
           3,427 matches in 00:00:00.1745455
       All Sentences with Compiled Regex:
           3,427 matches in 00:00:00.0575488
       All Sentences with Source-generated Regex:
           3,427 matches in 00:00:00.2698670
    */
    // </Snippet5>
}
