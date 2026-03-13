// <Program>
using GenerateMembersGenerator;

var person = new Person { FirstName = "Alice", LastName = "Smith", Age = 30 };

Console.WriteLine(person.Describe());
Console.WriteLine("Properties:");
foreach (string name in Person.PropertyNames)
{
    Console.WriteLine($"  {name}");
}

[GenerateMembers]
public partial class Person
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
}
// </Program>
