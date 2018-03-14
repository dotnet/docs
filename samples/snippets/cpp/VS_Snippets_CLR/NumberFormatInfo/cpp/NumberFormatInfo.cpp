//Types:System.Globalization.NumberFormatInfo Vendor: Richter
//<snippet1>
using namespace System;
using namespace System::Globalization;
using namespace System::Text;

int main()
{
    StringBuilder^ builder = gcnew StringBuilder();

    // Loop through all the specific cultures known to the CLR.
    for each(CultureInfo^ culture in 
        CultureInfo::GetCultures (CultureTypes::SpecificCultures)) 
    {
        // Only show the currency symbols for cultures 
        // that speak English.
        if (culture->TwoLetterISOLanguageName == "en")
        {
            //<snippet2>
            // Display the culture name and currency symbol.
            NumberFormatInfo^ numberFormat = culture->NumberFormat;
            builder->AppendFormat("The currency symbol for '{0}'"+
                "is '{1}'",culture->DisplayName,
                numberFormat->CurrencySymbol);
            builder->AppendLine();
            //</snippet2>
        }
    }
    Console::WriteLine(builder);
}

// This code produces the following output.
//
// The currency symbol for 'English (United States)' is '$'
// The currency symbol for 'English (United Kingdom)' is 'Ј'
// The currency symbol for 'English (Australia)' is '$'
// The currency symbol for 'English (Canada)' is '$'
// The currency symbol for 'English (New Zealand)' is '$'
// The currency symbol for 'English (Ireland)' is '?'
// The currency symbol for 'English (South Africa)' is 'R'
// The currency symbol for 'English (Jamaica)' is 'J$'
// The currency symbol for 'English (Caribbean)' is '$'
// The currency symbol for 'English (Belize)' is 'BZ$'
// The currency symbol for 'English (Trinidad and Tobago)' is 'TT$'
// The currency symbol for 'English (Zimbabwe)' is 'Z$'
// The currency symbol for 'English (Republic of the Philippines)' is 'Php'
//</snippet1>