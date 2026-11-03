namespace AnyKeyExamples;

// <DefaultCache>
public class DefaultCache : ICache
{
    private readonly string _cacheType;
    private readonly Dictionary<string, string> _data = new();

    public DefaultCache(string cacheType)
    {
        _cacheType = cacheType;
    }

    public string GetData(string key) =>
        _data.TryGetValue(key, out var value) ? value : $"No data in {_cacheType} cache";

    public void SetData(string key, string value) =>
        _data[key] = value;

    public override string ToString() => $"{_cacheType} cache";
}
// </DefaultCache>
