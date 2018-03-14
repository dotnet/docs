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
      Dim names() As String = [Enum].GetNames(GetType(SignMagnitude))
      For Each name In names
         Console.WriteLine("{0,3:D}     0x{0:X}     {1}", 
                           [Enum].Parse(GetType(SignMagnitude), name), 
                           name)
      Next
   End Sub
End Module
' The example displays the following output:
'      0     0x00000000     Zero
'      1     0x00000001     Positive
'     -1     0xFFFFFFFF     Negative
' </Snippet1>
