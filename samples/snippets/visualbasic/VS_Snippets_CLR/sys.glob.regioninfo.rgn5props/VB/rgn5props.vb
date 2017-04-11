'<snippet1>
' This example demonstrates the RegionInfo.EnglishName, NativeName, 
' CurrencyEnglishName, CurrencyNativeName, and GeoId properties.
Imports System
Imports System.Globalization

Class Sample
   Public Shared Sub Main()
      Dim ri As New RegionInfo("SE") ' Sweden
      Console.Clear()
      Console.WriteLine("Region English Name: . . . {0}", ri.EnglishName)
      Console.WriteLine("Native Name: . . . . . . . {0}", ri.NativeName)
      Console.WriteLine("Currency English Name: . . {0}", ri.CurrencyEnglishName)
      Console.WriteLine("Currency Native Name:. . . {0}", ri.CurrencyNativeName)
      Console.WriteLine("Geographical ID: . . . . . {0}", ri.GeoId)
   End Sub 'Main
End Class 'Sample
'
'This code example produces the following results:
'
'Region English Name: . . . Sweden
'Native Name: . . . . . . . Sverige
'Currency English Name: . . Swedish Krona
'Currency Native Name:. . . Svensk krona
'Geographical ID: . . . . . 221
'
'</snippet1>