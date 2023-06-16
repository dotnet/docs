using System.Runtime.CompilerServices;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;

var options = new JsonSerializerOptions
{
    TypeInfoResolver = new DefaultJsonTypeInfoResolver
    {
        Modifiers = { AddMissingMemberHandling }
    }
};

string json = """{"Name" : "John", "Surname" : "Doe", "Age" : 99 }""";
// Fails with:
// Unhandled exception. System.Text.Json.JsonException: JSON properties
// Surname, Age could not bind to any members of type MyPoco
JsonSerializer.Deserialize<MyPoco>(json, options);

static void AddMissingMemberHandling(JsonTypeInfo typeInfo)
{
    if (typeInfo.Kind == JsonTypeInfoKind.Object &&
        typeInfo.Properties.All(prop => !prop.IsExtensionData) &&
        typeInfo.OnDeserialized is null)
    {
        // Dynamically attach dictionaries to deserialized objects.
        var cwt = new ConditionalWeakTable<object, Dictionary<string, object>>();

        JsonPropertyInfo propertyInfo =
            typeInfo.CreateJsonPropertyInfo(typeof(Dictionary<string, object>), "__extensionDataAttribute");
        propertyInfo.Get = obj => cwt.TryGetValue(obj, out Dictionary<string, object>? value) ? value : null;
        propertyInfo.Set = (obj, value) => cwt.Add(obj, (Dictionary<string, object>)value!);
        propertyInfo.IsExtensionData = true;
        typeInfo.Properties.Add(propertyInfo);
        typeInfo.OnDeserialized = obj =>
        {
            if (cwt.TryGetValue(obj, out Dictionary<string, object>? dict))
            {
                cwt.Remove(obj);
                throw new JsonException($"JSON properties {String.Join(", ", dict.Keys)} " +
                    $"could not bind to any members of type {typeInfo.Type}");
            }
        };
    }
}

public class MyPoco
{
    public string? Name { get; set; }
}
