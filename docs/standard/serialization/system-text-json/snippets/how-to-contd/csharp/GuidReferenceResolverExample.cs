using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GuidReferenceResolverExample
{
    public class Person
    {
        internal Guid Id { get; set; }
        public string? Name { get; set; }
        public Person? Spouse { get; set; }
    }

    public class GuidReferenceResolver : ReferenceResolver
    {
        private readonly IDictionary<Guid, Person> _people = new Dictionary<Guid, Person>();

        public override object ResolveReference(string referenceId)
        {
            Guid id = new(referenceId);

            _people.TryGetValue(id, out Person? p);

            return p!;
        }

        public override string GetReference(object? value, out bool alreadyExists)
        {
            Person person = (Person)value!;

            if (!(alreadyExists = _people.ContainsKey(person.Id)))
            {
                _people[person.Id] = person;
            }

            return person.Id.ToString()!;
        }

        public override void AddReference(string reference, object value)
        {
            Guid id = new(reference);
            Person person = (Person)value;
            person.Id = id;
            _people[id] = person;
        }
    }

    static class Program
    {
        public static void Run()
        {
            Person tyler = new() { Id = Guid.NewGuid(), Name = "Tyler" };
            Person adrian = new() { Id = Guid.NewGuid(), Name = "Adrian" };
            tyler.Spouse = adrian;
            adrian.Spouse = tyler;
            var people = ImmutableArray.Create(tyler, adrian);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = new ReferenceHandler<GuidReferenceResolver>()
            };

            string json = JsonSerializer.Serialize(people, options);
            Console.WriteLine($"Output JSON {json}");

            List<Person> peopleDeserialized =
                JsonSerializer.Deserialize<List<Person>>(json, options)!;

            Person tylerDeserialized = peopleDeserialized[0];
            Person adrianDeserialized = peopleDeserialized[1];

            Console.WriteLine($"Adrian is Tyler's spouse: {tylerDeserialized.Equals(adrianDeserialized.Spouse)}");
            Console.WriteLine($"Tyler is Adrian's spouse: {adrianDeserialized.Equals(tylerDeserialized.Spouse)}");
        }
    }
}

// Produces output like the following example:
//
//Output JSON[
//  {
//    "$id": "79301726-9d94-499a-8cdc-0c8bcc4c9b63",
//    "Name": "Tyler",
//    "Spouse": {
//      "$id": "94833059-35f2-4fdd-96ee-94fd0484969a",
//      "Name": "Adrian",
//      "Spouse": {
//        "$ref": "79301726-9d94-499a-8cdc-0c8bcc4c9b63"
//      }
//  }
//  },
//  {
//    "$ref": "94833059-35f2-4fdd-96ee-94fd0484969a"
//  }
//]
//Adrian is Tyler's spouse: True
//Tyler is Adrian's spouse: True
