static class ListPatterns
{
    public static void Run()
    {
        Console.WriteLine(IsResetCommand([0x02, 0x52, 0x03]));
        Console.WriteLine(GetAnnouncements(["Mina", "Luis", "Ada"]));
        Console.WriteLine(GetInputFile(["--verbose", "--safe", "report.csv"]));
        Console.WriteLine(ValidateMessage(["BEGIN", "END"]));
    }

    // <ExactListPattern>
    static bool IsResetCommand(byte[] command) =>
        command is [0x02, 0x52, 0x03];
    // </ExactListPattern>

    // <CaptureElements>
    static string GetAnnouncements(List<string> finishingOrder) =>
        finishingOrder switch
        {
            [var winner, _, var thirdPlace] =>
                $"Winner: {winner}; third place: {thirdPlace}",
            _ => "A complete three-runner result isn't available"
        };
    // </CaptureElements>

    // <SlicePattern>
    static string GetInputFile(string[] arguments) =>
        arguments switch
        {
            ["--verbose", .., var fileName] => $"Verbose processing: {fileName}",
            [.., var fileName] => $"Processing: {fileName}",
            [] => "No input file was provided"
        };
    // </SlicePattern>

    // <SliceSubpattern>
    static string ValidateMessage(string[] entries) =>
        entries switch
        {
            ["BEGIN", .. { Length: 0 }, "END"] => "Reject empty payload",
            ["BEGIN", .., "END"] => "Process payload",
            _ => "Reject malformed message"
        };
    // </SliceSubpattern>
}
