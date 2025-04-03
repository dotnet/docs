// <Snippet5>
using System;

public class Person2
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        // This implementation handles a null obj argument.
        Person2 p = obj as Person2;
        if (p == null)
            return false;
        else
            return this.Name.Equals(p.Name);
    }
}

public class UsageErrorsEx2
{
    public static void Main()
    {
        Person2 p1 = new Person2();
        p1.Name = "John";
        Person2 p2 = null;

        Console.WriteLine($"p1 = p2: {p1.Equals(p2)}");
    }
}
// The example displays the following output:
//        p1 = p2: False
// </Snippet5>
