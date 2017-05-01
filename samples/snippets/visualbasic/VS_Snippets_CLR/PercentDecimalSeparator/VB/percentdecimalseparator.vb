' The following code example demonstrates the effect of changing the PercentDecimalSeparator property.

' <snippet1>
Imports System
Imports System.Globalization

Class NumberFormatInfoSample

   Public Shared Sub Main()

      ' Gets a NumberFormatInfo associated with the en-US culture.
      Dim nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat

      ' Displays a value with the default separator (".").
      Dim myInt As [Double] = 0.1234
      Console.WriteLine(myInt.ToString("P", nfi))

      ' Displays the same value with a blank as the separator.
      nfi.PercentDecimalSeparator = " "
      Console.WriteLine(myInt.ToString("P", nfi))

   End Sub 'Main 

End Class 'NumberFormatInfoSample


'This code produces the following output.
'
'12.34 %
'12 34 %

' </snippet1>
