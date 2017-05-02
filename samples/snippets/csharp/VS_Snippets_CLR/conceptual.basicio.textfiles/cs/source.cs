using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class WriteTextFiles
{
    static void Main(string[] args)
    {

        // Example 1: shows how to write synchronously
        // to a text file using StreamWriter
        // line by line
        WriteLineByLine();

        // Example 2: Appending text to
        // an existing file using StreamWriter
        AppendTextSW();

        // Example 3: shows how to write a 
        // a simple string asynchronously
        // to a text file using StreamWriter
        string text = "This is a sentence.";
        WriteTextAsync(text);

        // Example 4: shows how to write synchronously
        // to a text file using File and then
        // adding additional lines 
        WriteFile();
    }

    static void WriteLineByLine()
    {
        // <SnippetWriteLine>
        // Create a string array with the lines of text
        string[] lines = { "First line", "Second line", "Third line" };

        // Set a variable to the My Documents path.
        string mydocpath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the string array to a new file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.txt")) {
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }
        // </SnippetWriteLine>

    }

    static void AppendTextSW()
    {
        // <SnippetAppendText>
        // Set a variable to the My Documents path.
        string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Append text to an existing file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.txt", true)) {
            outputFile.WriteLine("Fourth Line");
        }
        // </SnippetAppendText>

    }

    // <SnippetWriteAsync>
    static async void WriteTextAsync(string text)
    {
        // Set a variable to the My Documents path.
        string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the text asynchronously to a new file named "WriteTextAsync.txt".
        using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteTextAsync.txt")) {
            await outputFile.WriteAsync(text);
        }
    }
    // </SnippetWriteAsync>

    static void WriteFile()
    {
        // <SnippetWriteFile>
        // Create a string array with the lines of text
        string text = "First line" + Environment.NewLine;

        // Set a variable to the My Documents path.
        string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the text to a new file named "WriteFile.txt".
        File.WriteAllText(mydocpath + @"\WriteFile.txt", text);

        // Create a string array with the additional lines of text
        string[] lines = { "New line 1", "New line 2" };

        // Append new lines of text to the file
        File.AppendAllLines(mydocpath + @"\WriteFile.txt", lines);
        // </SnippetWriteFile>

    }

}