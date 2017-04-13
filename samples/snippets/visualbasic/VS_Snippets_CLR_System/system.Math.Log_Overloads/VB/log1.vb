' <Snippet2>
Module Example
   Sub Main()
      Console.WriteLine( _
         "  Evaluate this identity with selected values for X:")
      Console.WriteLine("                              ln(x) = 1 / log[X](B)")
      Console.WriteLine()
          
      Dim XArgs() As Double = { 1.2, 4.9, 9.9, 0.1 }
   
      For Each argX As Double In XArgs
         ' Find natural log of argX.
         Console.WriteLine("                      Math.Log({0}) = {1:E16}", _
                           argX, Math.Log(argX))

         ' Evaluate 1 / log[X](e).
         Console.WriteLine("             1.0 / Math.Log(e, {0}) = {1:E16}", _
                           argX, 1.0 / Math.Log(Math.E, argX))
         Console.WriteLine()
      Next
   End Sub 
End Module
' This example displays the following output:
'         Evaluate this identity with selected values for X:
'                                     ln(x) = 1 / log[X](B)
'       
'                             Math.Log(1.2) = 1.8232155679395459E-001
'                    1.0 / Math.Log(e, 1.2) = 1.8232155679395459E-001
'       
'                             Math.Log(4.9) = 1.5892352051165810E+000
'                    1.0 / Math.Log(e, 4.9) = 1.5892352051165810E+000
'       
'                             Math.Log(9.9) = 2.2925347571405443E+000
'                    1.0 / Math.Log(e, 9.9) = 2.2925347571405443E+000
'       
'                             Math.Log(0.1) = -2.3025850929940455E+000
'                    1.0 / Math.Log(e, 0.1) = -2.3025850929940455E+000
' </Snippet2>
