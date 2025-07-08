// <Snippet2>
using System;

enum VersionTime {Earlier = -1, Same = 0, Later = 1 };

public class Example2
{
   public static void Main()
   {
      Version v1 = new Version(1, 1);
      Version v1a = new Version("1.1.0");
      ShowRelationship(v1, v1a);
      
      Version v1b = new Version(1, 1, 0, 0);
      ShowRelationship(v1b, v1a);
   }

   private static void ShowRelationship(Version v1, Version v2)
   {
      Console.WriteLine($"Relationship of {v1} to {v2}: {(VersionTime) v1.CompareTo(v2)}");       
   }
}
// The example displays the following output:
//       Relationship of 1.1 to 1.1.0: Earlier
//       Relationship of 1.1.0.0 to 1.1.0: Later
// </Snippet2>
