using System;

public class Example12
{
    public static void Main()
    {
        // <SnippetQAInterpolated>
        string[] names = { "Balto", "Vanya", "Dakota", "Samuel", "Koani", "Yiska", "Yuma" };
        string output = names[0] + ", " + names[1] + ", " + names[2] + ", " +
                        names[3] + ", " + names[4] + ", " + names[5] + ", " +
                        names[6];

        output += "\n";
        var date = DateTime.Now;
        output += String.Format("It is {0:t} on {0:d}. The day of the week is {1}.",
                                date, date.DayOfWeek);
        Console.WriteLine(output);
        // The example displays the following output:
        //     Balto, Vanya, Dakota, Samuel, Koani, Yiska, Yuma
        //     It is 10:29 AM on 1/8/2018. The day of the week is Monday.
        // </SnippetQAInterpolated>
    }
}
