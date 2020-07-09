using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class ImmutablePointConverter : JsonConverter<ImmutablePoint>
    {
        private readonly JsonEncodedText XName = JsonEncodedText.Encode("X");
        private readonly JsonEncodedText YName = JsonEncodedText.Encode("Y");

        private readonly JsonConverter<int> _intConverter;

        public ImmutablePointConverter(JsonSerializerOptions options)
        {
            if (options?.GetConverter(typeof(int)) is JsonConverter<int> intConverter)
            {
                _intConverter = intConverter;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override ImmutablePoint Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            };

            int x = default;
            bool xSet = false;

            int y = default;
            bool ySet = false;

            // Get the first property.
            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.ValueTextEquals(XName.EncodedUtf8Bytes))
            {
                x = ReadProperty(ref reader, options);
                xSet = true;
            }
            else if (reader.ValueTextEquals(YName.EncodedUtf8Bytes))
            {
                y = ReadProperty(ref reader, options);
                ySet = true;
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

            if (xSet && reader.ValueTextEquals(YName.EncodedUtf8Bytes))
            {
                y = ReadProperty(ref reader, options);
            }
            else if (ySet && reader.ValueTextEquals(XName.EncodedUtf8Bytes))
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

            return new ImmutablePoint(x, y);
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
            WriteProperty(writer, XName, point.X, options);
            WriteProperty(writer, YName, point.Y, options);
            writer.WriteEndObject();
        }
    }
}
