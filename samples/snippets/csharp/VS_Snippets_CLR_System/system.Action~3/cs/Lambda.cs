// <Snippet4>
using System;
                         
public class TestLambda
{
   public static void Main()
   {
      string[] ordinals = {"First", "Second", "Third", "Fourth", "Fifth"};
      string[] copiedOrdinals = new string[ordinals.Length];           
      Action<string[], string[], int> copyOperation = (s1, s2, pos) =>
                                      CopyStrings(s1, s2, pos); 
      copyOperation(ordinals, copiedOrdinals, 3);
      foreach (string ordinal in copiedOrdinals)
         Console.WriteLine(ordinal == string.Empty ? "<None>" : ordinal);
   }

   private static void CopyStrings(string[] source, string[] target, int startPos)
   {
      if (source.Length != target.Length) 
         throw new IndexOutOfRangeException("The source and target arrays must have the same number of elements.");

      for (int ctr = startPos; ctr <= source.Length - 1; ctr++)
         target[ctr] = String.Copy(source[ctr]);
   }
}
// </Snippet4>
