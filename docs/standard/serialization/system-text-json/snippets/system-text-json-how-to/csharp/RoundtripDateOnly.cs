using System.Text.Json;

namespace SystemTextJsonSamples;

public class RoundtripDateOnly
{
    public static void Run()
    {
        Console.WriteLine("""
            Serialize SeriesDataPoint class to a JSON string,
            then deserialize it back object.
            """);

        // <RoundtripDateOnly>
        SeriesDataPoint originalData = new(
            Id: Guid.NewGuid(),
            Value: 3.791m,
            Date: new DateOnly(2002, 1, 13),
            Time: new TimeOnly(5, 3, 1));
        string serialized = JsonSerializer.Serialize(originalData);

        Console.WriteLine($"Resulting JSON: {serialized}");

        SeriesDataPoint deserializedData =
            JsonSerializer.Deserialize<SeriesDataPoint>(serialized)!;

        bool valuesAreTheSame = originalData == deserializedData;
        Console.WriteLine($"""
            Original record is the same as the deserialized record: {valuesAreTheSame}
            """);
        // </RoundtripDateOnly>
    }
}

// <SeriesDataPoint>
sealed file record class SeriesDataPoint(
    Guid Id,
    decimal Value,
    DateOnly Date,
    TimeOnly Time);
// </SeriesDataPoint>
