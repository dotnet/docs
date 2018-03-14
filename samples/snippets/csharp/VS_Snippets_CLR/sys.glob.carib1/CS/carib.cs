//<snippet1>
// This example demonstrates a System.Globalization.Culture-
// AndRegionInfoBuilder constructor and some of the properties 
// of the CultureAndRegionInfoBuilder object that is created.
// Compile this example with a reference to sysglobl.dll.

using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {

// Construct a new, privately used culture that extends the en-US culture 
// provided by the .NET Framework. In this sample, the CultureAndRegion-
// Types.Specific parameter creates a minimal CultureAndRegionInfoBuilder 
// object that you must populate with culture and region information.

    CultureAndRegionInfoBuilder cib = null;
    try {
        cib = new CultureAndRegionInfoBuilder(
                                          "x-en-US-sample",
                                          CultureAndRegionModifiers.None);
        }
    catch (ArgumentException ae)
        {
        Console.WriteLine(ae);
        return;
        }

// Populate the new CultureAndRegionInfoBuilder object with culture information.

    CultureInfo ci = new CultureInfo("en-US");
    cib.LoadDataFromCultureInfo(ci);

// Populate the new CultureAndRegionInfoBuilder object with region information.

    RegionInfo  ri = new RegionInfo("US");
    cib.LoadDataFromRegionInfo(ri);

// Display some of the properties for the x-en-US-sample custom culture.

    Console.Clear();
    Console.WriteLine("CultureName:. . . . . . . . . . {0}", cib.CultureName);
    Console.WriteLine("CultureEnglishName: . . . . . . {0}", cib.CultureEnglishName);
    Console.WriteLine("CultureNativeName:. . . . . . . {0}", cib.CultureNativeName);
    Console.WriteLine("GeoId:. . . . . . . . . . . . . {0}", cib.GeoId);
    Console.WriteLine("IsMetric: . . . . . . . . . . . {0}", cib.IsMetric);
    Console.WriteLine("ISOCurrencySymbol:. . . . . . . {0}", cib.ISOCurrencySymbol);
    Console.WriteLine("RegionEnglishName:. . . . . . . {0}", cib.RegionEnglishName);
    Console.WriteLine("RegionName: . . . . . . . . . . {0}", cib.RegionName);
    Console.WriteLine("RegionNativeName: . . . . . . . {0}", cib.RegionNativeName);
    Console.WriteLine("ThreeLetterISOLanguageName: . . {0}", cib.ThreeLetterISOLanguageName);
    Console.WriteLine("ThreeLetterISORegionName: . . . {0}", cib.ThreeLetterISORegionName);
    Console.WriteLine("ThreeLetterWindowsLanguageName: {0}", cib.ThreeLetterWindowsLanguageName);
    Console.WriteLine("ThreeLetterWindowsRegionName: . {0}", cib.ThreeLetterWindowsRegionName);
    Console.WriteLine("TwoLetterISOLanguageName: . . . {0}", cib.TwoLetterISOLanguageName);
    Console.WriteLine("TwoLetterISORegionName: . . . . {0}", cib.TwoLetterISORegionName);
    }
}
/*
This code example produces the following results:

CultureName:. . . . . . . . . . x-en-US-sample
CultureEnglishName: . . . . . . English
CultureNativeName:. . . . . . . English
GeoId:. . . . . . . . . . . . . 244
IsMetric: . . . . . . . . . . . False
ISOCurrencySymbol:. . . . . . . USD
RegionEnglishName:. . . . . . . United States
RegionName: . . . . . . . . . . US
RegionNativeName: . . . . . . . United States
ThreeLetterISOLanguageName: . . eng
ThreeLetterISORegionName: . . . USA
ThreeLetterWindowsLanguageName: ENU
ThreeLetterWindowsRegionName: . USA
TwoLetterISOLanguageName: . . . en
TwoLetterISORegionName: . . . . US

*/
//</snippet1>