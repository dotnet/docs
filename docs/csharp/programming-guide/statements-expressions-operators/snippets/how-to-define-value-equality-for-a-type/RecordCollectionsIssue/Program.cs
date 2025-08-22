namespace RecordCollectionsIssue;

// Records with reference-equality members don't work as expected
public record PersonWithHobbies(string Name, List<string> Hobbies);

// A potential solution using IEquatable<T> with custom equality
public record PersonWithHobbiesFixed(string Name, List<string> Hobbies) : IEquatable<PersonWithHobbiesFixed>
{
    public virtual bool Equals(PersonWithHobbiesFixed? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        
        // Use SequenceEqual for List comparison
        return Name == other.Name && Hobbies.SequenceEqual(other.Hobbies);
    }

    public override int GetHashCode()
    {
        // Create hash based on content, not reference
        var hashCode = new HashCode();
        hashCode.Add(Name);
        foreach (var hobby in Hobbies)
        {
            hashCode.Add(hobby);
        }
        return hashCode.ToHashCode();
    }
}

// These also use reference equality - the issue persists
public record PersonWithHobbiesArray(string Name, string[] Hobbies);

public record PersonWithHobbiesImmutable(string Name, IReadOnlyList<string> Hobbies);

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Records with Collections - The Problem ===");
        
        // Problem: Records with mutable collections use reference equality for the collection
        var person1 = new PersonWithHobbies("Alice", new List<string> { "Reading", "Swimming" });
        var person2 = new PersonWithHobbies("Alice", new List<string> { "Reading", "Swimming" });
        
        Console.WriteLine($"person1: {person1}");
        Console.WriteLine($"person2: {person2}");
        Console.WriteLine($"person1.Equals(person2): {person1.Equals(person2)}"); // False! Different List instances
        Console.WriteLine($"Lists have same content: {person1.Hobbies.SequenceEqual(person2.Hobbies)}"); // True
        Console.WriteLine();
        
        Console.WriteLine("=== Solution 1: Custom IEquatable Implementation ===");
        
        var personFixed1 = new PersonWithHobbiesFixed("Bob", new List<string> { "Cooking", "Hiking" });
        var personFixed2 = new PersonWithHobbiesFixed("Bob", new List<string> { "Cooking", "Hiking" });
        
        Console.WriteLine($"personFixed1: {personFixed1}");
        Console.WriteLine($"personFixed2: {personFixed2}");
        Console.WriteLine($"personFixed1.Equals(personFixed2): {personFixed1.Equals(personFixed2)}"); // True! Custom equality
        Console.WriteLine();
        
        Console.WriteLine("=== Arrays Also Use Reference Equality ===");
        
        var personArray1 = new PersonWithHobbiesArray("Charlie", new[] { "Gaming", "Music" });
        var personArray2 = new PersonWithHobbiesArray("Charlie", new[] { "Gaming", "Music" });
        
        Console.WriteLine($"personArray1: {personArray1}");
        Console.WriteLine($"personArray2: {personArray2}");
        Console.WriteLine($"personArray1.Equals(personArray2): {personArray1.Equals(personArray2)}"); // False! Arrays use reference equality too
        Console.WriteLine($"Arrays have same content: {personArray1.Hobbies.SequenceEqual(personArray2.Hobbies)}"); // True
        Console.WriteLine();
        
        Console.WriteLine("=== Same Issue with IReadOnlyList ===");
        
        var personImmutable1 = new PersonWithHobbiesImmutable("Diana", new[] { "Art", "Travel" });
        var personImmutable2 = new PersonWithHobbiesImmutable("Diana", new[] { "Art", "Travel" });
        
        Console.WriteLine($"personImmutable1: {personImmutable1}");
        Console.WriteLine($"personImmutable2: {personImmutable2}");
        Console.WriteLine($"personImmutable1.Equals(personImmutable2): {personImmutable1.Equals(personImmutable2)}"); // False! Reference equality
        Console.WriteLine($"Content is the same: {personImmutable1.Hobbies.SequenceEqual(personImmutable2.Hobbies)}"); // True
        Console.WriteLine();
        
        Console.WriteLine("=== Collection Behavior Summary ===");
        Console.WriteLine("Type                              | Equals Result | Reason");
        Console.WriteLine("----------------------------------|---------------|------------------");
        Console.WriteLine($"Record with List<T>               | {person1.Equals(person2),-13} | Reference equality");
        Console.WriteLine($"Record with custom IEquatable<T>  | {personFixed1.Equals(personFixed2),-13} | Custom equality logic");
        Console.WriteLine($"Record with Array                 | {personArray1.Equals(personArray2),-13} | Reference equality");
        Console.WriteLine($"Record with IReadOnlyList<T>      | {personImmutable1.Equals(personImmutable2),-13} | Reference equality");

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}

/* Expected Output:
=== Records with Collections - The Problem ===
person1: PersonWithHobbies { Name = Alice, Hobbies = System.Collections.Generic.List`1[System.String] }
person2: PersonWithHobbies { Name = Alice, Hobbies = System.Collections.Generic.List`1[System.String] }
person1.Equals(person2): False
Lists have same content: True

=== Solution 1: Custom IEquatable Implementation ===
personFixed1: PersonWithHobbiesFixed { Name = Bob, Hobbies = System.Collections.Generic.List`1[System.String] }
personFixed2: PersonWithHobbiesFixed { Name = Bob, Hobbies = System.Collections.Generic.List`1[System.String] }
personFixed1.Equals(personFixed2): True

=== Arrays Also Use Reference Equality ===
personArray1: PersonWithHobbiesArray { Name = Charlie, Hobbies = System.String[] }
personArray2: PersonWithHobbiesArray { Name = Charlie, Hobbies = System.String[] }
personArray1.Equals(personArray2): False
Arrays have same content: True

=== Same Issue with IReadOnlyList ===
personImmutable1: PersonWithHobbiesImmutable { Name = Diana, Hobbies = System.String[] }
personImmutable2: PersonWithHobbiesImmutable { Name = Diana, Hobbies = System.String[] }
personImmutable1.Equals(personImmutable2): False
Content is the same: True

=== Collection Behavior Summary ===
Type                              | Equals Result | Reason
----------------------------------|---------------|------------------
Record with List<T>               | False         | Reference equality
Record with custom IEquatable<T>  | True          | Custom equality logic
Record with Array                 | False         | Reference equality
Record with IReadOnlyList<T>      | False         | Reference equality
*/