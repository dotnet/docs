using System;
public class Class1
{
   public static void Main()
   {
      string strA = "Владимир";
      string strB = "ВЛАДИМИР";

      // <Snippet4>
      String.Compare(strA, strB, StringComparison.OrdinalIgnoreCase);
      // </Snippet4>
      Console.WriteLine(String.Compare(strA, strB, StringComparison.OrdinalIgnoreCase));

      // <Snippet5>
      String.Compare(strA.ToUpperInvariant(), strB.ToUpperInvariant(),
                     StringComparison.Ordinal);
      // </Snippet5>
      Console.WriteLine(String.Compare(strA.ToUpperInvariant(), strB.ToUpperInvariant(),
                                       StringComparison.Ordinal));
   }
}
