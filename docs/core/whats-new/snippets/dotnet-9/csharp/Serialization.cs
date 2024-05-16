using System;
using System.Text.Json;

internal class Serialization
{
    public static void RunIt()
    {
        // <Indentation>
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IndentCharacter = '\t',
            IndentSize = 2,
        };

        string json = JsonSerializer.Serialize(
            new { Value = 1 },
            options
            );
        Console.WriteLine(json);
        //{
        //                "Value": 1
        //}
        // </Indentation>

        // <Web>
        string webJson = JsonSerializer.Serialize(
            new { SomeValue = 42 },
            JsonSerializerOptions.Web // Defaults to camelCase naming policy.
            );
        Console.WriteLine(webJson);
        // {"someValue":42}
        // </Web>
    }
}
