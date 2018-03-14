// <Snippet1>
using System;
using System.Reflection;


 // Make two fields.
public
    class Myfielda // private
{
    private string SomeField = "private field";
    public string Field
    {
        get{return SomeField;}
    }
}

public
    class Myfieldb // public
{
    public string SomeField = "public field";
}
 
public
    class Myfieldinfo
{
    public static int Main()
    {
        Console.WriteLine("\nReflection.FieldInfo");
        Myfielda Myfielda = new Myfielda();
        Myfieldb Myfieldb = new Myfieldb();
  
        // Get the Type and FieldInfo.
        Type MyTypea = typeof(Myfielda);
        FieldInfo Myfieldinfoa = MyTypea.GetField("SomeField", 
            BindingFlags.NonPublic|BindingFlags.Instance);
        Type MyTypeb = typeof(Myfieldb);
        FieldInfo Myfieldinfob = MyTypeb.GetField("SomeField");
  
        // Get and display the IsPublic and IsPrivate property values.
        Console.Write("\n{0}.", MyTypea.FullName);
        Console.Write("{0} - ", Myfieldinfoa.Name);
        Console.Write("{0}", Myfielda.Field);
        Console.Write("\n   IsPublic = {0}", Myfieldinfoa.IsPublic);
        Console.Write("\n   IsPrivate = {0}", Myfieldinfoa.IsPrivate);
  
        Console.Write("\n{0}.", MyTypeb.FullName);
        Console.Write("{0} - ", Myfieldinfob.Name);
        Console.Write("{0};", Myfieldb.SomeField);
        Console.Write("\n   IsPublic = {0}", Myfieldinfob.IsPublic);
        Console.Write("\n   IsPrivate = {0}", Myfieldinfob.IsPrivate);
  
        return 0;
    }
}
// </Snippet1>

