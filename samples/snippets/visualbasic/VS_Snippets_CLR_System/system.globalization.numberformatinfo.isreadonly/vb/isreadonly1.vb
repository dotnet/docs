' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim nfi As NumberFormatInfo = NumberFormatInfo.CurrentInfo
      Console.WriteLine("Read-Only: {0}", nfi.IsReadOnly)
      Console.WriteLine()
      Dim nfiw As NumberFormatInfo = CType(nfi.Clone(), NumberFormatInfo)
      Console.WriteLine("Read-Only: {0}", nfiw.IsReadOnly)
   End Sub
End Module
' The example displays the following output:
'       Read-Only: True
'       
'       Read-Only: False
' </Snippet1>
