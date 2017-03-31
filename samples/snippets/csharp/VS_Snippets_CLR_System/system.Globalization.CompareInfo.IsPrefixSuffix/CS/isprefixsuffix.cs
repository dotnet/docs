// The following code example determines whether a string is the prefix or suffix of another string.

// <snippet1>
using System;
using System.Globalization;

public class SamplesCompareInfo  {

   public static void Main()  {

      // Defines the strings to compare.
      String myStr1 = "calle";
      String myStr2 = "llegar";
      String myXfix = "lle";

      // Uses the CompareInfo property of the InvariantCulture.
      CompareInfo myComp = CultureInfo.InvariantCulture.CompareInfo;

      // Determines whether myXfix is a prefix of "calle" and "llegar".
      Console.WriteLine( "IsPrefix( {0}, {1} ) : {2}", myStr1, myXfix, myComp.IsPrefix( myStr1, myXfix ) );
      Console.WriteLine( "IsPrefix( {0}, {1} ) : {2}", myStr2, myXfix, myComp.IsPrefix( myStr2, myXfix ) );

      // Determines whether myXfix is a suffix of "calle" and "llegar".
      Console.WriteLine( "IsSuffix( {0}, {1} ) : {2}", myStr1, myXfix, myComp.IsSuffix( myStr1, myXfix ) );
      Console.WriteLine( "IsSuffix( {0}, {1} ) : {2}", myStr2, myXfix, myComp.IsSuffix( myStr2, myXfix ) );

   }

}


/*
This code produces the following output.

IsPrefix( calle, lle ) : False
IsPrefix( llegar, lle ) : True
IsSuffix( calle, lle ) : True
IsSuffix( llegar, lle ) : False

*/
// </snippet1>
