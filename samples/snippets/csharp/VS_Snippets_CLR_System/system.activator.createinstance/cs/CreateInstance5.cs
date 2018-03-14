// <Snippet5>
using System;

public class Example
{
   public static void Main()
   {
      // Initialize array of characters from a to z.
      Char[] chars = new Char[26]; 
      for (int ctr = 0; ctr < 26; ctr++)
         chars[ctr] = (char) (ctr + 0x0061);

      Object obj = Activator.CreateInstance(typeof(String),
                                            new Object[] { chars, 13, 10 } );
      Console.WriteLine(obj);                                          
   }
}
// The example displays the following output:
//       nopqrstuvw
// </Snippet5>

