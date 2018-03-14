// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");
      DateTimeFormatInfo dtfi = ci.DateTimeFormat;
      dtfi.AbbreviatedMonthNames = new string[] { "of Jan", "of Feb", "of Mar", 
                                                  "of Apr", "of May", "of Jun", 
                                                  "of Jul", "of Aug", "of Sep", 
                                                  "of Oct", "of Nov", "of Dec", "" };  
      dtfi.AbbreviatedMonthGenitiveNames = dtfi.AbbreviatedMonthNames;
      DateTime dat = new DateTime(2012, 5, 28);
      
      for (int ctr = 0; ctr < dtfi.Calendar.GetMonthsInYear(dat.Year); ctr++)
         Console.WriteLine(dat.AddMonths(ctr).ToString("dd MMM yyyy", dtfi));
   }
}
// The example displays the following output:
//       28 of May 2012
//       28 of Jun 2012
//       28 of Jul 2012
//       28 of Aug 2012
//       28 of Sep 2012
//       28 of Oct 2012
//       28 of Nov 2012
//       28 of Dec 2012
//       28 of Jan 2013
//       28 of Feb 2013
//       28 of Mar 2013
//       28 of Apr 2013
// </Snippet1>
