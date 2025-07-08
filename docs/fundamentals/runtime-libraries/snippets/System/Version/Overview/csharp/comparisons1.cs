using System;

public class Example7
{
   public static void Main()
   {
      CompareSimple();
   }

   private static void CompareSimple()
   {
      // <Snippet1>
      Version v1 = new Version(2, 0);
      Version v2 = new Version("2.1");
      Console.Write("Version {0} is ", v1);
      switch(v1.CompareTo(v2))
      {
         case 0:
            Console.Write("the same as");
            break;
         case 1:
            Console.Write("later than");
            break;
         case -1:
            Console.Write("earlier than");
            break;
      }
      Console.WriteLine($" Version {v2}.");                  
      // The example displays the following output:
      //       Version 2.0 is earlier than Version 2.1.
      // </Snippet1>      
   } 
}
