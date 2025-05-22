// <all>
using System.CommandLine;
using System.IO;

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
        RootCommand rootCommand = new("Sample app for System.CommandLine")
        {
            fileOption
        };
        // </option>

        // <setaction>
        rootCommand.SetAction(parseResult => ReadFile(parseResult.GetValue(fileOption)));
        // </setaction>

        return rootCommand.Parse(args).Invoke();
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
