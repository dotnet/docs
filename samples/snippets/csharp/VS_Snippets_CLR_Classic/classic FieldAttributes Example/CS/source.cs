// Updated for 406827 REDMOND\glennha
// <Snippet1>
using System;
using System.Reflection;

public class Demo
{
    // Make three fields:
    // The first field is private.
    private string m_field = "String A";

    // The second field is public.
    public string Field = "String B";

    // The third field is public const (hence also literal and static),
    // with a default value.
    public const string FieldC = "String C";
}

public class Myfieldattributes
{
    public static void Main()
    {
        Console.WriteLine ("\nReflection.FieldAttributes");
        Demo d = new Demo();
 
        // Get a Type object for Demo, and a FieldInfo for each of
        // the three fields. Use the FieldInfo to display field
        // name, value for the Demo object in d, and attributes.
        //
        Type myType = typeof(Demo);
        FieldInfo fiPrivate = myType.GetField("m_field",
            BindingFlags.NonPublic | BindingFlags.Instance);
        DisplayField(d, fiPrivate);

        FieldInfo fiPublic = myType.GetField("Field",
            BindingFlags.Public | BindingFlags.Instance);
        DisplayField(d, fiPublic);

        FieldInfo fiConstant = myType.GetField("FieldC",
            BindingFlags.Public | BindingFlags.Static);
        DisplayField(d, fiConstant);
    }

    static void DisplayField(Object obj, FieldInfo f)
    { 
        // Display the field name, value, and attributes.
        //
        Console.WriteLine("{0} = \"{1}\"; attributes: {2}", 
            f.Name, f.GetValue(obj), f.Attributes);
    }
}

/* This code example produces the following output:

Reflection.FieldAttributes
m_field = "String A"; attributes: Private
Field = "String B"; attributes: Public
FieldC = "String C"; attributes: Public, Static, Literal, HasDefault
 */
// </Snippet1>

