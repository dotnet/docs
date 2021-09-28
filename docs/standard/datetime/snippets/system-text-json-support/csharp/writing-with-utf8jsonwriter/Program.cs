using System;
using System.IO;
using System.Text;
using System.Text.Json;

public class Example
{
    public static void Main(string[] args)
    {
        JsonWriterOptions options = new JsonWriterOptions
        {
            Indented = true
        };

        using (MemoryStream stream = new MemoryStream())
        {
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream, options))
            {
                writer.WriteStartObject();
                writer.WriteString("date", DateTimeOffset.UtcNow);
                writer.WriteNumber("temp", 42);
                writer.WriteEndObject();
            }

            string json = Encoding.UTF8.GetString(stream.ToArray());
            Console.WriteLine(json);
        }
    }
}

// The example output similar to the following:
// {
//     "date": "2019-07-26T00:00:00+00:00",
//     "temp": 42
// }
