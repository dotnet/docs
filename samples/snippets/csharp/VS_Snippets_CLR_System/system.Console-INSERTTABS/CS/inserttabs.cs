// This sample opens a file whose name is passed to it as a parameter. 
// It reads each line in the file and replaces every occurrence of 4 
// space characters with a tab character.
//
// It takes two command-line arguments: the input file name, and 
// the output file name.
//
// Usage:
//
//   INSERTTABS inputfile.txt outputfile.txt
//
// <Snippet1>
using System;
using System.IO;

public class InsertTabs
{
    private const int tabSize = 4;
    private const string usageText = "Usage: INSERTTABS inputfile.txt outputfile.txt";
    public static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine(usageText);
            return 1;
        }

        try
        {
            // Attempt to open output file.
            using (var writer = new StreamWriter(args[1]))
            {
                using (var reader = new StreamReader(args[0]))
                {
                    // Redirect standard output from the console to the output file.
                    Console.SetOut(writer);
                    // Redirect standard input from the console to the input file.
                    Console.SetIn(reader);
                    string line;
                    while ((line = Console.ReadLine()) != null)
                    {
                        string newLine = line.Replace(("").PadRight(tabSize, ' '), "\t");
                        Console.WriteLine(newLine);
                    }
                }
            }
        }
        catch(IOException e)
        {
            TextWriter errorWriter = Console.Error;
            errorWriter.WriteLine(e.Message);
            errorWriter.WriteLine(usageText);
            return 1;
        }

        // Recover the standard output stream so that a 
        // completion message can be displayed.
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
        Console.WriteLine($"INSERTTABS has completed the processing of {args[0]}.");
        return 0;
    }
}
// </Snippet1>
