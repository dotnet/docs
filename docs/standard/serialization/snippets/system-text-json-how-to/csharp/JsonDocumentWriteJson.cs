using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class JsonDocumentWriteJson
    {
        public static void Run()
        {
            string inputFileName = "Grades.json";
            string outputFileName = "GradesOutput.json";

            // <Serialize>
            string jsonString = File.ReadAllText(inputFileName);

            var writerOptions = new JsonWriterOptions
            {
                Indented = true
            };

            var documentOptions = new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip
            };

            using FileStream fs = File.Create(outputFileName);
            using var writer = new Utf8JsonWriter(fs, options: writerOptions);
            using JsonDocument document = JsonDocument.Parse(jsonString, documentOptions);

            JsonElement root = document.RootElement;

            if (root.ValueKind == JsonValueKind.Object)
            {
                writer.WriteStartObject();
            }
            else
            {
                return;
            }

            foreach (JsonProperty property in root.EnumerateObject())
            {
                property.WriteTo(writer);
            }

            writer.WriteEndObject();

            writer.Flush();
            // </Serialize>
            Console.WriteLine($"Output file is {outputFileName}");
        }
    }
}
