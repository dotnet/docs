Imports System.Threading

Module Module1

    Class Account
        Dim thisLock As New Object
        Dim balance As Integer

        Dim r As New Random()

        Public Sub New(ByVal initial As Integer)
            balance = initial
        End Sub

        Public Function Withdraw(ByVal amount As Integer) As Integer
            ' This condition will never be true unless the SyncLock statement
            ' is commented out:
            If balance < 0 Then
                Throw New Exception("Negative Balance")
            End If

            ' Comment out the SyncLock and End SyncLock lines to see
            ' the effect of leaving out the SyncLock keyword.
            SyncLock thisLock
                If balance >= amount Then
                    Console.WriteLine("Balance before Withdrawal :  " & balance)
                    Console.WriteLine("Amount to Withdraw        : -" & amount)
                    balance = balance - amount
                    Console.WriteLine("Balance after Withdrawal  :  " & balance)
                    Return amount
                Else
                    ' Transaction rejected.
                    Return 0
                End If
            End SyncLock
        End Function

        Public Sub DoTransactions()
            For i As Integer = 0 To 99
                Withdraw(r.Next(1, 100))
            Next
        End Sub
    End Class

    Sub Main()
        Dim threads(10) As Thread
        Dim acc As New Account(1000)

        For i As Integer = 0 To 9
            Dim t As New Thread(New ThreadStart(AddressOf acc.DoTransactions))
            threads(i) = t
        Next

        For i As Integer = 0 To 9
            threads(i).Start()
        Next
    End Sub

End Module