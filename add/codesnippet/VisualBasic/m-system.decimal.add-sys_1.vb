    Class PiggyBank

        Public Sub AddPenny()
            MyFortune = [Decimal].Add(MyFortune, 0.01D)
        End Sub

        Public Overrides Function ToString() As String
            Return MyFortune.ToString("C") + " in piggy bank"
        End Function

        Protected MyFortune As Decimal
    End Class