// <Snippet2>
using System;
using System.Globalization;
using System.Reflection;

public class Example
{
    public static void Main()
    {
        // Instantiate three Belgian RegionInfo objects.
        RegionInfo BE = new RegionInfo("BE");
        RegionInfo frBE = new RegionInfo("fr-BE");
        RegionInfo nlBE = new RegionInfo("nl-BE");

        RegionInfo[] regions = { BE, frBE, nlBE };
        PropertyInfo[] props = typeof(RegionInfo).GetProperties(BindingFlags.Instance | BindingFlags.Public);

        Console.WriteLine("{0,-30}{1,18}{2,18}{3,18}\n",
                          "RegionInfo Property", "BE", "fr-BE", "nl-BE");
        foreach (var prop in props)
        {
            Console.Write("{0,-30}", prop.Name);
            foreach (var region in regions)
                Console.Write("{0,18}", prop.GetValue(region, null));

            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//    RegionInfo Property                           BE             fr-BE             nl-BE
//
//    Name                                          BE             fr-BE             nl-BE
//    EnglishName                              Belgium           Belgium           Belgium
//    DisplayName                              Belgium           Belgium           Belgium
//    NativeName                                België          Belgique            België
//    TwoLetterISORegionName                        BE                BE                BE
//    ThreeLetterISORegionName                     BEL               BEL               BEL
//    ThreeLetterWindowsRegionName                 BEL               BEL               BEL
//    IsMetric                                    True              True              True
//    GeoId                                         21                21                21
//    CurrencyEnglishName                         Euro              Euro              Euro
//    CurrencyNativeName                          euro              euro              euro
//    CurrencySymbol                                 €                 €                 €
//    ISOCurrencySymbol                            EUR               EUR               EUR
// </Snippet2>
