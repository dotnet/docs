// <Snippet3>
using System;
using System.Reflection;
using System.Runtime.Remoting;

public class Example
{
   public static void Main()
   {
      ObjectHandle handle = Activator.CreateInstance("PersonInfo", "Person");
      Object p = handle.Unwrap();
      Type t = p.GetType();
      PropertyInfo prop = t.GetProperty("Name");
      if (prop != null)
         prop.SetValue(p, "Samuel");

      MethodInfo method = t.GetMethod("ToString");
      Object retVal = method.Invoke(p, null); 
      if (retVal != null)
         Console.WriteLine(retVal);
   }
}
// The example displays the following output:
//        Samuel
// </Snippet3>
