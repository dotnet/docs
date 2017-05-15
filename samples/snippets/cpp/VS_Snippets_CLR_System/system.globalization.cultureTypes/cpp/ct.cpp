// <snippet1>
// This example demonstrates the CultureTypes enumeration 
// and the CultureInfo.CultureTypes property.

using namespace System;
using namespace System::Globalization;
int main()
{
    // Create a table of most culture types. 
    array<CultureTypes>^ mostCultureTypes = gcnew array<CultureTypes> {
                    CultureTypes::NeutralCultures, 
                    CultureTypes::SpecificCultures, 
                    CultureTypes::InstalledWin32Cultures, 
                    CultureTypes::UserCustomCulture, 
                    CultureTypes::ReplacementCultures, 
                    CultureTypes::FrameworkCultures,
                    CultureTypes::WindowsOnlyCultures
                    };
    CultureTypes combo;

    // Get and enumerate all cultures.
    System::Collections::IEnumerator^ enum0 = CultureInfo::GetCultures(CultureTypes::AllCultures)->GetEnumerator();
    while (enum0->MoveNext())
    {
        // Display the name of each culture.
        CultureInfo^ ci = safe_cast<CultureInfo^>(enum0->Current);
        Console::WriteLine("Culture: {0}", ci->Name);

        // Get the culture types of each culture. 
        combo = ci->CultureTypes;

        // Display the name of each culture type flag that is set.
        Console::Write("  ");
        for each (CultureTypes ct in mostCultureTypes)
            if ((ct & combo) != CultureTypes())
                Console::Write("{0} ", ct);
        Console::WriteLine();
    }
}

/*
The following is a portion of the results produced by this code example.
.
.
.
Culture: tg
  NeutralCultures InstalledWin32Cultures 
Culture: ta
  NeutralCultures InstalledWin32Cultures FrameworkCultures 
Culture: te
  NeutralCultures InstalledWin32Cultures FrameworkCultures 
Culture: syr
  NeutralCultures InstalledWin32Cultures FrameworkCultures 
Culture: tg-Cyrl-TJ
  SpecificCultures InstalledWin32Cultures 
Culture: ta-IN
  SpecificCultures InstalledWin32Cultures FrameworkCultures 
Culture: te-IN
  SpecificCultures InstalledWin32Cultures FrameworkCultures 
Culture: syr-SY
  SpecificCultures InstalledWin32Cultures FrameworkCultures 
Culture: tg-Cyrl
  NeutralCultures InstalledWin32Cultures 
.
.
.
*/
// </snippet1>
