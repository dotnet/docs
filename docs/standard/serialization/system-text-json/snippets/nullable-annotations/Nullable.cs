using System.Text.Json;

public static class Nullable1
{
    // <Unspecified>
    public static void RunIt()
    {
        JsonSerializerOptions options = new()
        {
            RespectNullableAnnotations = true
        };
        var result = JsonSerializer.Deserialize<MyPoco>("{}", options);
        Console.WriteLine(result.Name is null); // True.
    }

    class MyPoco
    {
        public string Name { get; set; }
    }
    // </Unspecified>
}

public static class Nullable2
{
    // <Serialization>
    public static void RunIt()
    {
#nullable enable
        JsonSerializerOptions options = new()
        {
            RespectNullableAnnotations = true
        };

        Person invalidValue = new(Name: null!);
        JsonSerializer.Serialize(invalidValue, options);
    }

    record Person(string Name);
    // </Serialization>
}

public static class Nullable3
{
    // <Deserialization>
    public static void RunIt()
    {
#nullable enable
        JsonSerializerOptions options = new()
        {
            RespectNullableAnnotations = true
        };

        string json = """{"Name":null}""";
        JsonSerializer.Deserialize<Person>(json, options);
    }

    record Person(string Name);
    // </Deserialization>
}

