// <Snippet1>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Random rnd = new Random();
      List<Task> tasks  = new List<Task>();
      // Execute the task 10 times.
      for (int ctr = 1; ctr <= 9; ctr++) {
         tasks.Add(Task.Factory.StartNew( () => {
                                            int utf32 = 0;
                                            lock(rnd) {
                                               // Get UTF32 value.
                                               utf32 = rnd.Next(0, 0xE01F0);
                                            }
                                            // Convert it to a UTF16-encoded character.
                                            string utf16 = Char.ConvertFromUtf32(utf32);
                                            // Display information about the character.
                                            Console.WriteLine("0x{0:X8} --> '{1,2}' ({2})", 
                                                              utf32, utf16, ShowHex(utf16));
                                         }));                           
      }
      Task.WaitAll(tasks.ToArray()); 
   }

   private static string ShowHex(string value)
   {
      string hexString = null;
      // Handle only non-control characters.
      if (! Char.IsControl(value, 0)) {
         foreach (var ch in value)
            hexString += String.Format("0x{0} ", Convert.ToUInt16(ch));

      }   
      return hexString.Trim();
   }
}
// The example displays the following output:
//       0x00097103 --> 'Ì®úÌ¥É' (0x55836 0x56579)
//       0x000A98A1 --> 'Ì©¶Ì≤°' (0x55910 0x56481)
//       0x00050002 --> 'Ì§ÄÌ∞Ç' (0x55552 0x56322)
//       0x0000FEF1 --> ' Ôª±' (0x65265)
//       0x0008BC0A --> 'ÌßØÌ∞ä' (0x55791 0x56330)
//       0x000860EA --> 'ÌßòÌ≥™' (0x55768 0x56554)
//       0x0009AC5A --> 'Ì®´Ì±ö' (0x55851 0x56410)
//       0x00053320 --> 'Ì§åÌº†' (0x55564 0x57120)
//       0x000874EF --> 'ÌßùÌ≥Ø' (0x55773 0x56559)
// </Snippet1>
