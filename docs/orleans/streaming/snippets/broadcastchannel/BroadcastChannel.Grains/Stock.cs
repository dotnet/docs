using System.Text.Json.Serialization;

namespace BroadcastChannel.Grains;

public sealed class Stock
{
    [JsonPropertyName("Global Quote")]
    public GlobalQuote GlobalQuote { get; set; } = null!;
}
