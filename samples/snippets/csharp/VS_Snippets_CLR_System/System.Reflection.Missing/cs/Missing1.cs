// <Snippet1>
using System;
using System.Reflection;

[assembly:CLSCompliant(true)]

public class MissingClass
{
   public static void MethodWithDefault(int value = 33)
   {
      Console.WriteLine("value = {0}", value);
   } 
}

public class Example
{
   public static void Main()
   {
      // Invoke without reflection
      MissingClass.MethodWithDefault();
      
      // Invoke by using reflection.
      Type t = typeof(MissingClass);
      MethodInfo mi = t.GetMethod("MethodWithDefault");
      mi.Invoke(null, new object[] { Missing.Value });
   }
}
// The example displays the following output:
//       value = 33  
//       value = 33  
// </Snippet1>

