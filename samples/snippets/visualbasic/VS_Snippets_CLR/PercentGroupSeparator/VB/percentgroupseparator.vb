' The following code example demonstrates the effect of changing the PercentGroupSeparator property.

' <snippet1>
Imports System.Globalization

Class NumberFormatInfoSample

   Public Shared Sub Main()

      ' Gets a NumberFormatInfo associated with the en-US culture.
      Dim nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat

      ' Displays a value with the default separator (",").
      Dim myInt As [Double] = 1234.5678
      Console.WriteLine(myInt.ToString("P", nfi))

      ' Displays the same value with a blank as the separator.
      nfi.PercentGroupSeparator = " "
      Console.WriteLine(myInt.ToString("P", nfi))

   End Sub

End Class


'This code produces the following output.
'
'123,456.78 %
'123 456.78 %

' </snippet1>
