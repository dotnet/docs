// <Snippet1>
using System;
using System.Reflection;
 
 // Define one writable property and one not writable.
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
        get{return caption;}
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
  
        // Read and display the property.
        Console.Write("\nMypropertya.Caption = " + Mypropertya.Caption);
        Console.Write("\nMypropertyb.Caption = " + Mypropertyb.Caption);
  
        // Write to the property.
        Mypropertya.Caption = "A- No Change";
        // Mypropertyb.Caption cannot be written to because
        // there is no set accessor.
  
        // Read and display the property.
        Console.Write("\nMypropertya.Caption = " + Mypropertya.Caption);
        Console.Write ("\nMypropertyb.Caption = " + Mypropertyb.Caption);
  
        // Get the type and PropertyInfo.
        Type MyTypea = Type.GetType("Mypropertya");
        PropertyInfo Mypropertyinfoa = MyTypea.GetProperty("Caption");
        Type MyTypeb = Type.GetType("Mypropertyb");
        PropertyInfo Mypropertyinfob = MyTypeb.GetProperty("Caption");
  
        // Get and display the CanWrite property.
      
        Console.Write("\nCanWrite a - " + Mypropertyinfoa.CanWrite);
      
        Console.Write("\nCanWrite b - " + Mypropertyinfob.CanWrite);
  
        return 0;
    }
}
// </Snippet1>

