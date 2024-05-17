using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class ImmutablePointConverter : JsonConverter<ImmutablePoint>
    {
        private readonly JsonEncodedText _xName = JsonEncodedText.Encode("X");
        private readonly JsonEncodedText _yName = JsonEncodedText.Encode("Y");

        private readonly JsonConverter<int> _intConverter;

        public ImmutablePointConverter(JsonSerializerOptions options) => 
            _intConverter = options?.GetConverter(typeof(int)) is JsonConverter<int> intConverter
                ? intConverter
                : throw new InvalidOperationException();

        public override ImmutablePoint Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            };

            int? x = default;
            int? y = default;

            // Get the first property.
            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.ValueTextEquals(_xName.EncodedUtf8Bytes))
            {
                x = ReadProperty(ref reader, options);
            }
            else if (reader.ValueTextEquals(_yName.EncodedUtf8Bytes))
            {
                y = ReadProperty(ref reader, options);
            }
            else
            {
                throw new JsonException();
            }

            // Get the second property.
            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (x.HasValue && reader.ValueTextEquals(_yName.EncodedUtf8Bytes))
            {
                y = ReadProperty(ref reader, options);
            }
            else if (y.HasValue && reader.ValueTextEquals(_xName.EncodedUtf8Bytes))
            {
                x = ReadProperty(ref reader, options);
            }
            else
            {
                throw new JsonException();
            }

            reader.Read();

            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return new ImmutablePoint(x.GetValueOrDefault(), y.GetValueOrDefault());
        }

        private int ReadProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            Debug.Assert(reader.TokenType == JsonTokenType.PropertyName);

            reader.Read();
            return _intConverter.Read(ref reader, typeof(int), options);
        }

        private void WriteProperty(Utf8JsonWriter writer, JsonEncodedText name, int intValue, JsonSerializerOptions options)
        {
            writer.WritePropertyName(name);
            _intConverter.Write(writer, intValue, options);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImmutablePoint point,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            WriteProperty(writer, _xName, point.X, options);
            WriteProperty(writer, _yName, point.Y, options);
            writer.WriteEndObject();
        }
    }
}
