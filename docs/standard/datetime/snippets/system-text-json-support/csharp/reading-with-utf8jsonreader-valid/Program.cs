using System;
using System.Text;
using System.Text.Json;

public class Example
{
    public static void Main(string[] args)
    {
        byte[] utf8Data = Encoding.UTF8.GetBytes(@"""2019-07-26T00:00:00""");

        Utf8JsonReader json = new Utf8JsonReader(utf8Data);
        while (json.Read())
        {
            if (json.TokenType == JsonTokenType.String)
            {
                Console.WriteLine(json.TryGetDateTime(out DateTime datetime));
                Console.WriteLine(datetime);
                Console.WriteLine(json.GetDateTime());
            }
        }
    }
}

// The example displays output similar to the following:
// True
// 7/26/2019 12:00:00 AM
// 7/26/2019 12:00:00 AM
