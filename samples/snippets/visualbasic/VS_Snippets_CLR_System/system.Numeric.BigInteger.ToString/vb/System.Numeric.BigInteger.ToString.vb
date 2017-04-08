' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.Numerics

Module modMain
   Public Sub Main()
      CallToString1()
      Console.WriteLine()
      CallToString2()
      Console.WriteLine()
      CallToString3()
   End Sub
   
   Private Sub CallToString1()
      ' <Snippet1>
      Dim number As BigInteger = 9867857831128
      number = BigInteger.Pow(number, 3) * BigInteger.MinusOne
      
      Dim bigIntegerProvider As New NumberFormatInfo()
      bigIntegerProvider.NegativeSign = "~"      
      
      Console.WriteLine(number.ToString(bigIntegerProvider))
      ' </Snippet1>
   End Sub
   
   Private Sub CallToString2()
      ' <Snippet2>
      Dim number As BigInteger = 9867857831128
      Console.WriteLine(number.ToString("G"))          ' Displays 9867857831128
      Console.WriteLine(number.ToString("D"))          ' Displays 9867857831128
      Console.WriteLine("0x{0}", number.ToString("X")) ' Displays 0x8F98A2924D8
      ' </Snippet2>
   End Sub
   
   Private Sub CallToString3()
      ' <Snippet3>
      Dim bigIntegerFormat As New NumberFormatInfo()
      bigIntegerFormat.NegativeSign = "~"
       
      Dim number As BigInteger = New BigInteger(-9867857831128)
      Console.WriteLine(number.ToString("G", bigIntegerFormat))          ' Displays 9867857831128
      Console.WriteLine(number.ToString("D:15", bigIntegerFormat))          ' Displays 9867857831128
      Console.WriteLine(number.ToString("X", bigIntegerFormat))          ' Displays 8F98A2924D8
     ' </Snippet3>
   End Sub
End Module

