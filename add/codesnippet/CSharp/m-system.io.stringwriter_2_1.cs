using System;
using System.IO;
using System.Text;

class StrWriter
{
    static void Main()
    {
        StringWriter strWriter  = new StringWriter();

        // Use the three overloads of the Write method that are 
        // overridden by the StringWriter class.
        strWriter.Write("file path characters are: ");
        strWriter.Write(
            Path.InvalidPathChars, 0, Path.InvalidPathChars.Length);
        strWriter.Write('.');

        // Use the underlying StringBuilder for more complex 
        // manipulations of the string.
        strWriter.GetStringBuilder().Insert(0, "Invalid ");

        Console.WriteLine("The following string is {0} encoded.\n{1}", 
            strWriter.Encoding.EncodingName, strWriter.ToString());
    }
}