// <Snippet1>
using System;

public class DateTimeComparison
{
   private enum DateComparisonResult
   {
      Earlier = -1,
      Later = 1,
      TheSame = 0
   };

   public static void Main()
   {
      DateTime thisDate = DateTime.Today;


      // Define two DateTime objects for today's date 
      // next year and last year		
      DateTime thisDateNextYear, thisDateLastYear;

      // Call AddYears instance method to add/substract 1 year
      thisDateNextYear = thisDate.AddYears(1);
      thisDateLastYear = thisDate.AddYears(-1);   

      // Compare dates
      //
      DateComparisonResult comparison;
      // Compare today to last year
      comparison = (DateComparisonResult) thisDate.CompareTo(thisDateLastYear);
      Console.WriteLine("CompareTo method returns {0}: {1:d} is {2} than {3:d}", 
                        (int) comparison, thisDate, comparison.ToString().ToLower(), 
                        thisDateLastYear);
      
      // Compare today to next year
      comparison = (DateComparisonResult) thisDate.CompareTo(thisDateNextYear);
      Console.WriteLine("CompareTo method returns {0}: {1:d} is {2} than {3:d}", 
                        (int) comparison, thisDate, comparison.ToString().ToLower(), 
                        thisDateNextYear);
   }
}
//
// If run on October 20, 2006, the example produces the following output:
//    CompareTo method returns 1: 10/20/2006 is later than 10/20/2005
//    CompareTo method returns -1: 10/20/2006 is earlier than 10/20/2007
// </Snippet1>
