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

        //<VerbatimLiterals>
        string title = "\"The \u00C6olean Harp\", by Samuel Taylor Coleridge";
        //Output: "The Æolean Harp", by Samuel Taylor Coleridge
        //</EscapeSequences>

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
        System.Console.WriteLine(columns);
        System.Console.WriteLine(rows);
        System.Console.WriteLine(title);

        System.Console.WriteLine(filePath);
        System.Console.WriteLine(text);
        System.Console.WriteLine(quote);
    }

    public static void RawStringLiterals()
    {
        // <RawStringLiteralSyntax>
        string singleLine = """Friends say "hello" as they pass by.""";
        string multiLine = """
            "Hello World!" is typically the first program someone writes.
            """;
        string embeddedXML = """
               <element attr = "content">
                   <body style="normal">
                       Here is the main text
                   </body>
                   <footer>
                       Excerpts from "An amazing story"
                   </footer>
               </element >
               """;
        // The line "<element attr = "content">" starts in the first column.
        // All whitespace left of that column is removed from the string.

        string rawStringLiteralDelimiter = """"
            Raw string literals are delimited 
            by a string of at least three double quotes,
            like this: """
            """";
        // </RawStringLiteralSyntax>

        /*
        // <ErrorExamples>
        // CS8997: Unterminated raw string literal.
        var multiLineStart = """This
            is the beginning of a string 
            """;

        // CS9000: Raw string literal delimiter must be on its own line.
        var multiLineEnd = """
            This is the beginning of a string """;

        // CS8999: Line does not start with the same whitespace as the closing line
        // of the raw string literal
        var noOutdenting = """
            A line of text.
        Trying to outdent the second line.
            """;
        // </ErrorExamples>
        */

        // <JSONString>
        string jsonString = """
        {
          "Date": "2019-08-01T00:00:00-07:00",
          "TemperatureCelsius": 25,
          "Summary": "Hot",
          "DatesAvailable": [
            "2019-08-01T00:00:00-07:00",
            "2019-08-02T00:00:00-07:00"
          ],
          "TemperatureRanges": {
            "Cold": {
              "High": 20,
              "Low": -10
            },
            "Hot": {
              "High": 60,
              "Low": 20
            }
                    },
          "SummaryWords": [
            "Cool",
            "Windy",
            "Humid"
          ]
        }
        """;
        // </JSONString>
    }
}
