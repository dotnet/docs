' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Enum SignMagnitude As Integer
   Negative = -1 
   Zero = 0
   Positive = 1
End Enum
   
Module Example
   Public Sub Main()
      Dim values() As Integer = CType([Enum].GetValues(GetType(SignMagnitude)), Integer())
      For Each value In values
         Console.WriteLine("{0,3}     0x{0:X8}     {1}",
                           value, CType(value, SignMagnitude).ToString())
      Next
   End Sub
End Module
' The example displays the following output:
'      0     0x00000000     Zero
'      1     0x00000001     Positive
'     -1     0xFFFFFFFF     Negative
' </Snippet1>
