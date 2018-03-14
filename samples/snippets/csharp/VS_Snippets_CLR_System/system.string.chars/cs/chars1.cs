using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      string str1 = "Test";
      for (int ctr = 0; ctr <= str1.Length - 1; ctr++ )
         Console.Write("{0} ", str1[ctr]);
      // The example displays the following output:
      //      T e s t         
      // </Snippet1>   
   }
}
