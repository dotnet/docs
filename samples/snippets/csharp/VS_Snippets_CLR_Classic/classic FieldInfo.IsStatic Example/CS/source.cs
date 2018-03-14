// <Snippet1>
using System;
using System.Reflection;

 // Make two fields.
public class Myfielda
{
    private string field = "A private field";
    public string Field
    {
        get{return field;}
        set{if(field!=value){field=value;}}
    }
}
public class Myfieldb
{
    static string field = "B private static field";
    public string Field 
    {
        get{return field;}
        set{if(field!=value){field=value;}}
    }
}
  
public class Myfieldinfo
{
    public static int Main()
    {
        Console.WriteLine("\nReflection.FieldInfo");
        Myfielda Myfielda = new Myfielda();
        Myfieldb Myfieldb = new Myfieldb();
  
        // Get the Type and FieldInfo.
        Type MyTypea = typeof(Myfielda);
        FieldInfo Myfieldinfoa = MyTypea.GetField("field", BindingFlags.NonPublic|BindingFlags.Instance);
        Type MyTypeb = typeof(Myfieldb);
        FieldInfo Myfieldinfob = MyTypeb.GetField("field", BindingFlags.NonPublic|BindingFlags.Static);
  
        // For the first field, get and display the name, field, and IsStatic property value.
        Console.Write("\n{0} - ", MyTypea.FullName);
        Console.Write("{0}; ", Myfieldinfoa.GetValue(Myfielda));
        Console.Write("IsStatic - {0}", Myfieldinfoa.IsStatic);
  
        // For the second field get and display the name, field, and IsStatic property value.
        Console.Write("\n{0} - ", MyTypeb.FullName);
        Console.Write("{0}; ", Myfieldinfob.GetValue(Myfieldb));
        Console.Write("IsStatic - {0}", Myfieldinfob.IsStatic);
  
        return 0;
    }
}
// </Snippet1>

