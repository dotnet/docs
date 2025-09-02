using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;

class JsonObjectTitleExample
{
    public static void RunIt()
    {
        // <Snippet1>
        JsonSchemaExporterOptions exporterOptions = new()
        {
            TransformSchemaNode = (context, schema) =>
            {
                // Only set title for the root type (not properties)
                if (context.PropertyInfo is null && context.TypeInfo.Type == typeof(Person))
                {
                    if (schema is not JsonObject jObj)
                    {
                        // Handle the case where the schema is a Boolean.
                        JsonValueKind valueKind = schema.GetValueKind();
                        Debug.Assert(valueKind is JsonValueKind.True or JsonValueKind.False);
                        schema = jObj = new JsonObject();
                        if (valueKind is JsonValueKind.False)
                        {
                            jObj.Add("not", true);
                        }
                    }

                    // Set the title in the schema
                    jObj.Insert(0, "title", "PersonTitle");
                }

                return schema;
            }
        };
        // </Snippet1>

        // <Snippet2>
        JsonSerializerOptions options = JsonSerializerOptions.Default;
        JsonNode schema = options.GetJsonSchemaAsNode(typeof(Person), exporterOptions);
        Console.WriteLine(schema.ToString());
        //{
        //  "title": "PersonTitle",
        //  "type": ["object", "null"],
        //  "properties": {
        //    "Name": { "type": "string" },
        //    "Age": { "type": "integer" }
        //  },
        //  "required": ["Name", "Age"]
        //}
        // </Snippet2>
    }

    // <SnippetPerson>
    public record Person(string Name, int Age);
    // </SnippetPerson>
}