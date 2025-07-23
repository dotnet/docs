// <all>
using System.CommandLine;

namespace scl;

class Program
{
    static int Main(string[] args)
    {
        // <option>
        Option<FileInfo> fileOption = new("--file")
        {
            Description = "The file to read and display on the console."
        };

        RootCommand rootCommand = new("Sample app for System.CommandLine");
        rootCommand.Options.Add(fileOption);
        // </option>

        // <setaction>
        rootCommand.SetAction(parseResult =>
        {
            FileInfo parsedFile = parseResult.GetValue(fileOption);
            ReadFile(parsedFile);
            return 0;
        });
        // </setaction>

        // <invoke>
        ParseResult parseResult = rootCommand.Parse(args);
        return parseResult.Invoke();
        // </invoke>
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
