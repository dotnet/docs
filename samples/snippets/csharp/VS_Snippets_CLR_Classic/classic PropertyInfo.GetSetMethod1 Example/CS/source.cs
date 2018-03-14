// <Snippet1>
using System;
using System.Reflection;
 
// Define a property.
public class Myproperty   
{
    private string caption = "A Default caption";
    public string Caption
    {
        get{return caption;}
        set {if(caption!=value) {caption = value;}
        }
    }
}
 
class Mypropertyinfo
{
    public static int Main()
    {
        Console.WriteLine ("\nReflection.PropertyInfo");
 
        // Get the type and PropertyInfo for two separate properties.
        Type MyTypea = Type.GetType("Myproperty");
        PropertyInfo Mypropertyinfoa = MyTypea.GetProperty("Caption");
        Type MyTypeb = Type.GetType("System.Text.StringBuilder");
        PropertyInfo Mypropertyinfob = MyTypeb.GetProperty("Length");
        // Get and display the GetSetMethod method for each property.
        MethodInfo Mygetmethodinfoa = Mypropertyinfoa.GetSetMethod();
        Console.Write ("\nSetAccessor for " + Mypropertyinfoa.Name
            + " returns a " + Mygetmethodinfoa.ReturnType);
        MethodInfo Mygetmethodinfob = Mypropertyinfob.GetSetMethod();
        Console.Write ("\nSetAccessor for " + Mypropertyinfob.Name
            + " returns a " + Mygetmethodinfob.ReturnType);
 
        // Display the GetSetMethod without using the MethodInfo.
        Console.Write ("\n\n" + MyTypea.FullName + "."
            + Mypropertyinfoa.Name + " GetSetMethod - "
            + Mypropertyinfoa.GetSetMethod());
        Console.Write ("\n" + MyTypeb.FullName + "."
            + Mypropertyinfob.Name + " GetSetMethod - "
            + Mypropertyinfob.GetSetMethod());
        return 0;
    }
}
// </Snippet1>

