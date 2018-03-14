// The following code example compares two strings using different CompareOptions settings.

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
      Console.WriteLine( "Comparing \"{0}\" and \"{1}\"", myStr1, myStr2 );
      Console.WriteLine( "   With no CompareOptions            : {0}", myComp.Compare( myStr1, myStr2 ) );
      Console.WriteLine( "   With None                         : {0}", myComp.Compare( myStr1, myStr2, CompareOptions.None ) );
      Console.WriteLine( "   With Ordinal                      : {0}", myComp.Compare( myStr1, myStr2, CompareOptions.Ordinal ) );
      Console.WriteLine( "   With StringSort                   : {0}", myComp.Compare( myStr1, myStr2, CompareOptions.StringSort ) );
      Console.WriteLine( "   With IgnoreCase                   : {0}", myComp.Compare( myStr1, myStr2, CompareOptions.IgnoreCase ) );
      Console.WriteLine( "   With IgnoreSymbols                : {0}", myComp.Compare( myStr1, myStr2, CompareOptions.IgnoreSymbols ) );
      Console.WriteLine( "   With IgnoreCase and IgnoreSymbols : {0}", myComp.Compare( myStr1, myStr2, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols ) );

   }

}


/*
This code produces the following output.

Comparing "My Uncle Bill's clients" and "My uncle bills clients"
   With no CompareOptions            : 1
   With None                         : 1
   With Ordinal                      : -32
   With StringSort                   : -1
   With IgnoreCase                   : 1
   With IgnoreSymbols                : 1
   With IgnoreCase and IgnoreSymbols : 0

*/
// </snippet1>
