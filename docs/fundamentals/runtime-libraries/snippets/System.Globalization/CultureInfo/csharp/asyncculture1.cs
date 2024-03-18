// <Snippet1>
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

public class AsyncCultureEx1
{
    public static void Main()
    {
        decimal[] values = { 163025412.32m, 18905365.59m };
        string formatString = "C2";

        string FormatDelegate()
        {
            string output = $"Formatting using the {CultureInfo.CurrentCulture.Name} " +
            "culture on thread {Thread.CurrentThread.ManagedThreadId}.\n";
            foreach (decimal value in values)
                output += $"{value.ToString(formatString)}   ";

            output += Environment.NewLine;
            return output;
        }

        Console.WriteLine($"The example is running on thread {Thread.CurrentThread.ManagedThreadId}");
        // Make the current culture different from the system culture.
        Console.WriteLine($"The current culture is {CultureInfo.CurrentCulture.Name}");
        if (CultureInfo.CurrentCulture.Name == "fr-FR")
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        else
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

        Console.WriteLine($"Changed the current culture to {CultureInfo.CurrentCulture.Name}.\n");

        // Execute the delegate synchronously.
        Console.WriteLine("Executing the delegate synchronously:");
        Console.WriteLine(FormatDelegate());

        // Call an async delegate to format the values using one format string.
        Console.WriteLine("Executing a task asynchronously:");
        var t1 = Task.Run(FormatDelegate);
        Console.WriteLine(t1.Result);

        Console.WriteLine("Executing a task synchronously:");
        var t2 = new Task<string>(FormatDelegate);
        t2.RunSynchronously();
        Console.WriteLine(t2.Result);
    }
}
// The example displays the following output:
//         The example is running on thread 1
//         The current culture is en-US
//         Changed the current culture to fr-FR.
//
//         Executing the delegate synchronously:
//         Formatting using the fr-FR culture on thread 1.
//         163 025 412,32 €   18 905 365,59 €
//
//         Executing a task asynchronously:
//         Formatting using the fr-FR culture on thread 3.
//         163 025 412,32 €   18 905 365,59 €
//
//         Executing a task synchronously:
//         Formatting using the fr-FR culture on thread 1.
//         163 025 412,32 €   18 905 365,59 €
// </Snippet1>
