// <Snippet1>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      string longName = "system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
      Assembly assem = Assembly.Load(longName);
      if (assem == null)
         Console.WriteLine("Unable to load assembly...");
      else
         Console.WriteLine(assem.FullName);
   }
}
// The example displays the following output:
//        system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// </Snippet1>