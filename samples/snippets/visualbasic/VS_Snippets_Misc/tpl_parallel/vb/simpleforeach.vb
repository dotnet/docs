'<snippet03>
Imports System.Collections.Concurrent

Namespace ParallelExample
    Class Program
        Shared Sub Main()

            '2 million
            Dim limit As Integer = 2 * 1000000
            Dim inputs = New List(Of Integer)(limit)
            Dim radomGenerator As Random = New Random()

            For index As Integer = 0 To limit - 1
                inputs.Add(radomGenerator.[Next]())
            Next

            Dim watch = New Stopwatch()
            watch.Start()
            Dim primeNumbers = GetPrimeList(inputs)
            watch.Stop()

            Dim watchForParallel = New Stopwatch()
            watchForParallel.Start()
            Dim primeNumbersFromParallel = GetPrimeListWithParallel(inputs)
            watchForParallel.Stop()

            Console.WriteLine($"Classical For loop    | Total prime numbers : {primeNumbersFromParallel.Count} | Time Taken : {watch.ElapsedMilliseconds} ms.")
            Console.WriteLine($"Parallel.ForEach loop | Total prime numbers : {primeNumbersFromParallel.Count} | Time Taken : {watchForParallel.ElapsedMilliseconds} ms.")

            Console.WriteLine("Press any key to exit.")
            Console.ReadLine()
        End Sub

        ' GetPrimeList returns Prime numbers by using sequential ForEach
        Private Shared Function GetPrimeList(inputs As IList(Of Integer)) As IList(Of Integer)
            Dim primeNumbers = New List(Of Integer)()

            For Each item In inputs

                If IsPrime(item) Then
                    primeNumbers.Add(item)
                End If
            Next

            Return primeNumbers
        End Function

        ' GetPrimeListWithParallel returns Prime numbers by using Parallel.ForEach
        Private Shared Function GetPrimeListWithParallel(inputs As IList(Of Integer)) As IList(Of Integer)
            Dim primeNumbers = New ConcurrentBag(Of Integer)()
            Parallel.ForEach(inputs, Sub(item)

                                         If IsPrime(item) Then
                                             primeNumbers.Add(item)
                                         End If
                                     End Sub)
            Return primeNumbers.ToList()
        End Function

        ' IsPrime returns true if number is Prime, else false.(https://en.wikipedia.org/wiki/Prime_number)
        Private Shared Function IsPrime(number As Integer) As Boolean
            If number <= 1 Then
                Return False
            End If

            If number = 2 OrElse number Mod 2 = 0 Then
                Return True
            End If

            Dim limit As Integer = CInt(Math.Floor(Math.Sqrt(number)))

            For index As Integer = 3 To limit Step 2

                If number Mod index = 0 Then
                    Return False
                End If
            Next

            Return True
        End Function
    End Class
End Namespace
'</snippet03>
