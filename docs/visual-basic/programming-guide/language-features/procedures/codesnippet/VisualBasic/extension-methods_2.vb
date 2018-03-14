Module Class1

    Sub Main()

        Dim example As String = "Hello"
        ' Call to extension method Print.
        example.Print()

        ' Call to instance method ToUpper.
        example.ToUpper()
        example.ToUpper.Print()

    End Sub

End Module