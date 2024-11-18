using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;

internal class Serialization
{
    public static void RunIt()
    {
        // <Indentation>
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IndentCharacter = '\t',
            IndentSize = 2,
        };

        string json = JsonSerializer.Serialize(
            new { Value = 1 },
            options
            );
        Console.WriteLine(json);
        //{
        //                "Value": 1
        //}
        // </Indentation>

        // <Web>
        string webJson = JsonSerializer.Serialize(
            new { SomeValue = 42 },
            JsonSerializerOptions.Web // Defaults to camelCase naming policy.
            );
        Console.WriteLine(webJson);
        // {"someValue":42}
        // </Web>

        // <Schema>
        Console.WriteLine(JsonSchemaExporter.GetJsonSchemaAsNode(JsonSerializerOptions.Default, typeof(Book)));
        // </Schema>

        // <PropertyOrder>
        JsonObject jObj = new()
        {
            ["key1"] = true,
            ["key3"] = 3
        };

        Console.WriteLine(jObj is IList<KeyValuePair<string, JsonNode?>>); // True.

        // Insert a new key-value pair at the correct position.
        int key3Pos = jObj.IndexOf("key3") is int i and >= 0 ? i : 0;
        jObj.Insert(key3Pos, "key2", "two");

        foreach (KeyValuePair<string, JsonNode?> item in jObj)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // Output:
        // key1: true
        // key2: two
        // key3: 3
        // </PropertyOrder>
    }

    public static void RunIt3()
    {
        // <RespectRequired>
        JsonSerializerOptions options = new() { RespectRequiredConstructorParameters = true };

        // Throws exception: System.Text.Json.JsonException: JSON deserialization
        // for type 'Serialization+MyPoco' was missing required properties including: 'Value'.
        JsonSerializer.Deserialize<MyPoco>("""{}""", options);
        // </RespectRequired>
    }

    // <Book>
    public class Book
    {
        public required string Title { get; set; }
        public string? Author { get; set; }
        public int PublishYear { get; set; }
    }
    // </Book>

    // <Poco>
    record MyPoco(string Value);
    // </Poco>
}

public static class Serialization2
{
    // <RespectNullable>
    public static void RunIt()
    {
        JsonSerializerOptions options = new() { RespectNullableAnnotations = true };

        // Throws exception: System.Text.Json.JsonException: The property or field
        // 'Title' on type 'Serialization+Book' doesn't allow getting null values.
        // Consider updating its nullability annotation.
        JsonSerializer.Serialize(new Book { Title = null! }, options);

        // Throws exception: System.Text.Json.JsonException: The property or field
        // 'Title' on type 'Serialization+Book' doesn't allow setting null values.
        // Consider updating its nullability annotation.
        JsonSerializer.Deserialize<Book>("""{ "Title" : null }""", options);
    }

    public class Book
    {
        public required string Title { get; set; }
        public string? Author { get; set; }
        public int PublishYear { get; set; }
    }
    // </RespectNullable>
}
