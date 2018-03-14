// <Snippet2>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      // Use reflection to get a reference to the GetCalendarName method.
      Assembly assem = Assembly.LoadFrom(@".\Example.dll");
      Type type = assem.GetType("Utility");
      MethodInfo methodInfo = type.GetMethod("GetCalendarName");
      
      // Determine whether the method has any custom attributes.
      Console.Write("Utility.GetCalendarName custom attributes:");
      object[] attribs = methodInfo.GetCustomAttributes(false);
      if (attribs.Length > 0) {
         Console.WriteLine();
         foreach (var attrib in attribs)
            Console.WriteLine("   " + attrib.ToString());   

      }
      else {
         Console.WriteLine("   <None>");
      }

      // Get the method's metadata flags.
      MethodImplAttributes flags = methodInfo.GetMethodImplementationFlags();
      Console.WriteLine("Utility.GetCalendarName flags: {0}", 
                        flags.ToString());      
   }
}
// The example displays the following output:
//     Utility.GetCalendarName custom attributes:   <None>
//     Utility.GetCalendarName flags: NoInlining
// </Snippet2>
