' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      For value As Decimal = 100d To 102d Step .1d
         Console.WriteLine("{0} --> {1}", value, Decimal.Round(value))
      Next
   End Sub
End Module
' The example displays the following output:
'     100 --> 100
'     100.1 --> 100
'     100.2 --> 100
'     100.3 --> 100
'     100.4 --> 100
'     100.5 --> 100
'     100.6 --> 101
'     100.7 --> 101
'     100.8 --> 101
'     100.9 --> 101
'     101.0 --> 101
'     101.1 --> 101
'     101.2 --> 101
'     101.3 --> 101
'     101.4 --> 101
'     101.5 --> 102
'     101.6 --> 102
'     101.7 --> 102
'     101.8 --> 102
'     101.9 --> 102
'     102.0 --> 102
' </Snippet1>
