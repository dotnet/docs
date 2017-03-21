    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub MaxEx2()
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8}, _
                       New Pet With {.Name = "Boots", .Age = 4}, _
                       New Pet With {.Name = "Whiskers", .Age = 1}}

        ' Add Pet.Age to the length of Pet.Name
        ' to determine the "maximum" Pet object in the array.
        Dim max As Integer = _
            pets.AsQueryable().Max(Function(pet) pet.Age + pet.Name.Length)

        MsgBox(String.Format("The maximum pet age plus name length is {0}.", max))

        'This code produces the following output:

        'The maximum pet age plus name length is 14.
