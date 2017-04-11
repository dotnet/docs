' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim current1 As NumberFormatInfo = CultureInfo.CurrentCulture.NumberFormat
      Console.WriteLine(current1.IsReadOnly)
      
      Dim current2 As NumberFormatInfo = NumberFormatInfo.CurrentInfo
      Console.WriteLine(current2.IsReadOnly)
      
      Dim current3 As NumberFormatInfo = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture)
      Console.WriteLine(current3.IsReadOnly)
   End Sub
End Module
' The example displays the following output:
'       True
'       True
'       True
' </Snippet1>

