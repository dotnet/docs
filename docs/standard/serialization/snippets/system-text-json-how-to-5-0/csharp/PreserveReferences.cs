using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PreserveReferences
{
    public class Employee
    {
        public string Name { get; set; }
        public Employee Manager { get; set; }
        public List<Employee> DirectReports { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            Employee tyler = new()
            {
                Name = "Tyler Stein"
            };

            Employee adrian = new()
            {
                Name = "Adrian King"
            };

            tyler.DirectReports = new List<Employee> { adrian };
            adrian.Manager = tyler;

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            string tylerJson = JsonSerializer.Serialize(tyler, options);
            Console.WriteLine($"Hayden Cook serialized:\n{tylerJson}");

            Employee tylerDeserialized =
                JsonSerializer.Deserialize<Employee>(tylerJson, options);
            Console.WriteLine("Tyler is the manager of Tyler's first direct report: ");
            Console.WriteLine(
                tylerDeserialized.DirectReports[0].Manager == tylerDeserialized);
        }
    }
}
