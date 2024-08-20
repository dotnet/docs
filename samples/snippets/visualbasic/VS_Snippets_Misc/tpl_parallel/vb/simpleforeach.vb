'<snippet03>
Imports System.Collections.Concurrent

Namespace ParallelExample
    Class Program
        Shared Sub Main()
            ' 2 million
            Dim limit = 2_000_000
            Dim numbers = Enumerable.Range(0, limit).ToList()

            Dim watch = Stopwatch.StartNew()
            Dim primeNumbersFromForeach = GetPrimeList(numbers)
            watch.Stop()

            Dim watchForParallel = Stopwatch.StartNew()
            Dim primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers)
            watchForParallel.Stop()

            Console.WriteLine($"Classical foreach loop | Total prime numbers : {primeNumbersFromForeach.Count} | Time Taken : {watch.ElapsedMilliseconds} ms.")
            Console.WriteLine($"Parallel.ForEach loop  | Total prime numbers : {primeNumbersFromParallelForeach.Count} | Time Taken : {watchForParallel.ElapsedMilliseconds} ms.")

            Console.WriteLine("Press 'Enter' to exit.")
            Console.ReadLine()
        End Sub

        ' GetPrimeList returns Prime numbers by using sequential ForEach
        Private Shared Function GetPrimeList(numbers As IList(Of Integer)) As IList(Of Integer)
            Return numbers.Where(AddressOf IsPrime).ToList()
        End Function

        ' GetPrimeListWithParallel returns Prime numbers by using Parallel.ForEach
        Private Shared Function GetPrimeListWithParallel(numbers As IList(Of Integer)) As IList(Of Integer)
            Dim primeNumbers = New ConcurrentBag(Of Integer)()
            Parallel.ForEach(numbers, Sub(number)

                                          If IsPrime(number) Then
                                              primeNumbers.Add(number)
                                          End If
                                      End Sub)
            Return primeNumbers.ToList()
        End Function

        ' IsPrime returns true if number is Prime, else false.(https://en.wikipedia.org/wiki/Prime_number)
        Private Shared Function IsPrime(number As Integer) As Boolean
            If number < 2 Then
                Return False
            End If

            For divisor = 2 To Math.Sqrt(number)

                If number Mod divisor = 0 Then
                    Return False
                End If
            Next

            Return True
        End Function
    End Class
End Namespace
'</snippet03>