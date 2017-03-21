    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub LongCountEx2()
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8}, _
                           New Pet With {.Name = "Boots", .Age = 4}, _
                           New Pet With {.Name = "Whiskers", .Age = 1}}

        Const Age As Integer = 3

        ' Count the number of Pet objects where Pet.Age is greater than 3.
        Dim count As Long = pets.AsQueryable().LongCount(Function(Pet) Pet.Age > Age)

        MsgBox(String.Format("There are {0} animals over age {1}.", count, Age))
    End Sub

    ' This code produces the following output:

    ' There are 2 animals over age 3.
