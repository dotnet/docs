using System;

public class Person
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Person(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }

    public string AllCaps()
    {
        FirstName = FirstName.ToUpper();
        LastName = LastName.ToUpper();
        return ToString();
    }
}

public class Program
{
    public static void Main()
    {
        var p = new Person("Bill", "Wagner");
        Console.WriteLine("The name, in all caps: " + p.AllCaps());
        Console.WriteLine("The name: " + p);
    }
}
