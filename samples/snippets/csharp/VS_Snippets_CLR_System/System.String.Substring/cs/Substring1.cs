// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      String[] pairs = { "Color1=red", "Color2=green", "Color3=blue",
                         "Title=Code Repository" };
      foreach (var pair in pairs) {
         int position = pair.IndexOf("=");
         if (position < 0)
            continue;
         Console.WriteLine("Key: {0}, Value: '{1}'", 
                           pair.Substring(0, position),
                           pair.Substring(position + 1));
      }                          
   }
}
// The example displays the following output:
//     Key: Color1, Value: 'red'
//     Key: Color2, Value: 'green'
//     Key: Color3, Value: 'blue'
//     Key: Title, Value: 'Code Repository'
// </Snippet1>
