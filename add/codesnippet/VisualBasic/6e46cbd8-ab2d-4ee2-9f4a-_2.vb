    ' This method computes the list of prime numbers used by the
    ' IsPrime method.
    Private Function BuildPrimeNumberList( _
        ByVal numberToTest As Integer, _
        ByVal asyncOp As AsyncOperation) As ArrayList

        Dim e As ProgressChangedEventArgs = Nothing
        Dim primes As New ArrayList
        Dim firstDivisor As Integer
        Dim n As Integer = 5

        ' Add the first prime numbers.
        primes.Add(2)
        primes.Add(3)

        ' Do the work.
        While n < numberToTest And _
            Not Me.TaskCanceled(asyncOp.UserSuppliedState)

            If IsPrime(primes, n, firstDivisor) Then
                ' Report to the client that you found a prime.
                e = New CalculatePrimeProgressChangedEventArgs( _
                    n, _
                    CSng(n) / CSng(numberToTest) * 100, _
                    asyncOp.UserSuppliedState)

                asyncOp.Post(Me.onProgressReportDelegate, e)

                primes.Add(n)

                ' Yield the rest of this time slice.
                Thread.Sleep(0)
            End If

            ' Skip even numbers.
            n += 2

        End While

        Return primes

    End Function