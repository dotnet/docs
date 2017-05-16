// <Snippet1>
using System;
using System.Reflection;
 
// Define a property.
public class ClassWithProperty
{
    private string _caption = "A Default caption";

    public string Caption
    {
        get { return _caption; }
        set { if(_caption != value) _caption = value; }
    }
}
 
class Example
{
    public static void Main()
    {
        ClassWithProperty test = new ClassWithProperty();
        Console.WriteLine("The Caption property: {0}", test.Caption);
        Console.WriteLine("----------");
        // Get the type and PropertyInfo.
        Type t = Type.GetType("ClassWithProperty");
        PropertyInfo propInfo = t.GetProperty("Caption");
 
        // Get the public GetAccessors method.
        MethodInfo[] methInfos = propInfo.GetAccessors();
        Console.WriteLine("There are {0} accessors.",
                          methInfos.Length);
        for(int ctr = 0; ctr < methInfos.Length; ctr++) {
           MethodInfo m = methInfos[ctr];
           Console.WriteLine("Accessor #{0}:", ctr + 1);
           Console.WriteLine("   Name: {0}", m.Name);
           Console.WriteLine("   Visibility: {0}", GetVisibility(m));
           Console.Write("   Property Type: ");
           // Determine if this is the property getter or setter.
           if (m.ReturnType == typeof(void)) {
              Console.WriteLine("Setter");
              Console.WriteLine("   Setting the property value.");
              //  Set the value of the property.
              m.Invoke(test, new object[] { "The Modified Caption" } );
           }
           else {
              Console.WriteLine("Getter");
              // Get the value of the property.
              Console.WriteLine("   Property Value: {0}",
                                m.Invoke(test, new object[] {} ));
           }
        }
        Console.WriteLine("----------");
        Console.WriteLine("The Caption property: {0}", test.Caption);
    }

    static string GetVisibility(MethodInfo m)
    {
       string visibility = "";
       if (m.IsPublic)
          return "Public";
       else if (m.IsPrivate)
          return "Private";
       else
          if (m.IsFamily)
             visibility = "Protected ";
          else if (m.IsAssembly)
             visibility += "Assembly";
       return visibility;
    }
}
// The example displays the following output:
//       The Caption property: A Default caption
//       ----------
//       There are 2 accessors.
//       Accessor #1:
//          Name: get_Caption
//          Visibility: Public
//          Property Type: Getter
//          Property Value: A Default caption
//       Accessor #2:
//          Name: set_Caption
//          Visibility: Public
//          Property Type: Setter
//          Setting the property value.
//       ----------
//       The Caption property: The Modified Caption
// </Snippet1>

