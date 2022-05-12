namespace SystemTextJsonSamples;

public class Program
{
    static void Main()
    {
        Console.WriteLine("\n============================= JsonNodeWithJsonSerializerOptions example\n");
        JsonNodeWithJsonSerializerOptions.Program.Main();
        Console.WriteLine("\n============================= JsonDocumentWithJsonSerializerOptions example\n");
        JsonDocumentWithJsonSerializerOptions.Program.Main();
        Console.WriteLine("\n============================= From string example\n");
        JsonNodeFromStringExample.Program.Main();
        Console.WriteLine("\n============================= From object example\n");
        JsonNodeFromObjectExample.Program.Main();
        Console.WriteLine("\n============================= POCO example\n");
        JsonNodePOCOExample.Program.Main();
        Console.WriteLine("\n============================= Average Grades example\n");
        JsonNodeAverageGradeExample.Program.Main();
        Console.WriteLine("\n============================= Write raw JSON\n");
        WriteRawJson.Program.Main();
    }
}
