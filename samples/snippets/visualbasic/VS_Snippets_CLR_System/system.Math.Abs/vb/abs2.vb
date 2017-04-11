' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim doubles() As Double = { Double.MaxValue, 16.354e-17, 15.098123, 0, _
                                  -19.069713, -15.058e18, Double.MinValue }
      For Each value As Double In doubles
         Console.WriteLine("Abs({0}) = {1}", value, Math.Abs(value))
      Next
   End Sub
End Module
' The example displays the following output:
'       Abs(1.79769313486232E+308) = 1.79769313486232E+308
'       Abs(1.6354E-16) = 1.6354E-16
'       Abs(15.098123) = 15.098123
'       Abs(0) = 0
'       Abs(-19.069713) = 19.069713
'       Abs(-1.5058E+19) = 1.5058E+19
'       Abs(-1.79769313486232E+308) = 1.79769313486232E+308
' </Snippet2>
