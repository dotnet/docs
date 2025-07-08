
SyncRead();
await AsyncRead();

void SyncRead()
{
    //<sync>
    try
    {
        // Open the text file using a stream reader.
        using StreamReader reader = new("TestFile.txt");

        // Read the stream as a string.
        string text = reader.ReadToEnd();

        // Write the text to the console.
        Console.WriteLine(text);
    }
    catch (IOException e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
    }
    //</sync>
}

async Task AsyncRead()
{
    //<async>
    try
    {
        // Open the text file using a stream reader.
        using StreamReader reader = new("TestFile.txt");

        // Read the stream as a string.
        string text = await reader.ReadToEndAsync();

        // Write the text to the console.
        Console.WriteLine(text);
    }
    catch (IOException e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
    }
    //</async>
}
