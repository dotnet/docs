// This sample takes a given input and replaces each
// occurence of the tab character with 4 space characters.
// It also takes two command-line arguements: input file name, & output file name.
// Usage:
//  EXPANDTABS inputfile.txt outputfile.txt
// System.Console.Read
// System.Console.WriteLine
// System.Console.Write
// System.Console.SetIn
// System.Console.SetOut
// System.Console.Error
// System.Console.Out
// <Snippet1>
using System;
using System.IO;

public class ExpandTabs
{
    private const int tabSize = 4;
    private const string usageText = "Usage: EXPANDTABSEX inputfile.txt outputfile.txt";

    public static void Main(string[] args)
    {
        StreamWriter writer = null;

        if (args.Length < 2) {
            Console.WriteLine(usageText);
            return;
        }

        try {
            writer = new StreamWriter(args[1]);
            Console.SetOut(writer);
            Console.SetIn(new StreamReader(args[0]));
        }
        catch(IOException e) {
            TextWriter errorWriter = Console.Error;
            errorWriter.WriteLine(e.Message);
            errorWriter.WriteLine(usageText);
            return;
        }
        int i;
        while ((i = Console.Read()) != -1) {
            char c = (char)i;
            if (c == '\t')
                Console.Write(("").PadRight(tabSize, ' '));
            else
                Console.Write(c);
        }
        writer.Close();
        // Recover the standard output stream so that a 
        // completion message can be displayed.
        StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
        Console.WriteLine("EXPANDTABSEX has completed the processing of {0}.", args[0]);
        return;
    }
}
// </Snippet1>

