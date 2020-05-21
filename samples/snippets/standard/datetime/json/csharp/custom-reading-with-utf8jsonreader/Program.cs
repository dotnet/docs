using System;
using System.Globalization;
using System.Text;
using System.Text.Json;

public class Example
{
    public static void Main(string[] args)
    {
        byte[] utf8Data = Encoding.UTF8.GetBytes(@"""Friday, 26 July 2019 00:00:00""");

        var json = new Utf8JsonReader(utf8Data);
        while (json.Read())
        {
            if (json.TokenType == JsonTokenType.String)
            {
                string value = json.GetString();
                DateTimeOffset dto = DateTimeOffset.ParseExact(value, "F", CultureInfo.InvariantCulture);
                Console.WriteLine(dto);
            }
        }
    }
}

// The example displays output similar to the following:
// 7/26/2019 12:00:00 AM -04:00
