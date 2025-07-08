using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace JsonNodeWithJsonSerializerOptions;

public class Program
{
    public static void Main()
    {
        Person person = new() { Name = "Nancy" };

        // Default serialization - Address property included with null token.
        // Output: {"Name":"Nancy","Address":null}
        string personJsonWithNull = JsonSerializer.Serialize(person);
        Console.WriteLine(personJsonWithNull);

        // Serialize and ignore null properties - null Address property is omitted
        // Output: {"Name":"Nancy"}
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        string personJsonWithoutNull = JsonSerializer.Serialize(person, options);
        Console.WriteLine(personJsonWithoutNull);

        // Ignore null properties doesn't work when serializing JsonNode instance
        // by using JsonSerializer.
        // Output: {"Name":"Nancy","Address":null}
        JsonNode? personJsonNode = JsonSerializer.Deserialize<JsonNode>(personJsonWithNull);
        personJsonWithNull = JsonSerializer.Serialize(personJsonNode, options);
        Console.WriteLine(personJsonWithNull);

        // Ignore null properties doesn't work when serializing JsonNode instance
        // by using JsonNode.ToJsonString method.
        // Output: {"Name":"Nancy","Address":null}
        personJsonWithNull = personJsonNode!.ToJsonString(options);
        Console.WriteLine(personJsonWithNull);

        // Ignore null properties doesn't work when serializing JsonNode instance
        // by using JsonNode.WriteTo method.
        // Output: {"Name":"Nancy","Address":null}
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);
        personJsonNode!.WriteTo(writer, options);
        writer.Flush();
        personJsonWithNull = Encoding.UTF8.GetString(stream.ToArray());
        Console.WriteLine(personJsonWithNull);
    }
}

public class Person
{
    public string? Name { get; set; }
    public string? Address { get; set; }
}

