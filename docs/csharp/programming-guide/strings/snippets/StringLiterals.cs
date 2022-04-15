namespace StringExamples;

using System;

public class Literals
{
    public static void StringLiterals()
    {
        //<EscapeSequences>
        string columns = "Column 1\tColumn 2\tColumn 3";
        //Output: Column 1        Column 2        Column 3

        string rows = "Row 1\r\nRow 2\r\nRow 3";
        /* Output:
            Row 1
            Row 2
            Row 3
        */

        string title = "\"The \u00C6olean Harp\", by Samuel Taylor Coleridge";
        //Output: "The Æolean Harp", by Samuel Taylor Coleridge
        //</EscapeSequences>

        System.Console.WriteLine(columns);
        System.Console.WriteLine(rows);
        System.Console.WriteLine(title);

        //<VerbatimLiterals>
        string filePath = @"C:\Users\scoleridge\Documents\";
        //Output: C:\Users\scoleridge\Documents\

        string text = @"My pensive SARA ! thy soft cheek reclined
            Thus on mine arm, most soothing sweet it is
            To sit beside our Cot,...";
        /* Output:
        My pensive SARA ! thy soft cheek reclined
            Thus on mine arm, most soothing sweet it is
            To sit beside our Cot,...
        */

        string quote = @"Her name was ""Sara.""";
        //Output: Her name was "Sara."
        //</VerbatimLiterals>
        System.Console.WriteLine(filePath);
        System.Console.WriteLine(text);
        System.Console.WriteLine(quote);

    }
}