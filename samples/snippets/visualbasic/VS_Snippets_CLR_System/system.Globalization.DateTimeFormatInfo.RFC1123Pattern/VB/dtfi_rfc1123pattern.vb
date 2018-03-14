' The following code example displays the value of RFC1123Pattern for selected cultures.

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
      Console.WriteLine("  {0}     {1}", myCulture, myDTFI.RFC1123Pattern)

   End Sub 'PrintPattern 

End Class 'SamplesDTFI

'This code produces the following output.
'
' CULTURE    PROPERTY VALUE
'  en-US     ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
'  ja-JP     ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
'  fr-FR     ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
'
' </snippet1>
