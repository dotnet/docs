using System.Text.Json;

namespace NonStringKeyDictionary
{
    public class Program
    {
        public static void Run()
        {
            Dictionary<int, string> numbers = new()
            {
                [0] = "zero",
                [1] = "one",
                [34] = "thirty four",
                [55] = "fifty five"
            };

            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            }; 
            
            string json =
                JsonSerializer.Serialize<Dictionary<int, string>>(numbers, options);

            Console.WriteLine($"Output JSON: {json}");

            Dictionary<int, string> dictionary =
                JsonSerializer.Deserialize<Dictionary<int, string>>(json)!;

            Console.WriteLine($"dictionary[55]: {dictionary[55]}");
        }
    }
}

// Produces output like the following example:
//
//Output JSON: {
//  "0": "zero",
//  "1": "one",
//  "34": "thirty four",
//  "55": "fifty five"
//}
//dictionary[55]: fifty five
