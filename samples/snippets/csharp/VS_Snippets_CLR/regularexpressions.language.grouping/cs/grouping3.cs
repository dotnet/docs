// <Snippet3>
using System;
using System.Text.RegularExpressions;

class Example
{
   public static void Main()
   {
      string pattern = "^[^<>]*" +
                       "(" +
                       "((?'Open'<)[^<>]*)+" +
                       "((?'Close-Open'>)[^<>]*)+" +
                       ")*" +
                       "(?(Open)(?!))$";
      string input = "<abc><mno<xyz>>";

      Match m = Regex.Match(input, pattern);
      if (m.Success == true)
      {
         Console.WriteLine($"Input: \"{input}\" \nMatch: \"{m}\"");
         int grpCtr = 0;
         foreach (Group grp in m.Groups)
         {
            Console.WriteLine($"   Group {grpCtr}: {grp.Value}");
            grpCtr++;
            int capCtr = 0;
            foreach (Capture cap in grp.Captures)
            {
                Console.WriteLine($"      Capture {capCtr}: {cap.Value}");
                capCtr++;
            }
          }
      }
      else
      {
         Console.WriteLine("Match failed.");
      }
    }
}
// The example displays the following output:
//    Input: "<abc><mno<xyz>>"
//    Match: "<abc><mno<xyz>>"
//       Group 0: <abc><mno<xyz>>
//          Capture 0: <abc><mno<xyz>>
//       Group 1: <mno<xyz>>
//          Capture 0: <abc>
//          Capture 1: <mno<xyz>>
//       Group 2: <xyz
//          Capture 0: <abc
//          Capture 1: <mno
//          Capture 2: <xyz
//       Group 3: >
//          Capture 0: >
//          Capture 1: >
//          Capture 2: >
//       Group 4:
//       Group 5: mno<xyz>
//          Capture 0: abc
//          Capture 1: xyz
//          Capture 2: mno<xyz>
// </Snippet3>
