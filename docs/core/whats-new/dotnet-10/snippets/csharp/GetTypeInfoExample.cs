using System;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace GetTypeInfoExamples;

public class GetTypeInfoExample
{
    public static void Example()
    {
        // <GetTypeInfoExample>
        var options = new JsonSerializerOptions();
        
        // Get type info for a supported type
        JsonTypeInfo typeInfo = options.GetTypeInfo(typeof(Person));
        Console.WriteLine($"Type: {typeInfo.Type.Name}");
        Console.WriteLine($"Kind: {typeInfo.Kind}");
        
        // Downcast to JsonTypeInfo<T> for strongly-typed usage
        if (typeInfo is JsonTypeInfo<Person> personTypeInfo)
        {
            Person person = new("Alice", 30);
            string json = JsonSerializer.Serialize(person, personTypeInfo);
            Console.WriteLine($"Serialized: {json}");
        }
        // </GetTypeInfoExample>
    }
}

record Person(string Name, int Age);
