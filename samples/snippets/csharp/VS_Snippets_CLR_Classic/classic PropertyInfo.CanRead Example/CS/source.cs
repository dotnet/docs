// <Snippet1>
using System;
using System.Reflection;
 
// Define one readable property and one not readable.
public class Mypropertya
{
    private string caption = "A Default caption";
    public string Caption
    {
        get{return caption;}
        set {if(caption!=value) {caption = value;}
        }
    }
}
public class Mypropertyb
{
    private string caption = "B Default caption";
    public string Caption
    {
        set{if(caption!=value) {caption = value;}
        }
    }
}
  
class Mypropertyinfo
{
    public static int Main()
    {
        Console.WriteLine("\nReflection.PropertyInfo");
  
        // Define two properties.
        Mypropertya Mypropertya = new Mypropertya();
        Mypropertyb Mypropertyb = new Mypropertyb();
  
        Console.Write("\nMypropertya.Caption = " + Mypropertya.Caption);
        // Mypropertyb.Caption cannot be read, because
        // there is no get accessor.
  
        // Get the type and PropertyInfo.
        Type MyTypea = Type.GetType("Mypropertya");
        PropertyInfo Mypropertyinfoa = MyTypea.GetProperty("Caption");
        Type MyTypeb = Type.GetType("Mypropertyb");
        PropertyInfo Mypropertyinfob = MyTypeb.GetProperty("Caption");
  
        // Get and display the CanRead property.
        Console.Write("\nCanRead a - " + Mypropertyinfoa.CanRead);
        Console.Write("\nCanRead b - " + Mypropertyinfob.CanRead);
  
        return 0;
    }
}
// </Snippet1>

