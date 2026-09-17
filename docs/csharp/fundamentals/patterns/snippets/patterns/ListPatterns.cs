static class ListPatterns
{
    public static void Run()
    {
        Console.WriteLine($"Header: {IsHeader(["Name", "Score"])}");
        Console.WriteLine(GetAnnouncements(["Mina", "Luis", "Ada"]));
        Console.WriteLine(
            GetInputFile(["--verbose", "--safe", "report.csv"]));
        Console.WriteLine(
            $"Has content: {HasContent(["BEGIN", "value", "END"])}");
    }

    // <ExactListPattern>
    static bool IsHeader(string[] columns) =>
        columns is ["Name", "Score"];
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
    static bool HasContent(string[] entries) =>
        entries is ["BEGIN", .. { Length: > 0 }, "END"];
    // </SliceSubpattern>
}
