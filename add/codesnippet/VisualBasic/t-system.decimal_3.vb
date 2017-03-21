    ' Keeping my fortune in Decimals to avoid the round-off errors.
    Class PiggyBank
        Protected MyFortune As Decimal

        Public Sub AddPenny()
            MyFortune = [Decimal].Add(MyFortune, 0.01D)
        End Sub

        Public ReadOnly Property Capacity() As Decimal
            Get
                Return [Decimal].MaxValue
            End Get
        End Property

        Public ReadOnly Property Dollars() As Decimal
            Get
                Return [Decimal].Floor(MyFortune)
            End Get
        End Property

        Public ReadOnly Property Cents() As Decimal
            Get
                Return [Decimal].Subtract(MyFortune, [Decimal].Floor(MyFortune))
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return MyFortune.ToString("C") + " in piggy bank"
        End Function
    End Class