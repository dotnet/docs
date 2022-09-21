using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripImmutableStruct
    {
        public static void Run()
        {
            string jsonString;
            var point1 = new ImmutablePoint(1, 2);
            var point2 = new ImmutablePoint(3, 4);
            var points = new List<ImmutablePoint> { point1, point2 };

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(points, serializeOptions);
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new ImmutablePointConverter(deserializeOptions));
            points = JsonSerializer.Deserialize<List<ImmutablePoint>>(jsonString, deserializeOptions)!;
            Console.WriteLine("Deserialized object values");
            foreach (ImmutablePoint point in points)
            {
                Console.WriteLine($"X,Y = {point.X},{point.Y}");
            }
        }
    }
}
