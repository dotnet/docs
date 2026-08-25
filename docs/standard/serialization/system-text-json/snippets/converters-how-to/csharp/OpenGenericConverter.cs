using System.Text.Json;
using System.Text.Json.Serialization;

// <OptionType>
[JsonConverter(typeof(OptionConverter<>))]
public readonly struct Option<T>
{
    public bool HasValue { get; }
    public T Value { get; }

    public Option(T value)
    {
        HasValue = true;
        Value = value;
    }
}
// </OptionType>

// <OptionConverter>
public sealed class OptionConverter<T> : JsonConverter<Option<T>>
{
    public override bool HandleNull => true;

    public override Option<T> Read(
        ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return default;
        }

        T value = JsonSerializer.Deserialize<T>(ref reader, options)!;
        return new Option<T>(value);
    }

    public override void Write(
        Utf8JsonWriter writer, Option<T> value, JsonSerializerOptions options)
    {
        if (!value.HasValue)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value.Value, options);
    }
}
// </OptionConverter>

// <Usage>
public class UserProfile
{
    public string Name { get; set; } = "";
    public Option<string> Nickname { get; set; }
    public Option<int> Age { get; set; }
}
// </Usage>
