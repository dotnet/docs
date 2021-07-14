using System;
using System.Text.RegularExpressions;

public class Class1
{
    // <main>
    public static void Main()
    {
        string inputString = "My favorite web sites include:</P>" +
                             "<A HREF=\"https://docs.microsoft.com/en-us/dotnet/\">" +
                             ".NET Documentation</A></P>" +
                             "<A HREF=\"http://www.microsoft.com\">" +
                             "Microsoft Corporation Home Page</A></P>" +
                             "<A HREF=\"https://devblogs.microsoft.com/dotnet/\">" +
                             ".NET Blog</A></P>";
        DumpHRefs(inputString);
    }
    // The example displays the following output:
    //       Found href https://docs.microsoft.com/dotnet/ at 43
    //       Found href http://www.microsoft.com at 114
    //       Found href https://devblogs.microsoft.com/dotnet/ at 188
    // </main>

    // <regex>
    private static void DumpHRefs(string inputString)
    {
        string hrefPattern = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";

        try
        {
            Match regexMatch = Regex.Match(inputString, hrefPattern,
                                           RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                           TimeSpan.FromSeconds(1));
            while (regexMatch.Success)
            {
                Console.WriteLine($"Found href {regexMatch.Groups[1]} at {regexMatch.Groups[1].Index}");
                regexMatch = regexMatch.NextMatch();
            }
        }
        catch (RegexMatchTimeoutException)
        {
            Console.WriteLine("The matching operation timed out.");
        }
    }
    // </regex>
}
