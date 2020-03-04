//<snippet1>
// This example demonstrates a System.Globalization.Culture-
// AndRegionInfoBuilder constructor and some of the properties 
// of a custom culture object created with the constructor.

#using <sysglobl.dll>

using namespace System;
using namespace System::Globalization;

int main()
{
    CultureAndRegionInfoBuilder^ builder = 
        gcnew CultureAndRegionInfoBuilder
        ("x-en-US-sample", CultureAndRegionModifiers::None);
    
    // Display some of the properties 
    // for the en-US culture.
    Console::WriteLine("CultureName:. . . . . . . . . . {0}", 
        builder->CultureName);
    Console::WriteLine("CultureEnglishName: . . . . . . {0}", 
        builder->CultureEnglishName);
    Console::WriteLine("CultureNativeName:. . . . . . . {0}", 
        builder->CultureNativeName);
    Console::WriteLine("GeoId:. . . . . . . . . . . . . {0}", 
        builder->GeoId);
    Console::WriteLine("IsMetric: . . . . . . . . . . . {0}", 
        builder->IsMetric);
    Console::WriteLine("ISOCurrencySymbol:. . . . . . . {0}", 
        builder->ISOCurrencySymbol);
    Console::WriteLine("RegionEnglishName:. . . . . . . {0}", 
        builder->RegionEnglishName);
    Console::WriteLine("RegionName: . . . . . . . . . . {0}", 
        builder->RegionName);
    Console::WriteLine("RegionNativeName: . . . . . . . {0}", 
        builder->RegionNativeName);
    Console::WriteLine("ThreeLetterISOLanguageName: . . {0}", 
        builder->ThreeLetterISOLanguageName);
    Console::WriteLine("ThreeLetterISORegionName: . . . {0}", 
        builder->ThreeLetterISORegionName);
    Console::WriteLine("ThreeLetterWindowsLanguageName: {0}", 
        builder->ThreeLetterWindowsLanguageName);
    Console::WriteLine("ThreeLetterWindowsRegionName: . {0}", 
        builder->ThreeLetterWindowsRegionName);
    Console::WriteLine("TwoLetterISOLanguageName: . . . {0}", 
        builder->TwoLetterISOLanguageName);
    Console::WriteLine("TwoLetterISORegionName: . . . . {0}", 
        builder->TwoLetterISORegionName);
}

/*
This code example produces the following results:

CultureName:. . . . . . . . . . en-US
CultureEnglishName: . . . . . . English (United States)
CultureNativeName:. . . . . . . English (United States)
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
