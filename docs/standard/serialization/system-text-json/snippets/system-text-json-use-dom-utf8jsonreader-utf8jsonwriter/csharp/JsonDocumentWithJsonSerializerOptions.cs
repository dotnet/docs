using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace JsonDocumentWithJsonSerializerOptions;

public class Program
{
    public static void Main()
    {
        Person person = new Person { Name = "Nancy" };

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

        // Ignore null properties doesn't work when serializing JsonDocument instance
        // by using JsonSerializer.
        // Output: {"Name":"Nancy","Address":null}
        var personJsonDocument = JsonSerializer.Deserialize<JsonDocument>(personJsonWithNull);
        personJsonWithNull = JsonSerializer.Serialize(personJsonDocument, options);
        Console.WriteLine(personJsonWithNull);
    }
}
public class Person
{
    public string? Name { get; set; }

    public string? Address { get; set; }
}

