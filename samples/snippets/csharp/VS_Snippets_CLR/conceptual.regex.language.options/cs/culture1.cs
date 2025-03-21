using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

public class CultureExample
{
    public static void Main()
    {
        ShowIllegalAccess();
        Console.WriteLine("-----");
        ShowNoAccess();
    }

    private static void ShowIllegalAccess()
    {
        // <Snippet14>
        CultureInfo defaultCulture = Thread.CurrentThread.CurrentCulture;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

        string input = "file://c:/Documents.MyReport.doc";
        string pattern = "FILE://";

        Console.WriteLine("Culture-sensitive matching ({0} culture)...",
                          Thread.CurrentThread.CurrentCulture.Name);
        if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
            Console.WriteLine("URLs that access files are not allowed.");
        else
            Console.WriteLine($"Access to {input} is allowed.");

        Thread.CurrentThread.CurrentCulture = defaultCulture;
        // The example displays the following output:
        //       Culture-sensitive matching (tr-TR culture)...
        //       Access to file://c:/Documents.MyReport.doc is allowed.
        // </Snippet14>
    }

    private static void ShowNoAccess()
    {
        // <Snippet15>
        CultureInfo defaultCulture = Thread.CurrentThread.CurrentCulture;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

        string input = "file://c:/Documents.MyReport.doc";
        string pattern = "FILE://";

        Console.WriteLine("Culture-insensitive matching...");
        if (Regex.IsMatch(input, pattern,
                          RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
            Console.WriteLine("URLs that access files are not allowed.");
        else
            Console.WriteLine($"Access to {input} is allowed.");

        Thread.CurrentThread.CurrentCulture = defaultCulture;
        // The example displays the following output:
        //       Culture-insensitive matching...
        //       URLs that access files are not allowed.
        // </Snippet15>
    }
}
