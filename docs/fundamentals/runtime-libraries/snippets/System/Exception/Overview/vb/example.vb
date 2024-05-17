Option Strict Off

' <Snippet3>
Imports System.Reflection

Module Example
   Sub Main()
      Dim limit As Integer = 10000000
      Dim primes As New PrimeNumberGenerator(limit)
      Dim start As Integer = 1000001
      Try
         Dim values() As Integer = primes.GetPrimesFrom(start)
         Console.WriteLine("There are {0} prime numbers from {1} to {2}",
                           start, limit)
      Catch e As NotPrimeException
         Console.WriteLine("{0} is not prime", e.NonPrime)
         Console.WriteLine(e)
         Console.WriteLine("--------")
      End Try

      Dim domain As AppDomain = AppDomain.CreateDomain("Domain2")
      Dim gen As PrimeNumberGenerator = domain.CreateInstanceAndUnwrap(
                                        GetType(Example).Assembly.FullName,
                                        "PrimeNumberGenerator", True,
                                        BindingFlags.Default, Nothing,
                                        {1000000}, Nothing, Nothing)
      Try
         start = 100
         Console.WriteLine(gen.GetPrimesFrom(start))
      Catch e As NotPrimeException
         Console.WriteLine("{0} is not prime", e.NonPrime)
         Console.WriteLine(e)
         Console.WriteLine("--------")
      End Try
   End Sub
End Module
' The example displays the following output:
'      1000001 is not prime
'      NotPrimeException: 1000001 is not a prime number.
'         at PrimeNumberGenerator.GetPrimesFrom(Int32 prime)
'         at Example.Main()
'      --------
'      100 is not prime
'      NotPrimeException: 100 is not a prime number.
'         at PrimeNumberGenerator.GetPrimesFrom(Int32 prime)
'         at Example.Main()
'      --------
' </Snippet3>
