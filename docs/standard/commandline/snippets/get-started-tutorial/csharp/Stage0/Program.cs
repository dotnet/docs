// <all>
using System.CommandLine;
using System.CommandLine.Parsing;

namespace scl;

class Program
{
    static int Main(string[] args)
    {
        // <symbols>
        Option<FileInfo> fileOption = new("--file")
        {
            Description = "The file to read and display on the console."
        };

        RootCommand rootCommand = new("Sample app for System.CommandLine");
        rootCommand.Options.Add(fileOption);
        // </symbols>

        // <parse>
        ParseResult parseResult = rootCommand.Parse(args);
        if (parseResult.GetValue(fileOption) is FileInfo parsedFile)
        {
            ReadFile(parsedFile);
            return 0;
        }
        // </parse>
        // <errors>
        foreach (ParseError parseError in parseResult.Errors)
        {
            Console.Error.WriteLine(parseError.Message);
        }
        return 1;
        // </errors>
    }

    // <action>
    static void ReadFile(FileInfo file)
    {
        foreach (string line in File.ReadLines(file.FullName))
        {
            Console.WriteLine(line);
        }
    }
    // </action>
}
// </all>
