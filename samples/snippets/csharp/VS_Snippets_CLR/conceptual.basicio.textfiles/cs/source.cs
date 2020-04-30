using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class WriteTextFiles
{
    static void Main(string[] args)
    {

        // Example 1: Shows how to synchronously write to
        // a text file using StreamWriter
        // line by line
        WriteLineByLine();

        // Example 2: Shows how to synchronously append text to
        // an existing file using StreamWriter
        AppendTextSW();

        // Example 3: Shows how to asynchronously write to
        // a text file using StreamWriter
        WriteTextAsync();

        // Example 4: Shows how to synchronously write and
        // append to a text file using File
        WriteFile();
    }

    // Example 1: Write line by line to a new text file with StreamWriter
    static void WriteLineByLine()
    {
        // <SnippetWriteLine>

        // Create a string array with the lines of text
        string[] lines = { "First line", "Second line", "Third line" };

        // Set a variable to the Documents path.
        string docPath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the string array to a new file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath,"WriteLines.txt"))) {
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }
        // </SnippetWriteLine>
    }

    // Example 2: Append a line to a text file with StreamWriter
    static void AppendTextSW()
    {
        // <SnippetAppendText>

        // Set a variable to the Documents path.
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Append text to an existing file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath,"WriteLines.txt"), true)) {
            outputFile.WriteLine("Fourth Line");
        }
        // </SnippetAppendText>
    }

    // Example 3: Write text asynchronously with StreamWriter
    static async void WriteTextAsync()
    {
        // <SnippetWriteAsync>

        // Set a variable to the Documents path.
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath,"WriteTextAsync.txt"))) {
            await outputFile.WriteAsync("This is a sentence.");
        }
        // </SnippetWriteAsync>
    }

    // Example 4: Write and append text using File
    static void WriteFile()
    {
        // <SnippetWriteFile>

        // Create a string array with the lines of text
        string text = "First line" + Environment.NewLine;

        // Set a variable to the Documents path.
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the text to a new file named "WriteFile.txt".
        File.WriteAllText(Path.Combine(docPath,"WriteFile.txt"), text);

        // Create a string array with the additional lines of text
        string[] lines = { "New line 1", "New line 2" };

        // Append new lines of text to the file
        File.AppendAllLines(Path.Combine(docPath,"WriteFile.txt"), lines);

        // </SnippetWriteFile>
    }
}
