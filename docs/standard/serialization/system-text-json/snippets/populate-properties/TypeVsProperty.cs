using System.Text.Json.Serialization;

// <AttributeLevel>
// Type-level preference is Populate.
[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
class B
{
    // For this property only, use Replace behavior.
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Replace)]
    public List<int> Numbers1 { get; } = [1, 2, 3];
    public List<int> Numbers2 { get; set; } = [1, 2, 3];
}
// </AttributeLevel>
