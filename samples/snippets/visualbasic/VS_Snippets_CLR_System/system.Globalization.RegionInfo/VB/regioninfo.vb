' The following code example demonstrates several members of the RegionInfo class.

' <snippet1>
Imports System.Globalization


Public Class SamplesRegionInfo   

   Public Shared Sub Main()

      ' Displays the property values of the RegionInfo for "US".
      Dim myRI1 As New RegionInfo("US")
      Console.WriteLine("   Name:                         {0}", myRI1.Name)
      Console.WriteLine("   DisplayName:                  {0}", myRI1.DisplayName)
      Console.WriteLine("   EnglishName:                  {0}", myRI1.EnglishName)
      Console.WriteLine("   IsMetric:                     {0}", myRI1.IsMetric)
      Console.WriteLine("   ThreeLetterISORegionName:     {0}", myRI1.ThreeLetterISORegionName)
      Console.WriteLine("   ThreeLetterWindowsRegionName: {0}", myRI1.ThreeLetterWindowsRegionName)
      Console.WriteLine("   TwoLetterISORegionName:       {0}", myRI1.TwoLetterISORegionName)
      Console.WriteLine("   CurrencySymbol:               {0}", myRI1.CurrencySymbol)
      Console.WriteLine("   ISOCurrencySymbol:            {0}", myRI1.ISOCurrencySymbol)
      Console.WriteLine()

      ' Compares the RegionInfo above with another RegionInfo created using CultureInfo.
      Dim myRI2 As New RegionInfo(New CultureInfo("en-US", False).LCID)
      If myRI1.Equals(myRI2) Then
         Console.WriteLine("The two RegionInfo instances are equal.")
      Else
         Console.WriteLine("The two RegionInfo instances are NOT equal.")
      End If 

   End Sub

End Class


'This code produces the following output.
'
'   Name:                         US
'   DisplayName:                  United States
'   EnglishName:                  United States
'   IsMetric:                     False
'   ThreeLetterISORegionName:     USA
'   ThreeLetterWindowsRegionName: USA
'   TwoLetterISORegionName:       US
'   CurrencySymbol:               $
'   ISOCurrencySymbol:            USD
'
'The two RegionInfo instances are equal.

' </snippet1>
