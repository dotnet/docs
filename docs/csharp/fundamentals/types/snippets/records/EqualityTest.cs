namespace EqualityTest;

public record Person(string FirstName, string LastName, string[] PhoneNumbers);

public static class Program
{
    public static void Main()
    {
        // <EqualityTest>
        // Person is a record type with three properties: FirstName, LastName, and PhoneNumbers.
        var phones = new string[] { "555-1234" };
        var person1 = new Person("Grace", "Hopper", phones);
        var person2 = new Person("Grace", "Hopper", phones);

        Console.WriteLine(person1 == person2);              // True
        Console.WriteLine(ReferenceEquals(person1, person2)); // False

        person1.PhoneNumbers[0] = "555-9999";
        Console.WriteLine(person2.PhoneNumbers[0]); // 555-9999 — same array
        // </EqualityTest>
    }
}
