' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Numerics

<Assembly: CLSCompliant(True)>

Public Module Numbers
   Public Function GetSquares(numbers As Byte()) As Byte()
      Dim numbersOut(numbers.Length - 1) As Byte
      For ctr As Integer = 0 To numbers.Length - 1
         Dim square As Integer = (CInt(numbers(ctr)) * CInt(numbers(ctr))) 
         If square <= Byte.MaxValue Then
            numbersOut(ctr) = CByte(square)
         ' If there's an overflow, assign MaxValue to the corresponding 
         ' element.
         Else
            numbersOut(ctr) = Byte.MaxValue
         End If   
      Next
      Return numbersOut
   End Function

   Public Function GetSquares(numbers As BigInteger()) As BigInteger()
      Dim numbersOut(numbers.Length - 1) As BigInteger
      For ctr As Integer = 0 To numbers.Length - 1
         numbersOut(ctr) = numbers(ctr) * numbers(ctr) 
      Next
      Return numbersOut
   End Function
End Module
' </Snippet10>

Module Example
   Public Sub Main()
       Dim bytes() As Byte = Numbers.GetSquares( { CByte(3), CByte(10), 
                                                   CByte(13), CByte(20) } )
       For Each byt In bytes
          Console.Write("{0}  ", byt)
       Next
       Console.WriteLine()
       Dim bigs() As BigInteger = { 1034, 1058, 100, 12399 }
       For Each bigSquare In Numbers.GetSquares(bigs)
          Console.Write("{0:N0}  ", bigSquare)
       Next
       Console.WriteLine()
   End Sub
End Module

