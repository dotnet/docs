' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      Dim value As Single = 123456789e4
      Dim additional As Single = Single.Epsilon * 1e12
      Console.WriteLine("{0} + {1} = {2}", value, additional, 
                                           value + additional)
   End Sub
End Module
' The example displays the following output:
'   1.234568E+12 + 1.401298E-33 = 1.234568E+12
' </Snippet4>

