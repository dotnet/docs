// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      DateTime baseDate = new DateTime(2000, 2, 29);
      Console.WriteLine("    Base Date:        {0:d}\n", baseDate);
      
      // Show dates of previous fifteen years.
      for (int ctr = -1; ctr >= -15; ctr--)
         Console.WriteLine("{0,2} year(s) ago:        {1:d}", 
                           Math.Abs(ctr), baseDate.AddYears(ctr));
      Console.WriteLine();

      // Show dates of next fifteen years.
      for (int ctr = 1; ctr <= 15; ctr++)
         Console.WriteLine("{0,2} year(s) from now:   {1:d}", 
                           ctr, baseDate.AddYears(ctr));
   }
}
// The example displays the following output:
//           Base Date:        2/29/2000
//       
//        1 year(s) ago:        2/28/1999
//        2 year(s) ago:        2/28/1998
//        3 year(s) ago:        2/28/1997
//        4 year(s) ago:        2/29/1996
//        5 year(s) ago:        2/28/1995
//        6 year(s) ago:        2/28/1994
//        7 year(s) ago:        2/28/1993
//        8 year(s) ago:        2/29/1992
//        9 year(s) ago:        2/28/1991
//       10 year(s) ago:        2/28/1990
//       11 year(s) ago:        2/28/1989
//       12 year(s) ago:        2/29/1988
//       13 year(s) ago:        2/28/1987
//       14 year(s) ago:        2/28/1986
//       15 year(s) ago:        2/28/1985
//       
//        1 year(s) from now:   2/28/2001
//        2 year(s) from now:   2/28/2002
//        3 year(s) from now:   2/28/2003
//        4 year(s) from now:   2/29/2004
//        5 year(s) from now:   2/28/2005
//        6 year(s) from now:   2/28/2006
//        7 year(s) from now:   2/28/2007
//        8 year(s) from now:   2/29/2008
//        9 year(s) from now:   2/28/2009
//       10 year(s) from now:   2/28/2010
//       11 year(s) from now:   2/28/2011
//       12 year(s) from now:   2/29/2012
//       13 year(s) from now:   2/28/2013
//       14 year(s) from now:   2/28/2014
//       15 year(s) from now:   2/28/2015
// </Snippet1>