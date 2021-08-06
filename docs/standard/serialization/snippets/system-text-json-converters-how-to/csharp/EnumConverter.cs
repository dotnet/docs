using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace EnumConverter
{
    public class Program
    {
        public static void Main()
        {
            JsonSerializerOptions options = new() { Converters = { new CustomEnumConverterFactory() } };

            // If serialization happens first then we likely can support arbitrary values and flag combinations.
            SerializeThenDeserialize(DayOfWeek.Monday);
            SerializeThenDeserialize(BindingFlags.Instance | BindingFlags.Public);

            // Deserialize a "known" enum value without serializing first.
            BindingFlags value = JsonSerializer.Deserialize<BindingFlags>(@"""declaredOnly, createInstance""", options);
            Console.WriteLine(value);

            // Deserialize an "unknown" enum value without serializing first. Recall Enum.ToString() has specific and deterministic ordering for flags.
            try
            {
                JsonSerializer.Deserialize<BindingFlags>(@"""createInstance, declaredOnly""", options);
            }
            catch (JsonException) { }

            void SerializeThenDeserialize(object enumVal)
            {
                string json = JsonSerializer.Serialize(enumVal, options);
                Console.WriteLine(json);

                enumVal = JsonSerializer.Deserialize(json, enumVal.GetType(), options)!;
                Console.WriteLine(enumVal);
            }
        }

        // <Converter>
        private sealed class CustomEnumConverterFactory : JsonConverterFactory
        {
            public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

            public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
            {
                object[]? knownValues = null;

                if (typeToConvert == typeof(BindingFlags))
                {
                    knownValues = new object[] { BindingFlags.CreateInstance | BindingFlags.DeclaredOnly };
                }

                return (JsonConverter)Activator.CreateInstance(
                    typeof(CustomEnumConverter<>).MakeGenericType(typeToConvert),
                    BindingFlags.Instance | BindingFlags.Public,
                    binder: null,
                    args: new object?[] { JsonNamingPolicy.CamelCase, options, knownValues },
                    culture: null)!;
            }
        }

        private sealed class CustomEnumConverter<T> : JsonConverter<T> where T : Enum
        {
            private readonly JsonNamingPolicy _namingPolicy;

            private readonly Dictionary<string, T> _readCache = new();
            private readonly Dictionary<T, JsonEncodedText> _writeCache = new();

            // This converter will only support up to 64 enum values (including flags) on serialization and deserialization
            private const int NameCacheLimit = 64;

            private const string ValueSeparator = ", ";

            public CustomEnumConverter(JsonNamingPolicy namingPolicy, JsonSerializerOptions options, object[]? knownValues)
            {
                _namingPolicy = namingPolicy;

                bool continueProcessing = true;
                for (int i = 0; i < knownValues?.Length; i++)
                {
                    if (!TryProcessValue((T)knownValues[i]))
                    {
                        continueProcessing = false;
                        break;
                    }
                }

                if (continueProcessing)
                {
                    Array values = Enum.GetValues(typeof(T));

                    for (int i = 0; i < values.Length; i++)
                    {
                        T value = (T)values.GetValue(i)!;

                        if (!TryProcessValue(value))
                        {
                            break;
                        }
                    }
                }

                bool TryProcessValue(T value)
                {
                    if (_readCache.Count == NameCacheLimit)
                    {
                        Debug.Assert(_writeCache.Count == NameCacheLimit);
                        return false;
                    }

                    FormatAndAddToCaches(value, options.Encoder);
                    return true;
                }
            }

            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                string? json;

                if (reader.TokenType != JsonTokenType.String || (json = reader.GetString()) == null || !_readCache.TryGetValue(json, out T value))
                {
                    throw new JsonException();
                }

                return value;
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                if (!_writeCache.TryGetValue(value, out JsonEncodedText formatted))
                {
                    if (_writeCache.Count == NameCacheLimit)
                    {
                        Debug.Assert(_readCache.Count == NameCacheLimit);
                        throw new ArgumentOutOfRangeException("Cache count = cache limit", "");
                    }

                    formatted = FormatAndAddToCaches(value, options.Encoder);
                }

                writer.WriteStringValue(formatted);
            }

            private JsonEncodedText FormatAndAddToCaches(T value, JavaScriptEncoder? encoder)
            {
                (string valueFormattedToStr, JsonEncodedText valueEncoded) = FormatEnumValue(value.ToString(), _namingPolicy, encoder);
                _readCache[valueFormattedToStr] = value;
                _writeCache[value] = valueEncoded;
                return valueEncoded;
            }

            private ValueTuple<string, JsonEncodedText> FormatEnumValue(string value, JsonNamingPolicy namingPolicy, JavaScriptEncoder? encoder)
            {
                string converted;

                if (!value.Contains(ValueSeparator))
                {
                    converted = namingPolicy.ConvertName(value);
                }
                else
                {
                    // todo: optimize implementation here by leveraging https://github.com/dotnet/runtime/issues/934.
                    string[] enumValues = value.Split(ValueSeparator);

                    for (int i = 0; i < enumValues.Length; i++)
                    {
                        enumValues[i] = namingPolicy.ConvertName(enumValues[i]);
                    }

                    converted = string.Join(ValueSeparator, enumValues);
                }

                return (converted, JsonEncodedText.Encode(converted, encoder));
            }
            // </Converter>
        }
    }
}
