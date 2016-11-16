Module Module1

    Sub Main()

        ' Declare an instance of the class and assign a value to its field.
        Dim c1 As Class1 = New Class1()
        c1.Field = 5
        Console.WriteLine(c1.Field)
        ' Output: 5

        ' ByVal does not prevent changing the value of a field or property.
        ChangeFieldValue(c1)
        Console.WriteLine(c1.Field)
        ' Output: 500

        ' ByVal does prevent changing the value of c1 itself. 
        ChangeClassReference(c1)
        Console.WriteLine(c1.Field)
        ' Output: 500

        Console.ReadKey()
    End Sub

    Public Sub ChangeFieldValue(ByVal cls As Class1)
        cls.Field = 500
    End Sub

    Public Sub ChangeClassReference(ByVal cls As Class1)
        cls = New Class1()
        cls.Field = 1000
    End Sub

    Public Class Class1
        Public Field As Integer
    End Class

End Module