namespace TourOfCsharp;
internal class AsyncSamples
{

    // <GetPageLengthAsync>
    public static async Task<int> GetPageLengthAsync(string endpoint)
    {
        var client = new HttpClient();
        var uri = new Uri(endpoint);
        byte[] content = await client.GetByteArrayAsync(uri);
        return content.Length;
    }
    // </GetPageLengthAsync>

    public static async Task UseReadSequence()
    {
        // <UseReadSequence>
        await foreach (var number in ReadSequence())
        {
            Console.WriteLine(number);
        }
        // </UseReadSequence>
    }

    // <ReadDataAsync>
    public static async IAsyncEnumerable<int> ReadSequence()
    {
        int index = 0;
        while (index < 100)
        {
            int[] nextChunk = await GetNextChunk(index);
            if (nextChunk.Length == 0)
            {
                yield break;
            }
            foreach (var item in nextChunk)
            {
                yield return item;
            }
            index++;
        }
    }
    // </ReadDataAsync>

    private static async Task<int[]> GetNextChunk(int index)
    {
        await Task.Delay(100);
        return [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ];
    }
}
