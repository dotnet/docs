' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim maxPrime As Integer = 100
      Dim primeList As IEnumerable(Of String) = GetPrimes(maxPrime)
      Console.WriteLine("Primes less than {0}:", maxPrime)
      Console.WriteLine("   {0}", String.Concat(primeList))
   End Sub
   
   Private Function GetPrimes(maxPrime As Integer) As IEnumerable(Of String)
      Dim values As Array = Array.CreateInstance(GetType(Integer), _
                              New Integer() { maxPrime - 1}, New Integer(){ 2 }) 
      ' Use Sieve of Erathsthenes to determine prime numbers.
      For ctr As Integer = values.GetLowerBound(0) To _
                           CInt(Math.Ceiling(Math.Sqrt(values.GetUpperBound(0))))
         If CInt(values.GetValue(ctr)) = 1 Then Continue For
         
         For multiplier As Integer = ctr To maxPrime \ 2
            If ctr * multiplier <= maxPrime Then values.SetValue(1, ctr * multiplier)
         Next   
      Next      
      
      Dim primes As New List(Of String)
      For ctr As Integer = values.GetLowerBound(0) To values.GetUpperBound(0)
         If CInt(values.GetValue(ctr)) = 0 Then primes.Add(ctr.ToString() + " ")
      Next            
      Return primes
   End Function   
End Module
' The example displays the following output:
'    Primes less than 100:
'       2 3 5 7 11 13 17 19 23 29 31 37 41 43 47 53 59 61 67 71 73 79 83 89 97
' </Snippet2>
