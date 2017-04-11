' Visual Basic .NET Document
Option Strict On
Option Infer On

Module modMain
   Public Sub Main()
      ' <Snippet1>
      Dim primes = New Tuple(Of Int32, Int32, Int32, Int32, Int32, Int32, Int32, _ 
                   Tuple(Of Int32))(2, 3, 5, 7, 11, 13, 17, New Tuple(Of Int32)(19))
      ' </Snippet1>
      Console.WriteLine(primes.ToString())
   End Sub
End Module

