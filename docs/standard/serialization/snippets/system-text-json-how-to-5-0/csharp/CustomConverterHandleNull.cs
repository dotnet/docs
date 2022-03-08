using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomConverterHandleNull
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        [JsonConverter(typeof(DescriptionConverter))]
        public string? Description { get; set; }
    }

    public class DescriptionConverter : JsonConverter<string>
    {
        public override bool HandleNull => true;

        public override string Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            reader.GetString() ?? "No description provided.";

        public override void Write(
            Utf8JsonWriter writer,
            string value,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(value);
    }

    public class Program
    {
        public static void Main()
        {
            string json = @"{""x"":1,""y"":2,""Description"":null}";

            Point point = JsonSerializer.Deserialize<Point>(json)!;
            Console.WriteLine($"Description: {point.Description}");
        }
    }
}

// Produces output like the following example:
//
//Description: No description provided.
