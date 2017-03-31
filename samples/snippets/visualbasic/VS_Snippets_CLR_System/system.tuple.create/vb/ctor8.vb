' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
       ' <Snippet20>
       Dim primes As New Tuple(Of Integer, Integer, Integer, Integer, 
                                  Integer, Integer, Integer, 
                                  Tuple(Of Integer)) _
                              (2, 3, 5, 7, 11, 13, 17, 
                               New Tuple(Of Integer)(19))
      ' </Snippet20>
      Console.WriteLine(primes.ToString())
   End Sub
End Module

