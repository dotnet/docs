' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example
   Public Sub Main()
      Dim values() As Double = { 0, Double.Epsilon, Double.Epsilon * .5 }
      
      For ctr As Integer = 0 To values.Length - 2
         For ctr2 As Integer = ctr + 1 To values.Length - 1
            Console.WriteLine("{0:r} = {1:r}: {2}", _
                              values(ctr), values(ctr2), _ 
                              values(ctr).Equals(values(ctr2)))
         Next
         Console.WriteLine()
      Next      
   End Sub
End Module
' The example displays the following output:
'       0 = 4.94065645841247E-324: False
'       0 = 0: True
'       
'       4.94065645841247E-324 = 0: False
' </Snippet5>
