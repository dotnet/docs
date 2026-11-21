namespace EqualityTest;

public record Person(string FirstName, string LastName);
public record Contact(string FirstName, string LastName, string[] PhoneNumbers);

public static class Program
{
    public static void Main()
    {
        // <EqualityTest>
        var person1 = new Person("Grace", "Hopper");
        var person2 = new Person("Grace", "Hopper");

        Console.WriteLine(person1 == person2);                // True
        Console.WriteLine(ReferenceEquals(person1, person2)); // False
        // </EqualityTest>

        // <CollectionEquality>
        var phones1 = new string[] { "555-1234" };
        var phones2 = new string[] { "555-1234" };

        var contact1 = new Contact("Grace", "Hopper", phones1);
        var contact2 = new Contact("Grace", "Hopper", phones2);

        // False: array properties compare by reference, not by element contents
        Console.WriteLine(contact1 == contact2);
        // </CollectionEquality>
    }
}
