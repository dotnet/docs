' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Reflection

Module Example
   Public Sub Main()
      ' Instantiate three Belgian RegionInfo objects.
      Dim BE As New RegionInfo("BE")
      Dim frBE As New RegionInfo("fr-BE")
      Dim nlBE As New RegionInfo("nl-BE")

      Dim regions() As RegionInfo = { BE, frBE, nlBE }
      Dim props() As PropertyInfo = GetType(RegionInfo).GetProperties(BindingFlags.Instance Or BindingFlags.Public)
      
      Console.WriteLine("{0,-30}{1,18}{2,18}{3,18}", 
                        "RegionInfo Property", "BE", "fr-BE", "nl-BE")
      Console.WriteLine()
      For Each prop As PropertyInfo In props
         Console.Write("{0,-30}", prop.Name)
         For Each region In regions
            Console.Write("{0,18}", prop.GetValue(region, Nothing))
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'    RegionInfo Property                           BE             fr-BE             nl-BE
'    
'    Name                                          BE             fr-BE             nl-BE
'    EnglishName                              Belgium           Belgium           Belgium
'    DisplayName                              Belgium           Belgium           Belgium
'    NativeName                                België          Belgique            België
'    TwoLetterISORegionName                        BE                BE                BE
'    ThreeLetterISORegionName                     BEL               BEL               BEL
'    ThreeLetterWindowsRegionName                 BEL               BEL               BEL
'    IsMetric                                    True              True              True
'    GeoId                                         21                21                21
'    CurrencyEnglishName                         Euro              Euro              Euro
'    CurrencyNativeName                          euro              euro              euro
'    CurrencySymbol                                 €                 €                 €
'    ISOCurrencySymbol                            EUR               EUR               EUR
' </Snippet2>
