// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      var name = "Horace";
      var age = 34;
      var s1 = $"He asked, \"Is your name {name}?\", but didn't wait for a reply.";
      Console.WriteLine(s1);
      
      var s2 = $"{name} is {age:D3} year{(age == 1 ? "" : "s")} old.";
      Console.WriteLine(s2); 
   }
}
// The example displays the following output:
//       He asked, "Is your name Horace?", but didn't wait for a reply.
//       Horace is 034 years old.
// </Snippet1>
