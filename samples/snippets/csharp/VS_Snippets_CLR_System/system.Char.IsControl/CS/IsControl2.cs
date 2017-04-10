// <Snippet2>
using System;

public class ControlChar
{
   public static void Main()
   {
      string sentence = "This is a " + Environment.NewLine + "two-line sentence.";
      for (int ctr = 0; ctr < sentence.Length; ctr++)
      {
         if (Char.IsControl(sentence, ctr))
           Console.WriteLine("Control character \\U{0} found in position {1}.", 
             Convert.ToInt32(sentence[ctr]).ToString("X4"), ctr);
         
      }
   }
}
// The example displays the following output to the console:
//       Control character \U000D found in position 10.
//       Control character \U000A found in position 11.
// </Snippet2>
