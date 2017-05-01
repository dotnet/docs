' The following code example demonstrates the effect of changing the PercentDecimalDigits property.

' <snippet1>
Imports System
Imports System.Globalization

Class NumberFormatInfoSample

   Public Shared Sub Main()

      ' Gets a NumberFormatInfo associated with the en-US culture.
      Dim nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat

      ' Displays a negative value with the default number of decimal digits (2).
      Dim myInt As [Double] = 0.1234
      Console.WriteLine(myInt.ToString("P", nfi))

      ' Displays the same value with four decimal digits.
      nfi.PercentDecimalDigits = 4
      Console.WriteLine(myInt.ToString("P", nfi))

   End Sub 'Main 

End Class 'NumberFormatInfoSample


'This code produces the following output.
'
'12.34 %
'12.3400 %

' </snippet1>
