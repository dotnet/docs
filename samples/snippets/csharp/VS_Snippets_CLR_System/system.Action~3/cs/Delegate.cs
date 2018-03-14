// <Snippet1>
using System;

delegate void StringCopy(string[] stringArray1, 
                         string[] stringArray2, 
                         int indexToStart);
                         
public class TestDelegate
{
   public static void Main()
   {
      string[] ordinals = {"First", "Second", "Third", "Fourth", "Fifth"};
      string[] copiedOrdinals = new string[ordinals.Length];           
      StringCopy copyOperation = CopyStrings;
      copyOperation(ordinals, copiedOrdinals, 3);
      foreach (string ordinal in copiedOrdinals)
         Console.WriteLine(String.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
   }

   private static void CopyStrings(string[] source, string[] target, int startPos)
   {
      if (source.Length != target.Length) 
         throw new IndexOutOfRangeException("The source and target arrays must have the same number of elements.");

      for (int ctr = startPos; ctr <= source.Length - 1; ctr++)
         target[ctr] = String.Copy(source[ctr]);
   }

}
// </Snippet1>
