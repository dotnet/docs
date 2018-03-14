// <Snippet1>

using System;
using System.Reflection;

 //Make two fields, one public and one read-only.
public class Myfielda
{
    public string field = "A - public modifiable field";
}
public class Myfieldb
{
    public readonly string field = "B - readonly field";
}
 
public class Myfieldinfo
{
    public static int Main()
    {
        Console.WriteLine("\nReflection.FieldInfo");
        Myfielda Myfielda = new Myfielda();
        Myfieldb Myfieldb = new Myfieldb();
  
        //Get the Type and FieldInfo.
        Type MyTypea = typeof(Myfielda);
        FieldInfo Myfieldinfoa = MyTypea.GetField("field",
            BindingFlags.Public | BindingFlags.Instance);
        Type MyTypeb = typeof(Myfieldb);
        FieldInfo Myfieldinfob = MyTypeb.GetField("field",
            BindingFlags.Public | BindingFlags.Instance);
  
        //Modify the fields.
        //Note that Myfieldb is not modified, as it is
        //read-only (IsInitOnly is True).
        Myfielda.field = "A - modified";
        //Myfieldb.field = "B - modified";
  
        //For the first field, get and display the name, field, and IsInitOnly state.
        Console.Write("\n{0} - {1}, IsInitOnly = {2} ",
            MyTypea.FullName,
            Myfieldinfoa.GetValue(Myfielda),
            Myfieldinfoa.IsInitOnly);
  
        //For the second field get and display the name, field, and IsInitOnly state.
        Console.Write("\n{0} - {1}, IsInitOnly = {2} ",
            MyTypeb.FullName,
            Myfieldinfob.GetValue(Myfieldb),
            Myfieldinfob.IsInitOnly);
  
        return 0;
    }
}
// </Snippet1>

