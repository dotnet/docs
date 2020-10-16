using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace CustomConverterHandleNull
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Dictionary<int, int> AdditionalValues;

        [JsonConverter(typeof(DescriptionConverter))]
        public string Description { get; set; }

        public Point()
        {
        }

        // Specify which ctor should be used when deserializing.
        // Attribute not needed if this is the only ctor.
        [JsonConstructor]
        public Point(int x, int y) => (X, Y) = (x, y);
    }

    public class DescriptionConverter : JsonConverter<string>
    {
        public override bool HandleNull => true;

        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string val = reader.GetString();
            return val ?? "No description provided.";
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
    public class Program
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            IncludeFields = true,
            WriteIndented = true
        };

        public static void Main()
        {
            var point = new Point(1, 2)
            {
                AdditionalValues = new Dictionary<int, int>
                {
                    [3] = 4,
                    [5] = 6,
                }
            };

            string serialized = JsonSerializer.Serialize(point, options);
            Console.WriteLine($"Output JSON:\n{serialized}");

            point = JsonSerializer.Deserialize<Point>(serialized, options);
            Console.WriteLine($"X: {point.X}");
            Console.WriteLine($"Y: {point.Y}");
            Console.WriteLine($"Additional values count: {point.AdditionalValues.Count}");
            Console.WriteLine($"AdditionalValues[3]: {point.AdditionalValues[3]}");
            Console.WriteLine($"AdditionalValues[5]: {point.AdditionalValues[5]}");
            Console.WriteLine($"Description: {point.Description}");
        }
    }
}
