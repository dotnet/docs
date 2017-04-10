using System;

public class Class1
{
   public static void Main()
   {
      UseCharEnumerator();
      Console.WriteLine("-----");
      UseForEach();
   }

   private static void UseCharEnumerator()
   {
      // <Snippet1>
      string title = "A Tale of Two Cities";
      CharEnumerator chEnum = title.GetEnumerator();
      int ctr = 1;
      string outputLine1 = null;
      string outputLine2 = null;
      string outputLine3 = null; 
      
      while (chEnum.MoveNext())
      {
         outputLine1 += ctr < 10 || ctr % 10 != 0 ? "  " : (ctr / 10) + " ";
         outputLine2 += (ctr % 10) + " ";
         outputLine3 += chEnum.Current + " ";
         ctr++;
      }
      
      Console.WriteLine("The length of the string is {0} characters:", 
                        title.Length);
      Console.WriteLine(outputLine1);
      Console.WriteLine(outputLine2);    
      Console.WriteLine(outputLine3);
      // The example displays the following output to the console:      
      //       The length of the string is 20 characters:
      //                         1                   2
      //       1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
      //       A   T a l e   o f   T w o   C i t i e s
      // </Snippet1>
   }   

   private static void UseForEach()
   {
      // <Snippet2>
      string title = "A Tale of Two Cities";
      int ctr = 1;
      string outputLine1 = null;
      string outputLine2 = null;
      string outputLine3 = null; 
      
      foreach (char ch in title)
      {
         outputLine1 += ctr < 10 || ctr % 10 != 0 ? "  " : (ctr / 10) + " ";
         outputLine2 += (ctr % 10) + " ";
         outputLine3 += ch + " ";
         ctr++;
      }
      
      Console.WriteLine("The length of the string is {0} characters:", 
                        title.Length);
      Console.WriteLine(outputLine1);
      Console.WriteLine(outputLine2);    
      Console.WriteLine(outputLine3);
      // The example displays the following output to the console:      
      //       The length of the string is 20 characters:
      //                         1                   2
      //       1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
      //       A   T a l e   o f   T w o   C i t i e s
      // </Snippet2>
   }   
}
