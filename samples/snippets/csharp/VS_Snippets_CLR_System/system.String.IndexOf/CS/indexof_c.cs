// <Snippet5>
using System;

class Example
{
   static void Main()
   {
      // Create a Unicode string with 5 Greek Alpha characters.
      String szGreekAlpha = new String('\u0391',5);

      // Create a Unicode string with 3 Greek Omega characters.
      String szGreekOmega = "\u03A9\u03A9\u03A9";
      
      String szGreekLetters = String.Concat(szGreekOmega, szGreekAlpha, 
                                            szGreekOmega.Clone());

      // Display the entire string.
      Console.WriteLine("The string: {0}", szGreekLetters);

      // The first index of Alpha.
      int ialpha = szGreekLetters.IndexOf('\u0391');
      // The first index of Omega.
      int iomega = szGreekLetters.IndexOf('\u03A9');

      Console.WriteLine("First occurrence of the Greek letter Alpha: Index {0}", 
                        ialpha);
      Console.WriteLine("First occurrence of the Greek letter Omega: Index {0}", 
                        iomega);
   }
} 
// The example displays the following output:
//    The string: OOO?????OOO
//    First occurrence of the Greek letter Alpha: Index 3
//    First occurrence of the Greek letter Omega: Index 0
// </Snippet5>

