' Visual Basic .NET Document
Option Strict On
Option Infer On 

' <Snippet1>
Module Example
   Public Sub Main()
      ' Create five 8-tuple objects containing prime numbers.
      Dim prime1 = New Tuple(Of Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple(Of Int32)) (2, 3, 5, 7, 11, 13, 17, 
                           New Tuple(Of Int32)(19))
      Dim prime2 = New Tuple(Of Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple(Of Int32)) (23, 29, 31, 37, 41, 43, 47, 
                           New Tuple(Of Int32)(55)) 
      Dim prime3 = New Tuple(Of Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple(Of Int32)) (3, 2, 5, 7, 11, 13, 17, 
                           New Tuple(Of Int32)(19)) 
      Dim prime4 = New Tuple(Of Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple(Of Int32, Int32)) (2, 3, 5, 7, 11, 13, 17, 
                           New Tuple(Of Int32, Int32)(19, 23))
      Dim prime5 = New Tuple(Of Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple(Of Int32)) (2, 3, 5, 7, 11, 13, 17, 
                           New Tuple(Of Int32)(19))
      Console.WriteLine("{0} = {1} : {2}", prime1, prime2, prime1.Equals(prime2))
      Console.WriteLine("{0} = {1} : {2}", prime1, prime3, prime1.Equals(prime3))
      Console.WriteLine("{0} = {1} : {2}", prime1, prime4, prime1.Equals(prime4))
      Console.WriteLine("{0} = {1} : {2}", prime1, prime5, prime1.Equals(prime5))
   End Sub
End Module
' The example displays the following output:
'    (2, 3, 5, 7, 11, 13, 17, 19) = (23, 29, 31, 37, 41, 43, 47, 55) : False
'    (2, 3, 5, 7, 11, 13, 17, 19) = (3, 2, 5, 7, 11, 13, 17, 19) : False
'    (2, 3, 5, 7, 11, 13, 17, 19) = (2, 3, 5, 7, 11, 13, 17, 19, 23) : False
'    (2, 3, 5, 7, 11, 13, 17, 19) = (2, 3, 5, 7, 11, 13, 17, 19) : True
' </Snippet1>
