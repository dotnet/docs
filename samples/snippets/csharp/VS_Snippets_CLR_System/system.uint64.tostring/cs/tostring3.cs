// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      ulong value = 217960834;
      string[] specifiers = { "G", "C", "D3", "E2", "e3", "F", 
                              "N", "P", "X", "000000.0", "#.0", 
                              "00000000;(0);**Zero**" };
      
      foreach (string specifier in specifiers)
         Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
   }
}
// The example displays the following output:
//       G: 217960834
//       C: $217,960,834.00
//       D3: 217960834
//       E2: 2.18E+008
//       e3: 2.180e+008
//       F: 217960834.00
//       N: 217,960,834.00
//       P: 21,796,083,400.00 %
//       X: CFDD182
//       000000.0: 217960834.0
//       #.0: 217960834.0
//       00000000;(0);**Zero**: 217960834
// </Snippet3>
