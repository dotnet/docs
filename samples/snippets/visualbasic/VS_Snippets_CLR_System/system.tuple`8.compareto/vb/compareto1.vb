' Visual Basic .NET Document
Option Strict On
Option Infer On 

' <Snippet1>
Module Example
   Public Sub Main()
      ' Create array of 8-tuple objects containing prime numbers.
      Dim primes() = { New Tuple(Of Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple(Of Int32)) (2, 3, 5, 7, 11, 13, 17, 
                           New Tuple(Of Int32)(19)),
                       New Tuple(Of Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple(Of Int32)) (23, 29, 31, 37, 41, 43, 47, 
                           New Tuple(Of Int32)(55)), 
                       New Tuple(Of Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple(Of Int32)) (3, 2, 5, 7, 11, 13, 17, 
                           New Tuple(Of Int32)(19)) }
      ' Display 8-tuples in unsorted order.
      For Each prime In primes
         Console.WriteLine(prime.ToString())
      Next
      Console.WriteLine()
      
      ' Sort the array and display its 8-tuples.
      Array.Sort(primes)
      For Each prime In primes
         Console.WriteLine(prime.ToString())
      Next
   End Sub
End Module
' The example displays the following output:
'       (2, 3, 5, 7, 11, 13, 17, 19)
'       (23, 29, 31, 37, 41, 43, 47, 55)
'       (3, 2, 5, 7, 11, 13, 17, 19)
'       
'       (2, 3, 5, 7, 11, 13, 17, 19)
'       (3, 2, 5, 7, 11, 13, 17, 19)
'       (23, 29, 31, 37, 41, 43, 47, 55)
' </Snippet1>
