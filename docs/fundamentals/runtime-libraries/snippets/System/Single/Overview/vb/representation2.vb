' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      Dim value As Single = 123.456
      Dim additional As Single = Single.Epsilon * 1e15
      Console.WriteLine($"{value} + {additional} = {value + additional}")
   End Sub
End Module
' The example displays the following output:
'   123.456 + 1.401298E-30 = 123.456
' </Snippet4>

