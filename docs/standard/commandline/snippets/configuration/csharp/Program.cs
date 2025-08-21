// <all>
using System.CommandLine;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // <rootcommand>
        Option<FileInfo?> fileOption = new("--file")
        {
            Description = "An option whose argument is parsed as a FileInfo"
        };

        RootCommand rootCommand = new("Configuration sample")
        {
            fileOption
        };

        rootCommand.SetAction((parseResult) =>
        {
            FileInfo? fileOptionValue = parseResult.GetValue(fileOption);
            parseResult.InvocationConfiguration.Output.WriteLine(
                $"File option value: {fileOptionValue?.FullName}"
                );
        });
        // </rootcommand>

        // <captureoutput>
        StringWriter output = new();
        rootCommand.Parse("-h").Invoke(new() { Output = output });
        Debug.Assert(output.ToString().Contains("Configuration sample"));
        // </captureoutput>
    }
}
// </all>
