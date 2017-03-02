// <Snippet6>
using System;

public class Employee : IComparable
{
    public String Name { get; set; }
    public int Id { get; set; }

    public int CompareTo(Object o)
    {
        var e = o as Employee;
        if (o == null)
        {
           throw new ArgumentException("o is not an Employee object.");
        }
        return Name.CompareTo(e.Name);
    }
}
// </Snippet6>

public class Example
{
    public static void Main()
    {
        var emp1 = new Employee() { Name = "John"};
        var emp2 = new Employee() { Name = "Jon" };
        Console.WriteLine(emp1.CompareTo(emp2));
    }
}
