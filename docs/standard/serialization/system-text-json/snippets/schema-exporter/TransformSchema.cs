using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;

class TransformSchema
{
    public static void RunIt()
    {
        // <Snippet1>
        JsonSchemaExporterOptions exporterOptions = new()
        {
            TransformSchemaNode = (context, schema) =>
            {
                // Determine if a type or property and extract the relevant attribute provider.
                ICustomAttributeProvider? attributeProvider = context.PropertyInfo is not null
                    ? context.PropertyInfo.AttributeProvider
                    : context.TypeInfo.Type;

                // Look up any description attributes.
                DescriptionAttribute? descriptionAttr = attributeProvider?
                    .GetCustomAttributes(inherit: true)
                    .Select(attr => attr as DescriptionAttribute)
                    .FirstOrDefault(attr => attr is not null);

                // Apply description attribute to the generated schema.
                if (descriptionAttr != null)
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

                    jObj.Insert(0, "description", descriptionAttr.Description);
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
        //  "description": "A person",
        //  "type": ["object", "null"],
        //  "properties": {
        //    "Name": { "description": "The name of the person", "type": "string" }
        //  },
        //  "required": ["Name"]
        //}
        // </Snippet2>
    }

    // <SnippetPerson>
    [Description("A person")]
    record Person([property: Description("The name of the person")] string Name);
    // </SnippetPerson>
}
