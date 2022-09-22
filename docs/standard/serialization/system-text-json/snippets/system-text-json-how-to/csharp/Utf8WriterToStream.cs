using System.Text;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class Utf8WriterToStream
    {
        public static void Run()
        {
            // <Serialize>
            var options = new JsonWriterOptions
            {
                Indented = true
            };

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream, options);

            writer.WriteStartObject();
            writer.WriteString("date", DateTimeOffset.UtcNow);
            writer.WriteNumber("temp", 42);
            writer.WriteEndObject();
            writer.Flush();

            string json = Encoding.UTF8.GetString(stream.ToArray());
            Console.WriteLine(json);
            // </Serialize>

            Console.WriteLine();
        }
    }
}
