' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim nfi As NumberFormatInfo
      
      nfi = System.Globalization.NumberFormatInfo.InvariantInfo
      Console.WriteLine(nfi.IsReadOnly)               
      
      nfi = CultureInfo.InvariantCulture.NumberFormat
      Console.WriteLine(nfi.IsReadOnly)               
      
      nfi = New NumberFormatInfo()
      Console.WriteLine(nfi.IsReadOnly)               
   End Sub
End Module
' The example displays the following output:
'       True
'       True
'       False
' </Snippet4>
