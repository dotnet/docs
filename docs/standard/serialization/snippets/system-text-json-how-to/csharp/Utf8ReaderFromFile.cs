using System.Text;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class Utf8ReaderFromFile
    {
        private static readonly byte[] s_nameUtf8 = Encoding.UTF8.GetBytes("name");
        private static ReadOnlySpan<byte> Utf8Bom => new byte[] { 0xEF, 0xBB, 0xBF };

        public static void Run()
        {
            // ReadAllBytes if the file encoding is UTF-8:
            string fileName = "UniversitiesUtf8.json";
            ReadOnlySpan<byte> jsonReadOnlySpan = File.ReadAllBytes(fileName);

            // Read past the UTF-8 BOM bytes if a BOM exists.
            if (jsonReadOnlySpan.StartsWith(Utf8Bom))
            {
                jsonReadOnlySpan = jsonReadOnlySpan.Slice(Utf8Bom.Length);
            }

            // Or read as UTF-16 and transcode to UTF-8 to convert to a ReadOnlySpan<byte>
            //string fileName = "Universities.json";
            //string jsonString = File.ReadAllText(fileName);
            //ReadOnlySpan<byte> jsonReadOnlySpan = Encoding.UTF8.GetBytes(jsonString);

            int count = 0;
            int total = 0;

            var reader = new Utf8JsonReader(jsonReadOnlySpan);

            while (reader.Read())
            {
                JsonTokenType tokenType = reader.TokenType;

                switch (tokenType)
                {
                    case JsonTokenType.StartObject:
                        total++;
                        break;
                    case JsonTokenType.PropertyName:
                        if (reader.ValueTextEquals(s_nameUtf8))
                        {
                            // Assume valid JSON, known schema
                            reader.Read();
                            if (reader.GetString()!.EndsWith("University"))
                            {
                                count++;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine($"{count} out of {total} have names that end with 'University'");
        }
    }
}
