using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripStackOfT
    {
        public static void Run()
        {
            Console.WriteLine("Deserialize JSON string [1, 2, 3], then serialize it back to JSON.");
            Stack<int> stack = JsonSerializer.Deserialize<Stack<int>>("[1, 2, 3]")!;
            string serialized = JsonSerializer.Serialize(stack);
            Console.WriteLine($"Result is in reverse order: {serialized}");

            Console.WriteLine("Deserialize JSON string [1, 2, 3] with custom converter, then serialize it back to JSON.");
            // <Register>
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonConverterFactoryForStackOfT());
            // </Register>
            stack = JsonSerializer.Deserialize<Stack<int>>("[1, 2, 3]", options)!;
            serialized = JsonSerializer.Serialize(stack, options);
            Console.WriteLine($"Result is in same order: {serialized}");
        }
    }
}
