// <Snippet1>
using System;
using System.Globalization;
using System.Threading;

public class CompareStringSample
{
   public static void Main()
   {
      string str1 = "Apple";
      string str2 = "Æble"; 

      // Sets the CurrentCulture to Danish in Denmark.
      Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");
      // Compares the two strings.
      int result1 = String.Compare(str1, str2);
      Console.WriteLine("\nWhen the CurrentCulture is \"da-DK\",\nthe " + 
                        "result of comparing {0} with {1} is: {2}", str1, str2, 
                        result1);

      // Sets the CurrentCulture to English in the U.S.
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      // Compares the two strings.
      int result2 = String.Compare(str1, str2);
      Console.WriteLine("\nWhen the CurrentCulture is \"en-US\",\nthe " + 
                        "result of comparing {0} with {1} is: {2}", str1, str2, 
                        result2);
   }
}
// The example displays the following output:
//    When the CurrentCulture is "da-DK",
//    the result of comparing Apple with Æble is: -1
//    
//    When the CurrentCulture is "en-US",
//    the result of comparing Apple with Æble is: 1
// </Snippet1>