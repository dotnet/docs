    Class PiggyBank
        Public ReadOnly Property Capacity() As Decimal
            Get
                Return [Decimal].MaxValue
            End Get
        End Property

        Protected MyFortune As Decimal

        Public Sub AddPenny()
            MyFortune += 0.01D
        End Sub
    End Class