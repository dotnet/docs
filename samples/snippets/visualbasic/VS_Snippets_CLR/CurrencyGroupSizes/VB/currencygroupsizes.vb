' The following code example demonstrates the effect of changing the CurrencyGroupSizes property.

' <snippet1>
Imports System.Globalization

Class NumberFormatInfoSample
   
   
   Public Shared Sub Main()

      ' Gets a NumberFormatInfo associated with the en-US culture.
      Dim nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat

      ' Displays a value with the default separator (".").
      Dim myInt As Int64 = 123456789012345
      Console.WriteLine(myInt.ToString("C", nfi))

      ' Displays the same value with different groupings.
      Dim mySizes1 As Integer() =  {2, 3, 4}
      Dim mySizes2 As Integer() =  {2, 3, 0}
      nfi.CurrencyGroupSizes = mySizes1
      Console.WriteLine(myInt.ToString("C", nfi))
      nfi.CurrencyGroupSizes = mySizes2
      Console.WriteLine(myInt.ToString("C", nfi))

   End Sub

End Class

 
'This code produces the following output.
'
'$123,456,789,012,345.00
'$12,3456,7890,123,45.00
'$1234567890,123,45.00

' </snippet1>
