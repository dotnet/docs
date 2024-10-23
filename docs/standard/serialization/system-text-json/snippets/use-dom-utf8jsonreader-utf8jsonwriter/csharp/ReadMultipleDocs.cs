using System.Text.Json;

namespace ReadMultipleDocs;

public class Program
{
    public static void Main()
    {
        // <Snippet1>
        JsonReaderOptions options = new() { AllowMultipleValues = true };
        Utf8JsonReader reader = new("null {} 1 \r\n [1,2,3]"u8, options);

        reader.Read();
        Console.WriteLine(reader.TokenType); // Null

        reader.Read();
        Console.WriteLine(reader.TokenType); // StartObject
        reader.Skip();

        reader.Read();
        Console.WriteLine(reader.TokenType); // Number

        reader.Read();
        Console.WriteLine(reader.TokenType); // StartArray
        reader.Skip();

        Console.WriteLine(reader.Read()); // False
        // </Snippet1>
    }

    public static void Main2()
    {
        // <Snippet2>
        JsonReaderOptions options = new() { AllowMultipleValues = true };
        Utf8JsonReader reader = new("[1,2,3]    <NotJson/>"u8, options);

        reader.Read();
        reader.Skip(); // Succeeds.
        reader.Read(); // Throws JsonReaderException.
        // </Snippet2>
    }

    public static async void Main3()
    {
        // <Snippet3>
        ReadOnlySpan<byte> utf8Json = """[0] [0,1] [0,1,1] [0,1,1,2] [0,1,1,2,3]"""u8;
        using var stream = new MemoryStream(utf8Json.ToArray());

        var items = JsonSerializer.DeserializeAsyncEnumerable<int[]>(stream, topLevelValues: true);
        await foreach (int[] item in items)
        {
            Console.WriteLine(item.Length);
        }

        /* This snippet produces the following output:
         * 
         * 1
         * 2
         * 3
         * 4
         * 5
         */
        // </Snippet3>
    }
}
