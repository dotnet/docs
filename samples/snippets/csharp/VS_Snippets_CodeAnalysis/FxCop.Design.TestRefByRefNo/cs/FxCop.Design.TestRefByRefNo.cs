//<Snippet1>
using System;

namespace DesignLibrary
{
   public class Test
   {
      public static void Main()
      {
         string s1 = "12345";
         string s2 = "12345";
         string s3 = "12345";
     
         Console.WriteLine("Changing pointer - passed by value:");
         Console.WriteLine(s1);
         ReferenceTypesAndParameters.BadPassTheObject (s1);
         Console.WriteLine(s1);

         Console.WriteLine("Changing pointer - passed by reference:");
         Console.WriteLine(s2);
         ReferenceTypesAndParameters.PassTheReference (ref s2);
         Console.WriteLine(s2);

         Console.WriteLine("Passing by return value:");
         s3 = ReferenceTypesAndParameters.BetterThanPassTheReference (s3);
         Console.WriteLine(s3);
      }
   }
}
//</Snippet1>
namespace DesignLibrary
{
   public class ReferenceTypesAndParameters
   {

      // The following syntax will not work. You cannot make a
      // reference type that is passed by value point to a new
      // instance. This needs the ref keyword.

      public static void BadPassTheObject(string argument)
      {
         argument = argument + " ABCDE";
      }

      // The following syntax will work, but is considered bad design.
      // It reassigns the argument to point to a new instance of string.
      // Violates rule DoNotPassTypesByReference.

      public static void PassTheReference(ref string argument)
      {
         argument = argument + " ABCDE";
      }

      // The following syntax will work and is a better design.
      // It returns the altered argument as a new instance of string.

      public static string BetterThanPassTheReference(string argument)
      {
         return argument + " ABCDE";
      }
   }
}