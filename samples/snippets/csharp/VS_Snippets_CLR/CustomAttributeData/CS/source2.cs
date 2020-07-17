// <snippet2>
using System;

public class ExampleAttribute : Attribute
{
    private string stringVal;

    public ExampleAttribute()
    {
        stringVal = "This is the default string.";
    }

    public string StringValue
    {
        get { return stringVal; }
        set { stringVal = value; }
    }
}

[Example(StringValue="This is a string.")]
class Class1
{
    public static void Main()
    {
        System.Reflection.MemberInfo info = typeof(Class1);
        foreach (object attrib in info.GetCustomAttributes(true))
        {
            Console.WriteLine(attrib);
        }
    }
}
// </snippet2>
