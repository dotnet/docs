using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

public static class RequiredProperties
{
    // <Keyword>
    public static void RunIt()
    {
        // The following line throws a JsonException at run time.
        Console.WriteLine(JsonSerializer.Deserialize<Person>("""{"Age": 42}"""));
    }

    public class Person
    {
        public required string Name { get; set; }
        public int Age { get; set; }
    }
    // </Keyword>
}

public static class RequiredProperties2
{
    // <Attribute>
    public static void RunIt()
    {
        // The following line throws a JsonException at run time.
        Console.WriteLine(JsonSerializer.Deserialize<Person>("""{"Age": 42}"""));
    }

    public class Person
    {
        [JsonRequired]
        public string Name { get; set; }
        public int Age { get; set; }
    }
    // </Attribute>
}

public static class RequiredProperties3
{
    // <ContractModel>
    public static void RunIt()
    {
        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers =
                {
                    static typeInfo =>
                    {
                        if (typeInfo.Kind != JsonTypeInfoKind.Object)
                            return;

                        foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
                        {
                            // Strip IsRequired constraint from every property.
                            propertyInfo.IsRequired = false;
                        }
                    }
                }
            }
        };

        // Deserialization succeeds even though
        // the Name property isn't in the JSON payload.
        JsonSerializer.Deserialize<Person>("""{"Age": 42}""", options);
    }

    public class Person
    {
        public required string Name { get; set; }
        public int Age { get; set; }
    }
    // </ContractModel>
}

public static class RequiredProperties4
{
    // <RequiredConstrParams>
    public static void RunIt()
    {
        JsonSerializerOptions options = new()
        {
            RespectRequiredConstructorParameters = true
        };
        string json = """{"Age": 42}""";

        // The following line throws a JsonException at run time.
        JsonSerializer.Deserialize<Person>(json, options);
    }

    record Person(string Name, int? Age = null);
    // </RequiredConstrParams>
}
