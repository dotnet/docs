' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim obj() As object = { 0, 10, 100, New BigInteger(1000), -10 }
      Dim bi() As BigInteger = { BigInteger.Zero, New BigInteger(10),
                                 New BigInteger(100), New BigInteger(1000),
                                 New BigInteger(-10) }
      For ctr As Integer = 0 To bi.Length - 1
         Console.WriteLine(bi(ctr).Equals(obj(ctr)))
      Next                           
   End Sub
End Module
' The example displays the following output:
'       False
'       False
'       False
'       True
'       False
' </Snippet3>
