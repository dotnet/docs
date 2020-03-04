' The following code example demonstrates the effect of changing the NumberDecimalDigits property.

' <snippet1>
Imports System.Globalization

Class NumberFormatInfoSample

   Public Shared Sub Main()

      ' Gets a NumberFormatInfo associated with the en-US culture.
      Dim nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat

      ' Displays a negative value with the default number of decimal digits (2).
      Dim myInt As Int64 = - 1234
      Console.WriteLine(myInt.ToString("N", nfi))

      ' Displays the same value with four decimal digits.
      nfi.NumberDecimalDigits = 4
      Console.WriteLine(myInt.ToString("N", nfi))

   End Sub

End Class


'This code produces the following output.
'
'-1,234.00
'-1,234.0000

' </snippet1>
