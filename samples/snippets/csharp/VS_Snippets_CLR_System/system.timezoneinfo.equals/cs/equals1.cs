// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      TimeZoneInfo thisTimeZone;
      object obj1, obj2;
      
      thisTimeZone = TimeZoneInfo.Local;
      obj1 = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
      obj2 = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
      Console.WriteLine(thisTimeZone.Equals(obj1));
      Console.WriteLine(thisTimeZone.Equals(obj2));
   }
}
// The example displays the following output:
//      True
//      False
// </Snippet1>
