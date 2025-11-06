using System.Text.Json;

namespace ca2026
{
    public static class Examples
    {
        //<Violation>
        public static void ProcessJsonViolation(string json)
        {
            JsonElement element = JsonDocument.Parse(json).RootElement;
            //...
        }
        //</Violation>

        //<Fixed>
        public static void ProcessJsonFixed(string json)
        {
            JsonElement element = JsonElement.Parse(json);
            //...
        }
        //</Fixed>
    }
}
