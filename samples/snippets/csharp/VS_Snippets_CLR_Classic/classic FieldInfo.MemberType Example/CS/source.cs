// <Snippet1>
using System;
using System.Reflection;
 
// Make a field.
public class Myfield
{
    private string field = "a private field";
    public string Field
    {
        get{return field;}
    }
}
  
public class Myfieldinfo
{
    public static int Main()
    {
        Console.WriteLine ("\nReflection.FieldInfo");
        Myfield Myfield = new Myfield();
  
        // Get the Type and FieldInfo.
        Type MyType = typeof(Myfield);
        FieldInfo Myfieldinfo = MyType.GetField("field", BindingFlags.NonPublic|BindingFlags.Instance);
  
        // Get and display the MemberType.
        Console.Write ("\n{0}.", MyType.FullName);
        Console.Write ("{0} - ", Myfieldinfo.Name);
        Console.Write ("{0};", Myfield.Field);
        MemberTypes Mymembertypes = Myfieldinfo.MemberType;
        Console.Write("MemberType is a {0}.", Mymembertypes.ToString());
        return 0;
    }
}
// </Snippet1>

