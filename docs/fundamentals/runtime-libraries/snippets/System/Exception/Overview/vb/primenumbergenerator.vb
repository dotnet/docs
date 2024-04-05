' <Snippet2>
Imports System.Collections.Generic

<Serializable()> Public Class PrimeNumberGenerator
   Private Const START As Integer = 2
   Private maxUpperBound As Integer = 10000000
   Private upperBound As Integer
   Private primeTable() As Boolean
   Private primes As New List(Of Integer)

   Public Sub New(upperBound As Integer)
      If upperBound > maxUpperBound Then
         Dim message As String = String.Format(
             "{0} exceeds the maximum upper bound of {1}.",
             upperBound, maxUpperBound)
         Throw New ArgumentOutOfRangeException(message)
      End If
      Me.upperBound = upperBound
      ' Create array and mark 0, 1 as not prime (True).
      ReDim primeTable(upperBound)
      primeTable(0) = True
      primeTable(1) = True

      ' Use Sieve of Eratosthenes to determine prime numbers.
      For ctr As Integer = START To CInt(Math.Ceiling(Math.Sqrt(upperBound)))
         If primeTable(ctr) Then Continue For

         For multiplier As Integer = ctr To CInt(upperBound \ ctr)
            If ctr * multiplier <= upperBound Then primeTable(ctr * multiplier) = True
         Next
      Next
      ' Populate array with prime number information.
      Dim index As Integer = START
      Do While index <> -1
         index = Array.FindIndex(primeTable, index, Function(flag)
                                                       Return Not flag
                                                    End Function)
         If index >= 1 Then
            primes.Add(index)
            index += 1
         End If
      Loop
   End Sub

   Public Function GetAllPrimes() As Integer()
      Return primes.ToArray()
   End Function

   Public Function GetPrimesFrom(prime As Integer) As Integer()
      Dim start As Integer = primes.FindIndex(Function(value)
                                                 Return value = prime
                                              End Function)
      If start < 0 Then
         Throw New NotPrimeException(prime, String.Format("{0} is not a prime number.", prime))
      Else
         Return primes.FindAll(Function(value)
                                  Return value >= prime
                               End Function).ToArray()
      End If
   End Function
End Class
' </Snippet2>