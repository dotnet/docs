using System.Text.Json;

namespace Shared;

public static class DefaultJsonSerialization
{
    public static JsonSerializerOptions Options { get; } =
        new(JsonSerializerDefaults.Web);
}
