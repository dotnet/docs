using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WriteRawJson
{
    public class Program
    {
        public static void Main()
        {
            JsonWriterOptions writerOptions = new() { Indented = true, };

            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream, writerOptions);

            writer.WriteStartObject();

            writer.WriteStartArray("defaultJsonFormatting");
            foreach (double number in new double[] { 50.4, 51 })
            {
                writer.WriteStartObject();
                writer.WritePropertyName("value");
                writer.WriteNumberValue(number);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();

            writer.WriteStartArray("customJsonFormatting");
            foreach (double result in new double[] { 50.4, 51 })
            {
                writer.WriteStartObject();
                writer.WritePropertyName("value");
                writer.WriteRawValue(
                    FormatNumberValue(result), skipInputValidation: true);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();

            writer.WriteEndObject();
            writer.Flush();

            string json = Encoding.UTF8.GetString(stream.ToArray());
            Console.WriteLine(json);
        }
        static string FormatNumberValue(double numberValue)
        {
            return numberValue == Convert.ToInt32(numberValue) ? 
                numberValue.ToString() + ".0" : numberValue.ToString();
        }
    }
}
// output:
//{
//  "defaultJsonFormatting": [
//    {
//      "value": 50.4
//    },
//    {
//      "value": 51
//    }
//  ],
//  "customJsonFormatting": [
//    {
//      "value": 50.4
//    },
//    {
//      "value": 51.0
//    }
//  ]
//}
