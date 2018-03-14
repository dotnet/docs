' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example
   Public Sub Main()
      For value As Decimal = 4.2d To 4.8d Step .1d
         Console.WriteLine("{0} --> {1}", value, Math.Round(value))
      Next   
   End Sub                                                                 
End Module
' The example displays the following output:
'       4.2 --> 4
'       4.3 --> 4
'       4.4 --> 4
'       4.5 --> 4
'       4.6 --> 5
'       4.7 --> 5
'       4.8 --> 5
' </Snippet6>

