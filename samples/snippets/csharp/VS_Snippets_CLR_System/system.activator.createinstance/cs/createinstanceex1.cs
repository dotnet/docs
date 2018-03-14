// <Snippet2>
using System;
using System.Runtime.Remoting;

public class Example
{
   public static void Main()
   {
      ObjectHandle handle = Activator.CreateInstance("PersonInfo", "Person");
      Person p = (Person) handle.Unwrap();
      p.Name = "Samuel";
      Console.WriteLine(p);
   }
}
// The example displays the following output:
//        Samuel
// </Snippet2>