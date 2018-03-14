// <Snippet1>
using System;
using System.Reflection;
 
// A class that contains some properties.
public class MyProperty   
{
    // Define a simple string property.
    private string caption = "A Default caption";
    public string Caption
    {
        get{return caption;}
        set {if(caption!=value) {caption = value;}
        }
    }

    // A very limited indexer that gets or sets one of four 
    // strings.
    private string[] strings = {"abc", "def", "ghi", "jkl"};
    public string this[int Index]    
    {
        get
        {
            return strings[Index];
        }
        set
        {
            strings[Index] = value;
        }
    }
}
 
class Mypropertyinfo
{
    public static int Main()
    {
        // Get the type and PropertyInfo.
        Type t = Type.GetType("MyProperty");
        PropertyInfo pi = t.GetProperty("Caption");
 
        // Get the public GetIndexParameters method.
        ParameterInfo[] parms = pi.GetIndexParameters();
        Console.WriteLine("\r\n" + t.FullName + "." + pi.Name
            + " has " + parms.GetLength(0) + " parameters.");
 
        // Display a property that has parameters. The default 
        // name of an indexer is "Item".
        pi = t.GetProperty("Item");
        parms = pi.GetIndexParameters();
        Console.WriteLine(t.FullName + "." + pi.Name + " has " + 
            parms.GetLength(0) + " parameters.");
        foreach( ParameterInfo p in parms )
        {
            Console.WriteLine("   Parameter: " + p.Name);
        }

        return 0;
    }
}
/*
 This example produces the following output:
 MyProperty.Caption has 0 parameters.
 MyProperty.Item has 1 parameters.
    Parameter: Index
 */
// </Snippet1>

