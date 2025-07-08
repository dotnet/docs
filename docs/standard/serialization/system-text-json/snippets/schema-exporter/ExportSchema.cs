using System.Text.Json.Nodes;
using System.Text.Json;
using System;
using System.Text.Json.Schema;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

public class ExtractExample1
{
    // <Snippet1>
    public static void SimpleExtraction()
    {
        JsonSerializerOptions options = JsonSerializerOptions.Default;
        JsonNode schema = options.GetJsonSchemaAsNode(typeof(Person));
        Console.WriteLine(schema.ToString());
        //{
        //  "type": ["object", "null"],
        //  "properties": {
        //    "Name": { "type": "string" },
        //    "Age": { "type": "integer" },
        //    "Address": { "type": ["string", "null"], "default": null }
        //  },
        //  "required": ["Name", "Age"]
        //}
    }

    record Person(string Name, int Age, string? Address = null);
    // </Snippet1>
}

public class ExtractExample2
{
    // <Snippet2>
    public static void CustomExtraction()
    {
        JsonSerializerOptions options = new(JsonSerializerOptions.Default)
        {
            PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper,
            NumberHandling = JsonNumberHandling.WriteAsString,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
        };

        JsonNode schema = options.GetJsonSchemaAsNode(typeof(MyPoco));
        Console.WriteLine(schema.ToString());
        //{
        //  "type": ["object", "null"],
        //  "properties": {
        //    "NUMERIC-VALUE": {
        //      "type": ["string", "integer"],
        //      "pattern": "^-?(?:0|[1-9]\\d*)$"
        //    }
        //  },
        //  "additionalProperties": false
        //}
    }

    class MyPoco
    {
        public int NumericValue { get; init; }
    }
    // </Snippet2>
}

public class ExtractExample3
{
    // <Snippet3>
    public static void CustomExtraction()
    {
        JsonSerializerOptions options = JsonSerializerOptions.Default;
        JsonSchemaExporterOptions exporterOptions = new()
        {
            TreatNullObliviousAsNonNullable = true,
        };

        JsonNode schema = options.GetJsonSchemaAsNode(typeof(Person), exporterOptions);
        Console.WriteLine(schema.ToString());
        //{
        //  "type": "object",
        //  "properties": {
        //    "Name": { "type": "string" }
        //  },
        //  "required": ["Name"]
        //}
    }

    record Person(string Name);
    // </Snippet3>
}
