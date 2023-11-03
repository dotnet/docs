using System.Text.Json.Serialization;
using System.Text.Json;

// <StructProperty>
C? c = JsonSerializer.Deserialize<C>("""{"S1": {"Value2": 5}}""");

class C
{
    public C()
    {
        _s1 = new S
        {
            Value1 = 10
        };
    }

    private S _s1;

    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public S S1
    {
        get { return _s1; }
        set { _s1 = value; }
    }
}

struct S
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
}
// </StructProperty>
