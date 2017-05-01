// <Snippet1>
using System;
using System.Reflection;
 
 // Define three properties: one read-write, one default,
 // and one read only. 
public class Aproperty  
    // Define a read-write property.
{
    private string caption = "A Default caption";
    public string Caption
    {
        get{return caption;}
        set
        {
            if (caption != value){caption = value;}
        }
    }
}
public class Bproperty  
    // Define a default property.
{
    private string caption  = "B Default caption";
    public string this [int index]
    {
        get {return "1";}
    }
    public string Caption
    {
  
        get{return caption;}
        set
        {
            if (caption != value){caption = value;}
        }
    }
}
public class Cproperty  
    // Define a read-only property.
{
    private string caption = "C Default caption";
    public string Caption
    {
        get{return caption;}
        // No setting is allowed, because this is a read-only property.
    }
}
  
class propertyattributesenum
{
    public static int Main(string[] args)
    {
        Console.WriteLine("\nReflection.PropertyAttributes");
  
        // Determine whether a property exists, and change its value.
        Aproperty Mypropertya = new Aproperty();
        Bproperty Mypropertyb = new Bproperty();
        Cproperty Mypropertyc = new Cproperty();
  
      
        Console.Write("\n1. Mypropertya.Caption = " + Mypropertya.Caption );
      
        Console.Write("\n1. Mypropertyb.Caption = " + Mypropertyb.Caption );
      
        Console.Write("\n1. Mypropertyc.Caption = " + Mypropertyc.Caption );
  
        // Only Mypropertya can be changed, as Mypropertyb is read-only.
        Mypropertya.Caption = "A- This is changed.";
        Mypropertyb.Caption = "B- This is changed.";
        // Note that Mypropertyc is not changed because it is read only
  
        Console.Write("\n\n2. Mypropertya.Caption = " + Mypropertya.Caption );
  
        Console.Write("\n2. Mypropertyb.Caption = " + Mypropertyb.Caption );
 
        Console.Write("\n2. Mypropertyc.Caption = " + Mypropertyc.Caption );
  
        // Get the PropertyAttributes enumeration of the property.
        // Get the type.
        Type MyTypea = Type.GetType("Aproperty");
        Type MyTypeb = Type.GetType("Bproperty");
        Type MyTypec = Type.GetType("Cproperty");
  
        // Get the property attributes.
        PropertyInfo Mypropertyinfoa = MyTypea.GetProperty("Caption");
        PropertyAttributes Myattributesa = Mypropertyinfoa.Attributes;
        PropertyInfo Mypropertyinfob = MyTypeb.GetProperty("Item");
        PropertyAttributes Myattributesb = Mypropertyinfob.Attributes;
        PropertyInfo Mypropertyinfoc = MyTypec.GetProperty("Caption");
        PropertyAttributes Myattributesc = Mypropertyinfoc.Attributes;
  
        // Display the property attributes value.
      
        Console.Write("\n\na- " + Myattributesa.ToString());

        Console.Write("\nb- " + Myattributesb.ToString());

        Console.Write("\nc- " + Myattributesc.ToString());
        return 0;
    }
}

// This example displays the following output to the console
//
// Reflection.PropertyAttributes
//
// 1. Mypropertya.Caption = A Default caption
// 1. Mypropertyb.Caption = B Default caption
// 1. Mypropertyc.Caption = C Default caption
//
// 2. Mypropertya.Caption = A- This is changed.
// 2. Mypropertyb.Caption = B- This is changed.
// 2. Mypropertyc.Caption = C Default caption
//
// a- None
// b- None
// c- None
// </Snippet1>

