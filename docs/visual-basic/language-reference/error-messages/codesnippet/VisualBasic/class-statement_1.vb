Class bankAccount
    Shared interestRate As Decimal
    Private accountNumber As String
    Private accountBalance As Decimal
    Public holdOnAccount As Boolean = False

    Public ReadOnly Property balance() As Decimal
        Get
            Return accountBalance
        End Get
    End Property

    Public Sub postInterest()
        accountBalance = accountBalance * (1 + interestRate)
    End Sub

    Public Sub postDeposit(ByVal amountIn As Decimal)
        accountBalance = accountBalance + amountIn
    End Sub

    Public Sub postWithdrawal(ByVal amountOut As Decimal)
        accountBalance = accountBalance - amountOut
    End Sub
End Class