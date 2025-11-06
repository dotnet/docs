using System.Text.Json;

namespace ca2026
{
    public static class Examples
    {
        //<Violation>
        public static void ProcessJsonViolation(string json)
        {
            JsonElement element = JsonDocument.Parse(json).RootElement;
            // Process element
        }
        //</Violation>

        //<Fixed>
        public static void ProcessJsonFixed(string json)
        {
            // JsonElement.Parse is available in .NET 10+
#if NET10_0_OR_GREATER
            JsonElement element = JsonElement.Parse(json);
#else
            // This code demonstrates the preferred API for .NET 10+
            // For compilation on earlier versions, we use the old pattern
            JsonElement element = JsonDocument.Parse(json).RootElement;
#endif
            // Process element
        }
        //</Fixed>
    }
}
