using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Serialization
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class AllowIntsAsStringsExample
    {
        static void SetNumberHandlingModifier(JsonTypeInfo jsonTypeInfo)
        {
            if (jsonTypeInfo.Type == typeof(int))
            {
                jsonTypeInfo.NumberHandling = JsonNumberHandling.AllowReadingFromString;
            }
        }

        public static void RunIt()
        {
            JsonSerializerOptions options = new()
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { SetNumberHandlingModifier }
                }
            };

            // Triple-quote syntax is a C# 11 feature.
            Point point = JsonSerializer.Deserialize<Point>("""{"X":"12","Y":"3"}""", options)!;
            Console.WriteLine($"({point.X},{point.Y})");
            // (12,3)
        }
    }
}
