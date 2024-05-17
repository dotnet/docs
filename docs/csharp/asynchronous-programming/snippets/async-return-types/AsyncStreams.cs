namespace AsyncExamples;

public static class AsyncStreamExample
{
    public static async Task ReadWordsAsync()
    {
        await foreach (string word in ReadWordsFromStreamAsync())
        {
            Console.WriteLine(word);
        }
    }

    // <GenerateAsyncStream>
    static async IAsyncEnumerable<string> ReadWordsFromStreamAsync()
    {
        string data =
            @"This is a line of text.
                  Here is the second line of text.
                  And there is one more for good measure.
                  Wait, that was the penultimate line.";

        using var readStream = new StringReader(data);

        string? line = await readStream.ReadLineAsync();
        while (line != null)
        {
            foreach (string word in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                yield return word;
            }

            line = await readStream.ReadLineAsync();
        }
    }
    // </GenerateAsyncStream>
}
