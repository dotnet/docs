' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim number As BigInteger = 10
      Dim exponent As Integer = 3
      Dim modulus As BigInteger = 30
      Console.WriteLine("({0}^{1}) Mod {2} = {3}", _
                        number, exponent, modulus, _
                        BigInteger.ModPow(number, exponent, modulus))
   End Sub   
End Module
' The example displays the following output:
'       (10^3) Mod 30 = 10      
' </Snippet1>

