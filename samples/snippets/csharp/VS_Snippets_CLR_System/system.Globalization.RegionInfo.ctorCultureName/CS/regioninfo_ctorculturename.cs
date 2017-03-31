// The following code example creates instances of T:System.Globalization.RegionInfo using culture names.

// <snippet1>
using System;
using System.Globalization;

public class SamplesRegionInfo  {

   public static void Main()  {

      // Creates an array containing culture names.
      String[] myCultures = new String[]  { "", "ar", "ar-DZ", "en", "en-US" };

      // Creates a RegionInfo for each of the culture names.
      //    Note that "ar" is the culture name for the neutral culture "Arabic",
      //    but it is also the region name for the country/region "Argentina";
      //    therefore, it does not fail as expected.
      Console.WriteLine("Without checks...");
      foreach (String culture in myCultures)  {
         try  {
            RegionInfo myRI = new RegionInfo( culture );
         }
         catch ( ArgumentException e )  {
            Console.WriteLine( e.ToString() );
         }
      }

      Console.WriteLine();

      Console.WriteLine( "Checking the culture names first..." );
      foreach (String culture in myCultures)  {
         if ( culture == "" )  {
            Console.WriteLine("The culture is the invariant culture.");
         }
         else  {
            CultureInfo myCI = new CultureInfo( culture, false );
            if ( myCI.IsNeutralCulture )
               Console.WriteLine( "The culture {0} is a neutral culture.", culture );
            else   {
               Console.WriteLine( "The culture {0} is a specific culture.", culture );
               try  {
                  RegionInfo myRI = new RegionInfo( culture );
               }
               catch ( ArgumentException e )  {
                  Console.WriteLine( e.ToString() );
               }
            }
         }
      }

   }

}

/*
This code produces the following output.

Without checks...
System.ArgumentException: Region name '' is not supported.
Parameter name: name
   at System.Globalization.RegionInfo..ctor(String name)
   at SamplesRegionInfo.Main()
System.ArgumentException: Region name 'en' is not supported.
Parameter name: name
   at System.Globalization.CultureTableRecord..ctor(String regionName, Boolean useUserOverride)
   at System.Globalization.RegionInfo..ctor(String name)
   at SamplesRegionInfo.Main()

Checking the culture names first...
The culture is the invariant culture.
The culture ar is a neutral culture.
The culture ar-DZ is a specific culture.
The culture en is a neutral culture.
The culture en-US is a specific culture.

*/
// </snippet1>
