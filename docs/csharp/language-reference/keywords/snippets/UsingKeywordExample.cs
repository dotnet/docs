// <UsingDirective>
using System;
using System.IO;
// </UsingDirective>

public class UsingStatementSample
{
    public static void Main()
    {
        // <UsingStatement>
        string filePath = "example.txt";
        string textToWrite = "Hello, this is a test message!";

        // Use the using statement to ensure the StreamWriter is properly disposed of
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(textToWrite);
        }
        // </UsingStatement>
    }
}
