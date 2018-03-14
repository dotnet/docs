// <Snippet1>
using System;

class Sample 
{
   public static void Main() 
   {
      // Define a string array with the following three "I" characters:
      //      U+0069, U+0131, and U+0049.  
      string[] threeIs = { "i", "ı", "I" };
      // Define Type object representing StringComparison type.
      Type scType = typeof(StringComparison);  
      
      // Show the current culture (for culture-sensitive string comparisons).
      Console.WriteLine("The current culture is {0}.\n", 
                        System.Globalization.CultureInfo.CurrentCulture.Name);
        
      // Perform comparisons using each StringComparison member. 
      foreach (string scName in Enum.GetNames(scType))
      {
         StringComparison sc = (StringComparison) Enum.Parse(scType, scName);
         Console.WriteLine("Comparisons using {0}:", sc);
         // Compare each character in character array.
         for (int ctr = 0; ctr <= 1; ctr++)
         {
            string instanceChar = threeIs[ctr];
            for (int innerCtr = ctr + 1; innerCtr <= threeIs.GetUpperBound(0); innerCtr++)
            {
               string otherChar = threeIs[innerCtr];
               Console.WriteLine("{0} (U+{1}) = {2} (U+{3}): {4}", 
                                 instanceChar, Convert.ToInt16(Char.Parse(instanceChar)).ToString("X4"), 
                                 otherChar, Convert.ToInt16(Char.Parse(otherChar)).ToString("X4"), 
                                 instanceChar.Equals(otherChar, sc));
            }
            Console.WriteLine();
         }
      }   
   }
}
// The example displays the following output:
//       The current culture is en-US.
//       
//       Comparisons using CurrentCulture:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): False
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using CurrentCultureIgnoreCase:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): True
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using InvariantCulture:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): False
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using InvariantCultureIgnoreCase:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): True
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using Ordinal:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): False
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using OrdinalIgnoreCase:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): True
//       
//       i (U+0131) = I (U+0049): False
// </Snippet1>
// 119 lines
