' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim values() As String = { Convert.ToString(12, 16), _
                                 Convert.ToString(123, 16), _
                                 Convert.ToString(245, 16) }
      
      Dim mask As Byte = &hFE
      For Each value As String In values
         Dim byteValue As Byte = Byte.Parse(value, NumberStyles.AllowHexSpecifier)
         Console.WriteLine("{0} And {1} = {2}", byteValue, mask, _ 
                           byteValue And mask)
      Next         
   End Sub
End Module
' The example displays the following output:
'       12 And 254 = 12
'       123 And 254 = 122
'       245 And 254 = 244
' </Snippet1>
