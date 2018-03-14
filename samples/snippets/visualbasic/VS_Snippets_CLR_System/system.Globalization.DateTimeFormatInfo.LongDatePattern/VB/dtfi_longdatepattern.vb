' The following code example displays the value of LongDatePattern for selected cultures.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesDTFI

   Public Shared Sub Main()

      ' Displays the values of the pattern properties.
      Console.WriteLine(" CULTURE    PROPERTY VALUE")
      PrintPattern("en-US")
      PrintPattern("ja-JP")
      PrintPattern("fr-FR")

   End Sub 'Main

   Public Shared Sub PrintPattern(myCulture As [String])

      Dim myDTFI As DateTimeFormatInfo = New CultureInfo(myCulture, False).DateTimeFormat
      Console.WriteLine("  {0}     {1}", myCulture, myDTFI.LongDatePattern)

   End Sub 'PrintPattern 

End Class 'SamplesDTFI

'This code produces the following output.  The question marks take the place of native script characters.
'
' CULTURE    PROPERTY VALUE
'  en-US     dddd, MMMM dd, yyyy
'  ja-JP     yyyy'?'M'?'d'?'
'  fr-FR     dddd d MMMM yyyy
'
' </snippet1>