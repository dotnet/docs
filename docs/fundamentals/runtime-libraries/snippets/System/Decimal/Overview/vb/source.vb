Namespace Snippets
    Class Launcher
        'Entry point which delegates to C-style main Private Function
        Public Overloads Shared Sub Main()
            Dim pb As New PiggyBank()

            Dim i As Integer
            For i = 0 To 377
                pb.AddPenny()
            Next i

            Console.WriteLine(pb)

            Console.ReadLine()
        End Sub
    End Class

    '<snippet1>
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
    '</snippet1>
End Namespace

Namespace Snippets2
    '<snippet2>
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
    '</snippet2>
End Namespace

Namespace Snippets3
    '<snippet3>
    Class PiggyBank
        Public ReadOnly Property Dollars() As Decimal
            Get
                Return [Decimal].Floor(MyFortune)
            End Get
        End Property

        Protected MyFortune As Decimal

        Public Sub AddPenny()
            MyFortune += 0.01D
        End Sub
    End Class
    '</snippet3>
End Namespace

Namespace Snippets4
    _
    '<snippet4>
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
    '</snippet4>
End Namespace

Namespace Snippets5
    '<snippet5>
    Class PiggyBank

        Public Sub AddPenny()
            MyFortune = [Decimal].Add(MyFortune, 0.01D)
        End Sub

        Public Overrides Function ToString() As String
            Return MyFortune.ToString("C") + " in piggy bank"
        End Function

        Protected MyFortune As Decimal
    End Class
    '</snippet5>
End Namespace
