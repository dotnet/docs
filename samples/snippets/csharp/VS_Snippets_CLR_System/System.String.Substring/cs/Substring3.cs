// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      String s = "<term>extant<definition>still in existence</definition></term>";
      String searchString = "<definition>";
      int startIndex = s.IndexOf(searchString);
      searchString = "</" + searchString.Substring(1);
      int endIndex = s.IndexOf(searchString);
      String substring = s.Substring(startIndex, endIndex + searchString.Length - startIndex);
      Console.WriteLine("Original string: {0}", s);
      Console.WriteLine("Substring;       {0}", substring); 
   }
}
// The example displays the following output:
//     Original string: <term>extant<definition>still in existence</definition></term>
//     Substring;       <definition>still in existence</definition>
// </Snippet3>
