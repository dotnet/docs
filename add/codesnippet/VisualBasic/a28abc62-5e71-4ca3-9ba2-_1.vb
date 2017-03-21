    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub MinEx2()
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8}, _
                       New Pet With {.Name = "Boots", .Age = 4}, _
                       New Pet With {.Name = "Whiskers", .Age = 1}}

        ' Get the Pet object that has the smallest Age value.
        Dim min As Integer = pets.AsQueryable().Min(Function(pet) pet.Age)

        MsgBox(String.Format("The youngest animal is age {0}.", min))
    End Sub

    'This code produces the following output:

    'The youngest animal is age 1.  
