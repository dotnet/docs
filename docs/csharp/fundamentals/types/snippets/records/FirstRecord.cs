namespace FirstRecord;

// <DeclareRecord>
public record Person(string FirstName, string LastName);
// </DeclareRecord>

// <RecordWithBody>
public record Product
{
    public required string Name { get; init; }
    public decimal Price { get; set; }
}
// </RecordWithBody>

// <RecordInheritance>
public record Student(string FirstName, string LastName, int GradeLevel)
    : Person(FirstName, LastName);
// </RecordInheritance>

public static class Program
{
    public static void Main()
    {
        // <UsingRecord>
        var person = new Person("Grace", "Hopper");
        Console.WriteLine(person);
        // Person { FirstName = Grace, LastName = Hopper }
        // </UsingRecord>

        // <Deconstruct>
        var (first, last) = person;
        Console.WriteLine($"{first} {last}");
        // Grace Hopper
        // </Deconstruct>

        var student = new Student("Grace", "Hopper", 12);
        Console.WriteLine(student);
        // Student { FirstName = Grace, LastName = Hopper, GradeLevel = 12 }
        Console.WriteLine(person == student); // False — different runtime types
    }
}
