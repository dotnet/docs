using System;

public class Example4
{
    public static void Main()
    {
        // <Snippet15>
        DateTime date = new DateTime(2009, 06, 15, 13, 45, 30, 90);
        string fmt1 = "h \\h m \\m";
        string fmt2 = @"h \h m \m";

        Console.WriteLine("{0} ({1}) -> {2}", date, fmt1, date.ToString(fmt1));
        Console.WriteLine("{0} ({1}) -> {2}", date, fmt2, date.ToString(fmt2));

        // The example displays the following output:
        //       6/15/2009 1:45:30 PM (h \h m \m) -> 1 h 45 m
        //       6/15/2009 1:45:30 PM (h \h m \m) -> 1 h 45 m
        // </Snippet15>
    }
}
