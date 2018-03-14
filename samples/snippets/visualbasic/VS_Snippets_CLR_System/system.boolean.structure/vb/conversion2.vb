' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example
   Public Sub Main()
      Dim dbl As Double = 1
      Dim iterations As Integer = 0
      For ctr As Integer = 1 To 5
         dbl += .2
         iterations += 1
      Next
      dbl -= 1 + iterations * .2
      Console.WriteLine("{0} --> {1}", dbl, Convert.ToBoolean(dbl))
   End Sub
End Module
' The example displays the following output:
'       -2.22044604925031E-16 --> True
' </Snippet7>
