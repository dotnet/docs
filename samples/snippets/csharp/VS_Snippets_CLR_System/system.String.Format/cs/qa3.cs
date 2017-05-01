using System;

public class Example
{
   public static void Main()
   {
      WillThrow();
      Console.WriteLine();
      WontThrow();
      Console.WriteLine();
      Recommended();
   }

   public static void WillThrow()
   {
      String result;
      int nOpen = 1;
      int nClose = 2;
      try {
      // <Snippet23>
      result = String.Format("The text has {0} '{' characters and {1} '}' characters.",
                             nOpen, nClose);
      // </Snippet23>
      Console.WriteLine(result); }
      catch (FormatException) {
         Console.WriteLine("FormatException");
      }
   }
   
   public static void WontThrow()
   {
      String result;
      int nOpen = 1;
      int nClose = 2;
      // <Snippet24>
      result = String.Format("The text has {0} '{{' characters and {1} '}}' characters.",
                             nOpen, nClose);
      // </Snippet24>
      Console.WriteLine(result);
   }
   
   public static void Recommended()
   {
      String result;
      int nOpen = 1;
      int nClose = 2;
      // <Snippet25>
      result = String.Format("The text has {0} '{1}' characters and {2} '{3}' characters.",
                             nOpen, "{", nClose, "}");
      // </Snippet25>
      Console.WriteLine(result);
   }
}
