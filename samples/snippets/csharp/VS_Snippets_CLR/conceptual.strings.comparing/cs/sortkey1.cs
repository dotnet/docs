// <Snippet4>
using System;
using System.Threading;
using System.Globalization;

public class SortKeySample 
{
   public static void Main(String[] args) 
   {
      String str1 = "Apple";
      String str2 = "Æble";

      // Set the CurrentCulture to "da-DK".
      CultureInfo dk = new CultureInfo("da-DK");
      Thread.CurrentThread.CurrentCulture = dk;

      // Create a culturally sensitive sort key for str1.
      SortKey sc1 = dk.CompareInfo.GetSortKey(str1);
      // Create a culturally sensitive sort key for str2.
      SortKey sc2 = dk.CompareInfo.GetSortKey(str2);

      // Compare the two sort keys and display the results.
      int result1 = SortKey.Compare(sc1, sc2);
      Console.WriteLine("When the CurrentCulture is \"da-DK\",");
      Console.WriteLine("the result of comparing {0} with {1} is: {2}\n", 
                        str1, str2, result1);

      // Set the CurrentCulture to "en-US".
      CultureInfo enus = new CultureInfo("en-US");
      Thread.CurrentThread.CurrentCulture = enus ;

      // Create a culturally sensitive sort key for str1.
      SortKey sc3 = enus.CompareInfo.GetSortKey(str1);
      // Create a culturally sensitive sort key for str1.
      SortKey sc4 = enus.CompareInfo.GetSortKey(str2);

      // Compare the two sort keys and display the results.
      int result2 = SortKey.Compare(sc3, sc4);
      Console.WriteLine("When the CurrentCulture is \"en-US\",");
      Console.WriteLine("the result of comparing {0} with {1} is: {2}", 
                        str1, str2, result2);
   }
}
// The example displays the following output:
//       When the CurrentCulture is "da-DK",
//       the result of comparing Apple with Æble is: -1
//       
//       When the CurrentCulture is "en-US",
//       the result of comparing Apple with Æble is: 1
// </Snippet4>