' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim number1 As Integer = 3000
      Dim number2 As Integer = 0
      Try
         Console.WriteLine(number1\number2)
      Catch e As DivideByZeroException
         Console.WriteLine("Division of {0} by zero.", number1)
      End Try
   End Sub
End Module
' The example displays the following output:
'       Division of 3000 by zero.
' </Snippet1>
