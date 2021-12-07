using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializeIgnoreCycles
{
    public class Employee
    {
        public string? Name { get; set; }
        public Employee? Manager { get; set; }
        public List<Employee>? DirectReports { get; set; }
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
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            string tylerJson = JsonSerializer.Serialize(tyler, options);
            Console.WriteLine($"Tyler serialized:\n{tylerJson}");

            Employee? tylerDeserialized =
                JsonSerializer.Deserialize<Employee>(tylerJson, options);

            Console.WriteLine(
                "Tyler is manager of Tyler's first direct report: ");
            Console.WriteLine(
                tylerDeserialized?.DirectReports?[0]?.Manager == tylerDeserialized);
        }
    }
}

// Produces output like the following example:
//
//Tyler serialized:
//{
//  "Name": "Tyler Stein",
//  "Manager": null,
//  "DirectReports": [
//    {
//      "Name": "Adrian King",
//      "Manager": null,
//      "DirectReports": null
//    }
//  ]
//}
//Tyler is manager of Tyler's first direct report:
//False
