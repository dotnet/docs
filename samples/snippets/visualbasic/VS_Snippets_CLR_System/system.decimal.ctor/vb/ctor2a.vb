' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As Decimal = { 1234.96d, -1234.96d }
      For Each value In values
         Dim parts() = Decimal.GetBits(value)
         Dim sign As Boolean = (parts(3) And &h80000000) <> 0
         Dim scale As Byte = CByte((parts(3) >> 16) And &H7F)
   
         Dim newValue As New Decimal(parts(0), parts(1), parts(2), sign, scale)    
         Console.WriteLine("{0} --> {1}", value, newValue)
      Next   
   End Sub
End Module
' The example displays the following output:
'    1234.96 --> 1234.96
'    -1234.96 --> -1234.96
' </Snippet1>

