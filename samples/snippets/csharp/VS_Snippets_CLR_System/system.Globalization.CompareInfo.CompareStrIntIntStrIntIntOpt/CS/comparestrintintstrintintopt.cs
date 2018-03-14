// The following code example compares portions of two strings using different CompareOptions settings.

// <snippet1>
using System;
using System.Globalization;

public class SamplesCompareInfo  {

   public static void Main()  {

      // Defines the strings to compare.
      String myStr1 = "My Uncle Bill's clients";
      String myStr2 = "My uncle bills clients";

      // Creates a CompareInfo that uses the InvariantCulture.
      CompareInfo myComp = CultureInfo.InvariantCulture.CompareInfo;

      // Compares two strings using myComp.
      Console.WriteLine( "Comparing \"{0}\" and \"{1}\"", myStr1.Substring( 3, 10 ), myStr2.Substring( 3, 10 ) );
      Console.WriteLine( "   With no CompareOptions            : {0}", myComp.Compare( myStr1, 3, 10, myStr2, 3, 10 ) );
      Console.WriteLine( "   With None                         : {0}", myComp.Compare( myStr1, 3, 10, myStr2, 3, 10, CompareOptions.None ) );
      Console.WriteLine( "   With Ordinal                      : {0}", myComp.Compare( myStr1, 3, 10, myStr2, 3, 10, CompareOptions.Ordinal ) );
      Console.WriteLine( "   With StringSort                   : {0}", myComp.Compare( myStr1, 3, 10, myStr2, 3, 10, CompareOptions.StringSort ) );
      Console.WriteLine( "   With IgnoreCase                   : {0}", myComp.Compare( myStr1, 3, 10, myStr2, 3, 10, CompareOptions.IgnoreCase ) );
      Console.WriteLine( "   With IgnoreSymbols                : {0}", myComp.Compare( myStr1, 3, 10, myStr2, 3, 10, CompareOptions.IgnoreSymbols ) );
      Console.WriteLine( "   With IgnoreCase and IgnoreSymbols : {0}", myComp.Compare( myStr1, 3, 10, myStr2, 3, 10, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols ) );

   }

}


/*
This code produces the following output.

Comparing "Uncle Bill" and "uncle bill"
   With no CompareOptions            : 1
   With None                         : 1
   With Ordinal                      : -32
   With StringSort                   : 1
   With IgnoreCase                   : 0
   With IgnoreSymbols                : 1
   With IgnoreCase and IgnoreSymbols : 0

*/
// </snippet1>
