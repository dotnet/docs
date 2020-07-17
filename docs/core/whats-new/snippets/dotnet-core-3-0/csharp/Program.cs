using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace whats_new
{
    class Program
    {

        static async Task Main(string[] args)
        {
            // <SnippetPrintJsonCall>
            // Calling code
            Console.WriteLine("Read with Utf8JsonReader");
            PrintJson(File.ReadAllBytes("launch.json").AsSpan());
            // </SnippetPrintJsonCall>

            // <SnippetReadJsonCall>
            // Calling code
            Console.WriteLine("Read with JsonDocument");
            ReadJson(File.ReadAllText("launch.json"));
            // </SnippetReadJsonCall>

            // <SnippetJsonSerializeCall>
            // Calling code
            Console.WriteLine("Read with JsonSerializer");
            new JSON().WriteJSON();
            // </SnippetJsonSerializeCall>

            // <SnippetJsonDeserializeCall>
            // Calling code
            Console.WriteLine("Read with JsonSerializer");
            var person = JsonPerson.Parse(new JSON().WriteJSON());
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}\nAge: {person.Age}");
            // </SnippetJsonSerializeCall>

            //await TLS.ConnectCloudFlare();

            //Cipher.Run();
        }

        // <SnippetPrintJson>
        public static void PrintJson(ReadOnlySpan<byte> dataUtf8)
        {
            var json = new Utf8JsonReader(dataUtf8, isFinalBlock: true, state: default);

            while (json.Read())
            {
                JsonTokenType tokenType = json.TokenType;
                ReadOnlySpan<byte> valueSpan = json.ValueSpan;
                switch (tokenType)
                {
                    case JsonTokenType.StartObject:
                    case JsonTokenType.EndObject:
                        break;
                    case JsonTokenType.StartArray:
                    case JsonTokenType.EndArray:
                        break;
                    case JsonTokenType.PropertyName:
                        break;
                    case JsonTokenType.String:
                        Console.WriteLine($"STRING: {json.GetString()}");
                        break;
                    case JsonTokenType.Number:
                        if (!json.TryGetInt32(out int valueInteger))
                        {
                            throw new FormatException();
                        }
                        break;
                    case JsonTokenType.True:
                    case JsonTokenType.False:
                        Console.WriteLine($"BOOL: {json.GetBoolean()}");
                        break;
                    case JsonTokenType.Null:
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            dataUtf8 = dataUtf8.Slice((int)json.BytesConsumed);
            JsonReaderState state = json.CurrentState;
        }
        // </SnippetPrintJson>

        // <SnippetReadJson>
        public static void ReadJson(string jsonString)
        {
            using var document = JsonDocument.Parse(jsonString);

            var root = document.RootElement;
            var version = root.GetProperty("version").GetString();
            var configurations = root.GetProperty("configurations");

            Console.WriteLine($"Launch Version: {version}");

            foreach (var config in configurations.EnumerateArray())
            {
                var name = config.GetProperty("name").GetString();
                Console.WriteLine($"Config: {name}");
            }
        }
        // </SnippetReadJson>
    }
}
