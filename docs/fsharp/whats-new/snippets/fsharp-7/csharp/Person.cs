// <InitOnlyPerson>
public sealed class Person
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Person Set() => this;
}
// </InitOnlyPerson>
