// <Snippet1>
using System;
using System.Collections.Generic;
using System.Globalization;

public class Example : IComparer<CultureInfo>
{
   public static void Main()
   {
      // Assign possible values and their associated patterns to a 
      // generic Dictionary object.
      Dictionary<int, String> patterns = new Dictionary<int, String>();
      string[] patternStrings= { "($n)", "-$n", "$-n", "$n-", "(n$)", 
                                 "-n$", "n-$", "n$-", "-n $", "-$ n",
                                 "n $-", "$ n-", "$ -n", "n- $", "($ n)",
                                 "(n $)" };    
      for (int ctr = patternStrings.GetLowerBound(0); 
           ctr <= patternStrings.GetUpperBound(0); ctr++) 
         patterns.Add(ctr, patternStrings[ctr]);

      // Retrieve all specific cultures.
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
      Array.Sort(cultures, new Example());
      
      double number = -16.335;
      // Display the culture, CurrencyNegativePattern value, associated pattern, and result.
      foreach (var culture in cultures) 
         Console.WriteLine("{0,-15} {1,2} ({2,5}) {3,15}", culture.Name + ":", 
                           culture.NumberFormat.CurrencyNegativePattern,
                           patterns[culture.NumberFormat.CurrencyNegativePattern],
                           number.ToString("C", culture));
   }
   
   public int Compare(CultureInfo x, CultureInfo y) 
   {
      return String.Compare(x.Name, y.Name);                           
   }
}
// A portion of the output appears as follows:
//       ca-ES:           8 ( -n $)        -16,34 €
//       co-FR:           8 ( -n $)        -16,34 €
//       cs-CZ:           8 ( -n $)       -16,34 Kč
//       cy-GB:           1 (  -$n)         -£16.34
//       da-DK:          12 ( $ -n)      kr. -16,34
//       de-AT:           9 ( -$ n)        -€ 16,34
//       de-CH:           2 (  $-n)       Fr.-16.34
//       de-DE:           8 ( -n $)        -16,34 €
//       de-LI:           2 (  $-n)       CHF-16.34
//       de-LU:           8 ( -n $)        -16,34 €
//       dsb-DE:          8 ( -n $)        -16,34 €
// </Snippet1>
