' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim value, complement As bigInteger
      
      value = BigInteger.Multiply(BigInteger.One, 9)
      complement = Not value
      
      Console.WriteLine("{0,5} -- {1,-32}", value, DisplayInBinary(value))
      Console.WriteLine("{0,5} -- {1,-32}", complement, DisplayInBinary(complement))
      Console.WriteLine()
   
      value = BigInteger.MinusOne * SByte.MaxValue
      complement = BigInteger.op_OnesComplement(value)
      
      Console.WriteLine("{0,5} -- {1,-32}", value, DisplayInBinary(value))
      Console.WriteLine("{0,5} -- {1,-32}", complement, DisplayInBinary(complement))
      Console.WriteLine()
   End Sub

   Private Function DisplayInBinary(number As BigInteger) As String
      Dim bytes() As Byte = number.ToByteArray()  
      Dim binaryString As String = String.Empty
      For Each byteValue As Byte In bytes
         Dim byteString As String = Convert.ToString(byteValue, 2).Trim()
         binaryString += byteString.Insert(0, New String("0"c, 8 - byteString.Length))
      Next
      Return binaryString    
   End Function
End Module
' The example displays the following output:
'           9 -- 00001001
'         -10 -- 11110110
'       
'        -127 -- 10000001
'         126 -- 01111110
' </Snippet1>
