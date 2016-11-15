    Sub Main()
        Dim example As New ExampleClass
        Dim arg1 As Long = 10
        Dim arg2 As Integer = 5

        ' The following statement calls the extension method.
        example.exampleMethod(arg1)
        ' The following statement calls the instance method.
        example.exampleMethod(arg2)
    End Sub