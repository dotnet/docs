using System;

public class Equality
{
    public static void EqualityTest()
    {
        //<Snippet32>
        // Person is defined in the previous example.

        //public struct Person(string name, int age)
        //{
        //    public string Name { get; set; } = name;
        //    public int Age { get; set; } = age;
        //}

        Person p1 = new("Wallace", 75);
        Person p2 = new("", 42);
        p2.Name = "Wallace";
        p2.Age = 75;

        if (p2.Equals(p1))
            Console.WriteLine("p2 and p1 have the same values.");

        // Output: p2 and p1 have the same values.
        //</Snippet32>
    }
}
