using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripPolymorphic
    {
        public static void Run()
        {
            string jsonString;
            var people = PersonFactories.CreatePeople();
            people.ForEach(p => p.DisplayPropertyValues());

            // <Register>
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new PersonConverterWithTypeDiscriminator());
            // </Register>
            serializeOptions.WriteIndented = true;
            jsonString = JsonSerializer.Serialize(people, serializeOptions);
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <Deserialize>
            var deserializeOptions = new JsonSerializerOptions
            {
                Converters =
                {
                    new PersonConverterWithTypeDiscriminator()
                }
            };
            people = JsonSerializer.Deserialize<List<Person>>(jsonString, deserializeOptions);
            // </Deserialize>
            people.ForEach(p => p.DisplayPropertyValues());

            // <DeserializeAlt>
            deserializeOptions = new JsonSerializerOptions
            {
                Converters =
                {
                    new PersonConverterWithTypeDiscriminatorAlt ()
                }
            };
            people = JsonSerializer.Deserialize<List<Person>>(jsonString, deserializeOptions);
            // </DeserializeAlt>
            people.ForEach(p => p.DisplayPropertyValues());
        }
    }
}
