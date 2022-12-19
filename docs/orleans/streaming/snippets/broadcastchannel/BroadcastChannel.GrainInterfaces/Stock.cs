using System.Text.Json.Serialization;

namespace BroadcastChannel.GrainsInterfaces;

public sealed class Stock
{
    [JsonPropertyName("Global Quote")]
    public GlobalQuote GlobalQuote { get; set; } = null!;
}
