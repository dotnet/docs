' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim decimals() As Decimal = { Decimal.MaxValue, 12.45D, 0D, -19.69D, _
                                    Decimal.MinValue }
      For Each value As Decimal In decimals
         Console.WriteLine("Abs({0}) = {1}", value, Math.Abs(value))
      Next
   End Sub
End Module
' The example displays the following output:
'       Abs(79228162514264337593543950335) = 79228162514264337593543950335
'       Abs(12.45) = 12.45
'       Abs(0) = 0
'       Abs(-19.69) = 19.69
'       Abs(-79228162514264337593543950335) = 79228162514264337593543950335
' </Snippet1>
