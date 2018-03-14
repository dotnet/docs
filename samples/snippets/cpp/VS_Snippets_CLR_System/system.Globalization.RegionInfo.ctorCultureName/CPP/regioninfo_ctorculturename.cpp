// The following code example creates instances of 
// T:System.Globalization.RegionInfo using culture names.

// <snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Globalization;

namespace Sample
{
    public ref class SamplesRegionInfo  
    {
    public: 
        static void Work()  
        {

            // Creates an array containing culture names.
            array <String^>^ commonCultures = 
                {"", "ar", "ar-DZ", "en", "en-US"};

            // Creates a RegionInfo for each of the culture names.
            // Note that "ar" is the culture name for the neutral 
            // culture  "Arabic", but it is also the region name for
            // the country/region "Argentina"; therefore, it does not 
            // fail as expected.
            Console::WriteLine("Without checks...");
            for each (String^ cultureID in commonCultures)
            {   
                try  
                {
                    RegionInfo^ region = 
                    gcnew RegionInfo(cultureID);
                }

                catch (ArgumentException^ ex)  
                {
                    Console::WriteLine(ex);
                }
            }

            Console::WriteLine();

            Console::WriteLine("Checking the culture"
                " names first...");

            for each (String^ cultureID in commonCultures)
            {
                if (cultureID->Length == 0)  
                {
                    Console::WriteLine(
                        "The culture is the invariant culture.");
                }
                else  
                {
                    CultureInfo^ culture = 
                        gcnew CultureInfo(cultureID, false);
                    if (culture->IsNeutralCulture)
                    {
                        Console::WriteLine("The culture {0} is "
                            "a neutral culture.", cultureID);
                    }
                    else   
                    {
                        Console::WriteLine("The culture {0} is "
                            "a specific culture.", cultureID);
                        try  
                        {
                            RegionInfo^ region = 
                                gcnew RegionInfo(cultureID);
                        }
                        catch (ArgumentException^ ex)  
                        {
                            Console::WriteLine(ex);
                        }
                    }
                }
			} 
            Console::ReadLine();
        }
    };
}

int main()
{
    Sample::SamplesRegionInfo::Work();
    return 0;
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
at System.Globalization.CultureTableRecord..ctor(String regionName, 
   Boolean useUserOverride)
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
