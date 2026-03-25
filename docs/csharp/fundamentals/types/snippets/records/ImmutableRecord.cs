namespace ImmutableRecord;

public record Person(string FirstName, string LastName);

public class Program
{
    public static void Main()
    {
        // <WithExpression>
        var original = new Person("Grace", "Hopper");
        var modified = original with { FirstName = "Margaret" };

        Console.WriteLine(original); // Person { FirstName = Grace, LastName = Hopper }
        Console.WriteLine(modified); // Person { FirstName = Margaret, LastName = Hopper }
        Console.WriteLine(original == modified); // False

        var copy = original with { };
        Console.WriteLine(original == copy); // True
        // </WithExpression>
    }
}