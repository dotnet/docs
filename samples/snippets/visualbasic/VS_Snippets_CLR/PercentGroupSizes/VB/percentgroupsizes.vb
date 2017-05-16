' The following code example demonstrates the effect of changing the PercentGroupSizes property.

' <snippet1>
Imports System
Imports System.Globalization

Class NumberFormatInfoSample

   Public Shared Sub Main()

      ' Gets a NumberFormatInfo associated with the en-US culture.
      Dim nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat

      ' Displays a value with the default separator (".").
      Dim myInt As [Double] = 123456789012345.6789
      Console.WriteLine(myInt.ToString("P", nfi))

      ' Displays the same value with different groupings.
      Dim mySizes1 As Integer() =  {2, 3, 4}
      Dim mySizes2 As Integer() =  {2, 3, 0}
      nfi.PercentGroupSizes = mySizes1
      Console.WriteLine(myInt.ToString("P", nfi))
      nfi.PercentGroupSizes = mySizes2
      Console.WriteLine(myInt.ToString("P", nfi))

   End Sub 'Main 

End Class 'NumberFormatInfoSample


'This code produces the following output.
'
'12,345,678,901,234,600.00 %
'1234,5678,9012,346,00.00 %
'123456789012,346,00.00 %

' </snippet1>
