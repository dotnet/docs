using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class RoundtripPolymorphic
    {
        public static void Run()
        {
            string jsonString;
            var people = PersonFactories.CreatePeople();
            people.ForEach(p => p.DisplayPropertyValues());

            // <SnippetRegister>
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new PersonConverterWithTypeDiscriminator());
            // </SnippetRegister>
            serializeOptions.WriteIndented = true;
            jsonString = JsonSerializer.Serialize(people, serializeOptions);
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SnippetDeserialize>
            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new PersonConverterWithTypeDiscriminator());
            people = JsonSerializer.Deserialize<List<Person>>(jsonString, deserializeOptions);
            // </SnippetDeserialize>
            people.ForEach(p => p.DisplayPropertyValues());
        }
    }
}
