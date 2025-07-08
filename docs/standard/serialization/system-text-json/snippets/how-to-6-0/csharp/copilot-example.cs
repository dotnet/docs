using System.Text.Json;

public class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }
}

public class Program
{
    public static void Main()
    {
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            Country = "USA"
        };

        string jsonString = JsonSerializer.Serialize(person);
        Console.WriteLine(jsonString);
    }
}
