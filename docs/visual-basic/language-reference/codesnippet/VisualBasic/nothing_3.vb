Module Module1
    Sub Main()

        Dim testObject As Object
        testObject = Nothing
        Console.WriteLine(testObject Is Nothing)
        ' Output: True

        Dim tc As New TestClass
        tc = Nothing
        Console.WriteLine(tc IsNot Nothing)
        ' Output: False

        ' Declare a nullable value type.
        Dim n? As Integer
        Console.WriteLine(n Is Nothing)
        ' Output: True

        n = 4
        Console.WriteLine(n Is Nothing)
        ' Output: False

        n = Nothing
        Console.WriteLine(n IsNot Nothing)
        ' Output: False

        Console.ReadKey()
    End Sub

    Class TestClass
        Public Field1 As Integer
        Private field2 As Boolean
    End Class
End Module