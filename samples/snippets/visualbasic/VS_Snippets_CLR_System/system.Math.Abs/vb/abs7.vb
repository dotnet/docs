' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example
   Public Sub Main()
      Dim values() As Single = { Single.MaxValue, 16.354e-12, 15.098123, 0, _
                                  -19.069713, -15.058e17, Single.MinValue }
      For Each value As Single In values
         Console.WriteLine("Abs({0}) = {1}", value, Math.Abs(value))
      Next
   End Sub
End Module
' The example displays the following output:
'       Abs(3.402823E+38) = 3.402823E+38
'       Abs(1.6354E-11) = 1.6354E-11
'       Abs(15.09812) = 15.09812
'       Abs(0) = 0
'       Abs(-19.06971) = 19.06971
'       Abs(-1.5058E+18) = 1.5058E+18
'       Abs(-3.402823E+38) = 3.402823E+38
' </Snippet7>


