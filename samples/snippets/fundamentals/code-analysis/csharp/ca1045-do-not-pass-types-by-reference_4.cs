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