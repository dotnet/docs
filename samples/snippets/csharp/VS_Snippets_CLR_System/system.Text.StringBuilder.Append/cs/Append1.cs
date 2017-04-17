using System;
using System.Text;

[assembly: CLSCompliant(true)]
public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      char[] characters = {'/', '<', '<', ' ', '>', '>', '\\'};
      const int beginPosition = 0;
      const int endPosition = 3; 
      
      string title = "The Hound of the Baskervilles";
      
      StringBuilder sb = new StringBuilder();
      sb.Append(characters, beginPosition, 4);
      sb.Append(title);
      sb.Append(characters, endPosition, 4);
      Console.WriteLine(sb.ToString());
      // The example displays the following output:
      //      /<< The Hound of the Baskervilles >>\      
      // </Snippet1>
   }
}
