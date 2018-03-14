// <Snippet1>
using System;
using System.Text;

public class Class1
{
   public static void Main()
   {
      StringBuilder sb = new StringBuilder("This is a string.");
      Console.WriteLine("{0} ({1} characters)", sb.ToString(), sb.Length);
      
      sb.Clear();
      Console.WriteLine("{0} ({1} characters)", sb.ToString(), sb.Length);

      sb.Append("This is a second string.");
      Console.WriteLine("{0} ({1} characters)", sb.ToString(), sb.Length);
   }
}
// The example displays the following output:
//       This is a string. (17 characters)
//        (0 characters)
//       This is a second string. (24 characters)
// </Snippet1>