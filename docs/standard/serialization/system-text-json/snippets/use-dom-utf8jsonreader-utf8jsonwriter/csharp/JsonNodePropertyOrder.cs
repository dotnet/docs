using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;

namespace JsonNodePropertyOrder;

public class Program
{
    public static void Main()
    {
        // <Snippet1>
        var schema = (JsonObject)JsonSerializerOptions.Default.GetJsonSchemaAsNode(typeof(MyPoco));

        JsonNode? idValue;
        switch (schema.IndexOf("$id"))
        {
            // $id property missing.
            case < 0:
                idValue = (JsonNode)"https://example.com/schema";
                schema.Insert(0, "$id", idValue);
                break;

            // $id property already at the start of the object.
            case 0:
                break;

            // $id exists but not at the start of the object.
            case int index:
                idValue = schema[index];
                schema.RemoveAt(index);
                schema.Insert(0, "$id", idValue);
                break;
        }
        // </Snippet1>
    }
}

class MyPoco { }
