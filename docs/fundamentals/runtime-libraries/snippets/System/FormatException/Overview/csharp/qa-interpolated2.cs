using System;

public class Example13
{
    public static void Main()
    {
        // <SnippetQAInterpolated2>
        string[] names = { "Balto", "Vanya", "Dakota", "Samuel", "Koani", "Yiska", "Yuma" };
        string output = $"{names[0]}, {names[1]}, {names[2]}, {names[3]}, {names[4]}, " +
                        $"{names[5]}, {names[6]}";

        var date = DateTime.Now;
        output += $"\nIt is {date:t} on {date:d}. The day of the week is {date.DayOfWeek}.";
        Console.WriteLine(output);
        // The example displays the following output:
        //     Balto, Vanya, Dakota, Samuel, Koani, Yiska, Yuma
        //     It is 10:29 AM on 1/8/2018. The day of the week is Monday.
        // </SnippetQAInterpolated2>
    }
}
