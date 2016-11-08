Module Module1

    Sub Main()

        Dim testObject As Object
        ' The following statement sets testObject so that it does not refer to
        ' any instance.
        testObject = Nothing

        Dim tc As New TestClass
        tc = Nothing
        ' The fields of tc cannot be accessed. The following statement causes 
        ' a NullReferenceException at run time. (Compare to the assignment of
        ' Nothing to structure ts in the previous example.)
        'Console.WriteLine(tc.Field1)

    End Sub

    Class TestClass
        Public Field1 As Integer
        ' . . .
    End Class
End Module