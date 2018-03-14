' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Divide a series of numbers by 22.1
      Dim dividend As Decimal = 1230.0d
      Dim divisor As Decimal = 22.1d
      For ctr As Integer = 0 To 10
         Console.WriteLine("{0:N1} / {1:N1} = {2:N4}", dividend, divisor,
                           Decimal.Divide(dividend, divisor))
         dividend += .1d 
      Next
   End Sub
End Module
' The example displays the following output:
'       1,230.0 / 22.1 = 55.6561
'       1,230.1 / 22.1 = 55.6606
'       1,230.2 / 22.1 = 55.6652
'       1,230.3 / 22.1 = 55.6697
'       1,230.4 / 22.1 = 55.6742
'       1,230.5 / 22.1 = 55.6787
'       1,230.6 / 22.1 = 55.6833
'       1,230.7 / 22.1 = 55.6878
'       1,230.8 / 22.1 = 55.6923
'       1,230.9 / 22.1 = 55.6968
'       1,231.0 / 22.1 = 55.7014
' </Snippet1>
