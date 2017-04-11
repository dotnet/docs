using System;

public class Example
{
   public static void Main()
   {
      int n1 = 10;
      int n2 = 20;
      // <Snippet4>
      String result = String.Format("{0} + {1} = {2}", 
                                    n1, n2, n1 + n2);
      // </Snippet4>
      Console.WriteLine(result);
      Main2();
   }

   public static void Main2()
   {
      // <Snippet3>
      int n1 = 10;
      int n2 = 20;
      String result = String.Format("{0 + {1] = {2}", 
                                    n1, n2, n1 + n2);
      // </Snippet3>
   }
}
