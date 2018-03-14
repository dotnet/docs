
// <Snippet4>
using System;

public class Example
{
   public static void Main()
   {
      Console.WriteLine("NaN == NaN: {0}", Single.NaN == Single.NaN); 
      Console.WriteLine("NaN != NaN: {0}", Single.NaN != Single.NaN); 
      Console.WriteLine("NaN.Equals(NaN): {0}", Single.NaN.Equals(Single.NaN)); 
      Console.WriteLine("! NaN.Equals(NaN): {0}", ! Single.NaN.Equals(Single.NaN)); 
      Console.WriteLine("IsNaN: {0}", Double.IsNaN(Double.NaN));
      
      Console.WriteLine("\nNaN > NaN: {0}", Single.NaN > Single.NaN); 
      Console.WriteLine("NaN >= NaN: {0}", Single.NaN >= Single.NaN); 
      Console.WriteLine("NaN < NaN: {0}", Single.NaN < Single.NaN);
      Console.WriteLine("NaN < 100.0: {0}", Single.NaN < 100.0f); 
      Console.WriteLine("NaN <= 100.0: {0}", Single.NaN <= 100.0f); 
      Console.WriteLine("NaN >= 100.0: {0}", Single.NaN > 100.0f);
      Console.WriteLine("NaN.CompareTo(NaN): {0}", Single.NaN.CompareTo(Single.NaN)); 
      Console.WriteLine("NaN.CompareTo(100.0): {0}", Single.NaN.CompareTo(100.0f)); 
      Console.WriteLine("(100.0).CompareTo(Single.NaN): {0}", (100.0f).CompareTo(Single.NaN)); 
   }
}
// The example displays the following output:
//       NaN == NaN: False
//       NaN != NaN: True
//       NaN.Equals(NaN): True
//       ! NaN.Equals(NaN): False
//       IsNaN: True
//
//       NaN > NaN: False
//       NaN >= NaN: False
//       NaN < NaN: False
//       NaN < 100.0: False
//       NaN <= 100.0: False
//       NaN >= 100.0: False
//       NaN.CompareTo(NaN): 0
//       NaN.CompareTo(100.0): -1
//       (100.0).CompareTo(Single.NaN): 1
// </Snippet4>
