namespace SystemTextJsonSamples
{
    // <Person>
    public class Person
    {
        public string? Name { get; set; }
    }

    public class Customer : Person
    {
        public decimal CreditLimit { get; set; }
    }

    public class Employee : Person
    {
        public string? OfficeNumber { get; set; }
    }
    // </Person>

    public static class PersonExtensions
    {
        public static void DisplayPropertyValues(this Person person)
        {
            Utilities.DisplayPropertyValues(person);
            Console.WriteLine();
        }
    }

    public static class PersonFactories
    {
        public static List<Person> CreatePeople() =>
            new()
            {
                new Customer { CreditLimit = 10000, Name = "John" },
                new Employee { OfficeNumber = "555-1234", Name = "Nancy" }
            };
    }
}
