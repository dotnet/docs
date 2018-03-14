// <Snippet1>
using System;

public class Example
{
   public static void Main() 
   {
      try {
         // Call a method that throws an exception.
         TypeLoadExceptionDemoClass.GenerateException();
      }  
      catch (TypeLoadException e) {
         Console.WriteLine("TypeLoadException:\n   {0}", e.Message);
      }
   }
}

class TypeLoadExceptionDemoClass
{ 
   public static bool GenerateException() 
   {
      // Throw a TypeLoadException with a custom defined message.
      throw new TypeLoadException("This is a custom TypeLoadException error message.");
   }
}
// The example displays the following output:
//       TypeLoadException:
//          This is a custom TypeLoadException error message.
// </Snippet1>
