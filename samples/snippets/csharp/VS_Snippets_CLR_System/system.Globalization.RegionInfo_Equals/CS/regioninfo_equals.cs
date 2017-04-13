// The following code example compares two instances of RegionInfo that were created differently.

// <snippet1>
using System;
using System.Globalization;

public class SamplesRegionInfo  {

   public static void Main()  {

      // Creates a RegionInfo using the ISO 3166 two-letter code.
      RegionInfo myRI1 = new RegionInfo( "US" );

      // Creates a RegionInfo using a CultureInfo.LCID.
      RegionInfo myRI2 = new RegionInfo( new CultureInfo("en-US",false).LCID );

      // Compares the two instances.
      if ( myRI1.Equals( myRI2 ) )
         Console.WriteLine( "The two RegionInfo instances are equal." );
      else
         Console.WriteLine( "The two RegionInfo instances are NOT equal." );

   }

}

/*
This code produces the following output.

The two RegionInfo instances are equal.

*/
// </snippet1>
