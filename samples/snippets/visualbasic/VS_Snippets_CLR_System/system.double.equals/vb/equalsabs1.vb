' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim value1 As Double = .1 * 10
      Dim value2 As Double = 0
      For ctr As Integer =  0 To 9
         value2 += .1
      Next
               
      Console.WriteLine("{0:R} = {1:R}: {2}", value1, value2,
                        HasMinimalDifference(value1, value2, 1))
   End Sub

   Public Function HasMinimalDifference(value1 As Double, value2 As Double, units As Integer) As Boolean
      Dim lValue1 As long =  BitConverter.DoubleToInt64Bits(value1)
      Dim lValue2 As long =  BitConverter.DoubleToInt64Bits(value2)
      
      ' If the signs are different, Return False except for +0 and -0.
      If ((lValue1 >> 63) <> (lValue2 >> 63)) Then
         If value1 = value2 Then
            Return True
         End If           
         Return False
      End If

      Dim diff As Long =  Math.Abs(lValue1 - lValue2)

      If diff <= units Then
         Return True
      End If

      Return False
   End Function
End Module
' The example displays the following output:
'       1 = 0.99999999999999989: True
' </Snippet1>

