class WriteAllLines
{
    public static async Task ExampleAsync()
    {
        string[] lines =
        {
            "First line", "Second line", "Third line" 
        };

        await File.WriteAllLinesAsync("WriteLines.txt", lines);
    }
}
