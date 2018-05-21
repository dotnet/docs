    Sub TestCall()
        Call (Sub() Console.Write("Hello"))()

        Call New TheClass().ShowText()
    End Sub

    Class TheClass
        Public Sub ShowText()
            Console.Write(" World")
        End Sub
    End Class