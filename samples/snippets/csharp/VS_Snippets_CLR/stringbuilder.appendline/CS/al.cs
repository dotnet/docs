//<snippet1>
// This example demonstrates the StringBuilder.AppendLine() 
// method.

using System;
using System.Text;

class Sample 
{
    public static void Main() 
    {
    StringBuilder sb = new StringBuilder();
    string        line = "A line of text.";
    int           number = 123;

// Append two lines of text.
    sb.AppendLine("The first line of text.");
    sb.AppendLine(line);

// Append a new line, an empty string, and a null cast as a string.
    sb.AppendLine();
    sb.AppendLine("");
    sb.AppendLine((string)null);

// Append the non-string value, 123, and two new lines.
    sb.Append(number).AppendLine().AppendLine();

// Append two lines of text.
    sb.AppendLine(line);
    sb.AppendLine("The last line of text.");

// Convert the value of the StringBuilder to a string and display the string.
    Console.WriteLine(sb.ToString());
    }
}
/*
This example produces the following results:

The first line of text.
A line of text.



123

A line of text.
The last line of text.
*/
//</snippet1>