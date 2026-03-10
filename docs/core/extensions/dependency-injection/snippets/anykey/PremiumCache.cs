namespace AnyKeyExamples;

// <PremiumCache>
public class PremiumCache : ICache
{
    private readonly Dictionary<string, string> _data = new();

    public string GetData(string key) =>
        _data.TryGetValue(key, out var value) ? value : "No data in premium cache";

    public void SetData(string key, string value) =>
        _data[key] = value;

    public override string ToString() => "Premium cache";
}
// </PremiumCache>
