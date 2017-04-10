// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      String pattern = @"^([a-z]+)(\d+)?\.([a-z]+(\d)*)$";
      String[] values = { "AC10", "Za203.CYM", "XYZ.CoA", "ABC.x170" };   
      foreach (var value in values) {
         Match m = Regex.Match(value, pattern, RegexOptions.IgnoreCase);
         if (m.Success) {
            Console.WriteLine("Match: '{0}'", m.Value);
            Console.WriteLine("   Number of Capturing Groups: {0}", 
                              m.Groups.Count);
            for (int gCtr = 0; gCtr < m.Groups.Count; gCtr++) {
               Group group = m.Groups[gCtr];
               Console.WriteLine("      Group {0}: {1}", gCtr, 
                                 group.Value == "" ? "<empty>" : "'" + group.Value + "'");   
               Console.WriteLine("         Number of Captures: {0}", 
                                 group.Captures.Count);
           
               for (int cCtr = 0; cCtr < group.Captures.Count; cCtr++) 
                  Console.WriteLine("            Capture {0}: {1}", 
                                    cCtr, group.Captures[cCtr].Value);
            }
         } 
         else {
            Console.WriteLine("No match for {0}: Match.Value is {1}", 
                              value, m.Value == String.Empty ? "<empty>" : m.Value);
         }
      }
   }
}
// The example displays the following output:
//       No match for AC10: Match.Value is <empty>
//       Match: 'Za203.CYM'
//          Number of Capturing Groups: 5
//             Group 0: 'Za203.CYM'
//                Number of Captures: 1
//                   Capture 0: Za203.CYM
//             Group 1: 'Za'
//                Number of Captures: 1
//                   Capture 0: Za
//             Group 2: '203'
//                Number of Captures: 1
//                   Capture 0: 203
//             Group 3: 'CYM'
//                Number of Captures: 1
//                   Capture 0: CYM
//             Group 4: <empty>
//                Number of Captures: 0
//       Match: 'XYZ.CoA'
//          Number of Capturing Groups: 5
//             Group 0: 'XYZ.CoA'
//                Number of Captures: 1
//                   Capture 0: XYZ.CoA
//             Group 1: 'XYZ'
//                Number of Captures: 1
//                   Capture 0: XYZ
//             Group 2: <empty>
//                Number of Captures: 0
//             Group 3: 'CoA'
//                Number of Captures: 1
//                   Capture 0: CoA
//             Group 4: <empty>
//                Number of Captures: 0
//       Match: 'ABC.x170'
//          Number of Capturing Groups: 5
//             Group 0: 'ABC.x170'
//                Number of Captures: 1
//                   Capture 0: ABC.x170
//             Group 1: 'ABC'
//                Number of Captures: 1
//                   Capture 0: ABC
//             Group 2: <empty>
//                Number of Captures: 0
//             Group 3: 'x170'
//                Number of Captures: 1
//                   Capture 0: x170
//             Group 4: '0'
//                Number of Captures: 3
//                   Capture 0: 1
//                   Capture 1: 7
//                   Capture 2: 0
// </Snippet1>
