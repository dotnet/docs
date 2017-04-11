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
        Type MyTypeb = Type.GetType("System.Reflection.MethodInfo");
        PropertyInfo Mypropertyinfob = MyTypeb.GetProperty("MemberType");
 
        // Get and display the GetGetMethod method for each property.
        MethodInfo Mygetmethodinfoa = Mypropertyinfoa.GetGetMethod();
        Console.Write ("\nGetAccessor for " + Mypropertyinfoa.Name
            + " returns a " + Mygetmethodinfoa.ReturnType);
        MethodInfo Mygetmethodinfob = Mypropertyinfob.GetGetMethod();
        Console.Write ("\nGetAccessor for " + Mypropertyinfob.Name
            + " returns a " + Mygetmethodinfob.ReturnType);
 
        // Display the GetGetMethod without using the MethodInfo.
        Console.Write ("\n" + MyTypea.FullName + "." + Mypropertyinfoa.Name
            + " GetGetMethod - " + Mypropertyinfoa.GetGetMethod());
        Console.Write ("\n" + MyTypeb.FullName + "." + Mypropertyinfob.Name
            + " GetGetMethod - " + Mypropertyinfob.GetGetMethod());
        return 0;
    }
}
// </Snippet1>

