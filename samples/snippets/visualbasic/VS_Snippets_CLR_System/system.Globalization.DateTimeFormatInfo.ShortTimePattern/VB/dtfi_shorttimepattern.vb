' The following code example displays the value of ShortTimePattern for selected cultures.

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
      Console.WriteLine("  {0}     {1}", myCulture, myDTFI.ShortTimePattern)

   End Sub 'PrintPattern 

End Class 'SamplesDTFI

'This code produces the following output.
'
' CULTURE    PROPERTY VALUE
'  en-US     h:mm tt
'  ja-JP     H:mm
'  fr-FR     HH:mm
'
' </snippet1>
