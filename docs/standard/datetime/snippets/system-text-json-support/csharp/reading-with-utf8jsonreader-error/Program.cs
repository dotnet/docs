using System;
using System.Text;
using System.Text.Json;

public class Example
{
    public static void Main(string[] args)
    {
        byte[] utf8Data = Encoding.UTF8.GetBytes(@"""2019/07/26 00:00:00""");

        Utf8JsonReader json = new Utf8JsonReader(utf8Data);
        while (json.Read())
        {
            if (json.TokenType == JsonTokenType.String)
            {
                Console.WriteLine(json.TryGetDateTime(out DateTime datetime));
                Console.WriteLine(datetime);

                DateTime _ = json.GetDateTime();
            }
        }
    }
}

// The example displays the following output:
// False
// 1/1/0001 12:00:00 AM
// Unhandled exception. System.FormatException: The JSON value is not in a supported DateTime format.
//     at System.Text.Json.Utf8JsonReader.GetDateTime()
