    Class PiggyBank
        Public ReadOnly Property Cents() As Decimal
            Get
                Return [Decimal].Subtract(MyFortune, [Decimal].Floor(MyFortune))
            End Get
        End Property

        Protected MyFortune As Decimal

        Public Sub AddPenny()
            MyFortune += 0.01D
        End Sub
    End Class