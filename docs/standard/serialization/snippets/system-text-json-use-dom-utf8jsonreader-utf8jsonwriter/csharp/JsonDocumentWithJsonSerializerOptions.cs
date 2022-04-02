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

        // Ignore null properties doesn't work when serializing JsonDocument instance
        // by using JsonSerializer.
        // Output: {"Name":"Nancy","Address":null}
        var personJsonDocument = JsonSerializer.Deserialize<JsonDocument>(personJson);
        personJson = JsonSerializer.Serialize(personJsonDocument, options);
        Console.WriteLine(personJson);
    }
}
public class Person
{
    public string? Name { get; set; }

    public string? Address { get; set; }
}

