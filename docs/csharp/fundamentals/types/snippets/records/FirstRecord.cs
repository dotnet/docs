namespace FirstRecord;

// <FirstRecord>

public record Person(string FirstName, string LastName);

public static class Program
{
    public static void Main()
    {
        Person person = new("Nancy", "Davolio");
        Console.WriteLine(person);
        // output: Person { FirstName = Nancy, LastName = Davolio }
    }

}
// </FirstRecord>
