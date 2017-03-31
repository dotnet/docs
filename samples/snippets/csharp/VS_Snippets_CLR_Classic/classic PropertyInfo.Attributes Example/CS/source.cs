// <Snippet1>
using System;
using System.Reflection;
 
public class Myproperty
{
    private string caption = "Default caption";
    public string Caption
    {
        get{ return caption; }
        set { if(caption!=value) {caption = value;} }
    }
}
  
class Mypropertyinfo
{
    public static int Main(string[] args)
    {
        Console.WriteLine("\nReflection.PropertyInfo");
  
        // Define a property.
        Myproperty Myproperty = new Myproperty();
        Console.Write("\nMyproperty.Caption = " + Myproperty.Caption);
  
        // Get the type and PropertyInfo.
        Type MyType = Type.GetType("Myproperty");
        PropertyInfo Mypropertyinfo = MyType.GetProperty("Caption");
  
        // Get and display the attributes property.
        PropertyAttributes Myattributes = Mypropertyinfo.Attributes;
      
        Console.Write("\nPropertyAttributes - " + Myattributes.ToString());
  
        return 0;
    }
}
// The example displays the following output:
//       Reflection.PropertyInfo
//
//       Myproperty.Caption = Default caption
//       PropertyAttributes - None
// </Snippet1>

