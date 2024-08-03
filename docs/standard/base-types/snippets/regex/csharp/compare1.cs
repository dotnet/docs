using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

internal static partial class CompareExample
{
    // <Snippet5>
    const string pattern = @"\b(\w+((\r?\n)|,?\s))*\w+[.?:;!]";

    [GeneratedRegex(pattern, RegexOptions.Singleline)]
    private static partial Regex GeneratedRegex();

    public static void RunIt()
    {
        Stopwatch sw;
        Match match;
        int ctr;

        StreamReader inFile = new(@".\Dreiser_TheFinancier.txt");
        string input = inFile.ReadToEnd();
        inFile.Close();

        // Read first ten sentences with interpreted regex.
        Console.WriteLine("10 Sentences with Interpreted Regex:");
        sw = Stopwatch.StartNew();
        Regex int10 = new(pattern, RegexOptions.Singleline);
        match = int10.Match(input);
        for (ctr = 0; ctr <= 9; ctr++)
        {
            if (match.Success)
                // Do nothing with the match except get the next match.
                match = match.NextMatch();
            else
                break;
        }
        sw.Stop();
        Console.WriteLine("   {0} matches in {1}", ctr, sw.Elapsed);

        // Read first ten sentences with compiled regex.
        Console.WriteLine("10 Sentences with Compiled Regex:");
        sw = Stopwatch.StartNew();
        Regex comp10 = new Regex(pattern,
                     RegexOptions.Singleline | RegexOptions.Compiled);
        match = comp10.Match(input);
        for (ctr = 0; ctr <= 9; ctr++)
        {
            if (match.Success)
                // Do nothing with the match except get the next match.
                match = match.NextMatch();
            else
                break;
        }
        sw.Stop();
        Console.WriteLine("   {0} matches in {1}", ctr, sw.Elapsed);

        // Read first ten sentences with source-generated regex.
        Console.WriteLine("10 Sentences with Source-generated Regex:");
        sw = Stopwatch.StartNew();

        match = GeneratedRegex().Match(input);
        for (ctr = 0; ctr <= 9; ctr++)
        {
            if (match.Success)
                // Do nothing with the match except get the next match.
                match = match.NextMatch();
            else
                break;
        }
        sw.Stop();
        Console.WriteLine("   {0} matches in {1}", ctr, sw.Elapsed);

        // Read all sentences with interpreted regex.
        Console.WriteLine("All Sentences with Interpreted Regex:");
        sw = Stopwatch.StartNew();
        Regex intAll = new(pattern, RegexOptions.Singleline);
        match = intAll.Match(input);
        int matches = 0;
        while (match.Success)
        {
            matches++;
            // Do nothing with the match except get the next match.
            match = match.NextMatch();
        }
        sw.Stop();
        Console.WriteLine("   {0:N0} matches in {1}", matches, sw.Elapsed);

        // Read all sentences with compiled regex.
        Console.WriteLine("All Sentences with Compiled Regex:");
        sw = Stopwatch.StartNew();
        Regex compAll = new(pattern,
                        RegexOptions.Singleline | RegexOptions.Compiled);
        match = compAll.Match(input);
        matches = 0;
        while (match.Success)
        {
            matches++;
            // Do nothing with the match except get the next match.
            match = match.NextMatch();
        }
        sw.Stop();
        Console.WriteLine("   {0:N0} matches in {1}", matches, sw.Elapsed);

        // Read all sentences with source-generated regex.
        Console.WriteLine("All Sentences with Source-generated Regex:");
        sw = Stopwatch.StartNew();
        match = GeneratedRegex().Match(input);
        matches = 0;
        while (match.Success)
        {
            matches++;
            // Do nothing with the match except get the next match.
            match = match.NextMatch();
        }
        sw.Stop();
        Console.WriteLine("   {0:N0} matches in {1}", matches, sw.Elapsed);
    }
    /* The example displays the following output:

       10 Sentences with Interpreted Regex:
           10 matches in 00:00:00.0050027
       10 Sentences with Compiled Regex:
           10 matches in 00:00:00.0181372
       10 Sentences with Source-generated Regex:
           10 matches in 00:00:00.0049145
       All Sentences with Interpreted Regex:
           13,682 matches in 00:00:00.1588303
       All Sentences with Compiled Regex:
           13,682 matches in 00:00:00.0859949
       All Sentences with Source-generated Regex:
           13,682 matches in 00:00:00.2794411
    */
    // </Snippet5>
}
