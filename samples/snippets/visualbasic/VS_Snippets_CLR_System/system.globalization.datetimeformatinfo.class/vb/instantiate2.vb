' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim current1 As DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo
      current1 = CType(current1.Clone(), DateTimeFormatInfo)
      Console.WriteLine(current1.IsReadOnly)

      Dim culture2 As CultureInfo = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name)
      Dim current2 As DateTimeFormatInfo = culture2.DateTimeFormat
      Console.WriteLine(current2.IsReadOnly)
   End Sub
End Module
' The example displays the following output:
'       False
'       False
' </Snippet7>
