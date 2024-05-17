using System.Text;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class ValueTextEqualsExample
    {
        // <DefineUtf8Var>
        private static readonly byte[] s_nameUtf8 = Encoding.UTF8.GetBytes("name");
        // </DefineUtf8Var>
        public static void Run(ReadOnlySpan<byte> jsonReadOnlySpan)
        {
            int count = 0;
            int total = 0;
            var reader = new Utf8JsonReader(jsonReadOnlySpan);

            // <UseUtf8Var>
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        total++;
                        break;
                    case JsonTokenType.PropertyName:
                        if (reader.ValueTextEquals(s_nameUtf8))
                        {
                            count++;
                        }
                        break;
                }
            }
            // </UseUtf8Var>
            Console.WriteLine($"{count} out of {total} have \"name\" properties");
        }
    }
}
