' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim value1 As Single = .1 * 10
      Dim value2 As Single = 0
      For ctr As Integer =  0 To 9
         value2 += CSng(.1)
      Next
               
      Console.WriteLine("{0:R} = {1:R}: {2}", value1, value2,
                        HasMinimalDifference(value1, value2, 1))
   End Sub

   Public Function HasMinimalDifference(value1 As Single, value2 As Single, units As Integer) As Boolean
      Dim bytes() As Byte = BitConverter.GetBytes(value1)
      Dim iValue1 As Integer =  BitConverter.ToInt32(bytes, 0)
      
      bytes = BitConverter.GetBytes(value2)
      Dim iValue2 As Integer =  BitConverter.ToInt32(bytes, 0)
      
      ' If the signs are different, Return False except for +0 and -0.
      If ((iValue1 >> 31) <> (iValue2 >> 31)) Then
         If value1 = value2 Then
            Return True
         End If           
         Return False
      End If

      Dim diff As Integer =  Math.Abs(iValue1 - iValue2)

      If diff <= units Then
         Return True
      End If

      Return False
   End Function
End Module
' The example displays the following output:
'       1 = 1.00000012: True
' </Snippet1>

