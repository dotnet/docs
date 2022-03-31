using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace JsonNodeWithJsonSerializerOptions;

public class Program
{
    public static void Main()
    {
        Person person = new Person { Name = "Nancy" };

        // Serialize and ignore null properties - null Address property is omitted
        // Output: {"Name":"Nancy"}
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        string personJson = JsonSerializer.Serialize(person, options);
        Console.WriteLine(personJson);

        // Default serialization - Address property included with null token.
        // Output: {"Name":"Nancy","Address":null}
        personJson = JsonSerializer.Serialize(person);
        Console.WriteLine(personJson);

        // Ignore null properties doesn't work when serializing JsonNode instance
        // by using JsonSerializer.
        // Output: {"Name":"Nancy","Address":null}
        var personJsonNode = JsonSerializer.Deserialize<JsonNode>(personJson);
        personJson = JsonSerializer.Serialize(personJsonNode, options);
        Console.WriteLine(personJson);

        // Ignore null properties doesn't work when serializing JsonNode instance
        // by using JsonNode.ToJsonString method.
        // Output: {"Name":"Nancy","Address":null}
        personJson = personJsonNode!.ToJsonString(options);
        Console.WriteLine(personJson);

        // Ignore null properties doesn't work when serializing JsonNode instance
        // by using JsonNode.WriteTo method.
        // Output: {"Name":"Nancy","Address":null}
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);
        personJsonNode!.WriteTo(writer, options);
        writer.Flush();
        personJson = Encoding.UTF8.GetString(stream.ToArray());
        Console.WriteLine(personJson);
    }
}
public class Person
{
    public string? Name { get; set; }
    public string? Address { get; set; }
}

