' Visual Basic .NET Document
Option Strict On
Option Infer On

Module modMain
   Public Sub Main()
      ' <Snippet17>
      Dim primes = Tuple.Create(2, 3, 5, 7, 11, 13, 17, 19)
      Console.WriteLine("Prime numbers less than 20: " + 
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, and {7}",
                        primes.Item1, primes.Item2, primes.Item3, 
                        primes.Item4, primes.Item5, primes.Item6,
                        primes.Item7, primes.Rest.Item1)
      ' The example displays the following output:
      '     Prime numbers less than 20: 2, 3, 5, 7, 11, 13, 17, and 19
      ' </Snippet17>
      Console.WriteLine(primes.ToString())
   End Sub
End Module

