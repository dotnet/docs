' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim current1 As NumberFormatInfo = NumberFormatInfo.CurrentInfo
      current1 = CType(current1.Clone(), NumberFormatInfo)
      Console.WriteLine(current1.IsReadOnly)

      Dim culture2 As CultureInfo = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name)
      Dim current2 As NumberFormatInfo = culture2.NumberFormat
      Console.WriteLine(current2.IsReadOnly)
   End Sub
End Module
' The example displays the following output:
'       False
'       False
' </Snippet2>
