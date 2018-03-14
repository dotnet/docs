// <Snippet3>
using System;

public class TestAnonymousMethod
{
   public static void Main()
   {
      string[] ordinals = {"First", "Second", "Third", "Fourth", "Fifth", 
                           "Sixth", "Seventh", "Eighth", "Ninth", "Tenth"};
      string[] copiedOrdinals = new string[ordinals.Length];           
      Action<string[], string[], int, int> copyOperation = 
                                           delegate(string[] s1, string[] s2, 
                                           int pos, int num) 
                                { CopyStrings(s1, s2, pos, num); };  
      copyOperation(ordinals, copiedOrdinals, 3, 5);
      foreach (string ordinal in copiedOrdinals)
         Console.WriteLine(String.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
   }

   private static void CopyStrings(string[] source, string[] target, 
                                   int startPos, int number)
   {
      if (source.Length != target.Length) 
         throw new IndexOutOfRangeException("The source and target arrays must have the same number of elements.");

      for (int ctr = startPos; ctr <= startPos + number - 1; ctr++)
         target[ctr] = String.Copy(source[ctr]);
   }
}
// </Snippet3>
