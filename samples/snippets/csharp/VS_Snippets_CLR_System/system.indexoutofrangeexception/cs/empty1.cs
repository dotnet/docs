// <Snippet9>
using System;

public class Example
{
   public static void Main()
   {
      string[] maleNames= { "Adam", "Bartholomew", "Charles", "David", 
                            "Earl", "Robert", "Stanley", "Wilberforce" };
      string[] selected= Array.FindAll(maleNames, name => {
                                                     string fLetter = name.Substring(0, 1);
                                                     return fLetter.CompareTo("F") >= 0 && 
                                                            fLetter.CompareTo("M") <= 0;
                                       } );                                  
      for (int ctr = 0; ctr < selected.Length; ctr++)
         Console.WriteLine(selected[ctr]);
   }
}
// The example displays the following output:
//       Unhandled Exception:
//       System.IndexOutOfRangeException:
//       Index was outside the bounds of the array.
//       at Example.Main()
// </Snippet9>

