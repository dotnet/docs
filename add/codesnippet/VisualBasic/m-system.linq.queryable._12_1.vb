    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub DefaultIfEmptyEx1()
        ' Create a list of Pet objects.
        Dim pets As New List(Of Pet)(New Pet() { _
                            New Pet With {.Name = "Barley", .Age = 8}, _
                            New Pet With {.Name = "Boots", .Age = 4}, _
                            New Pet With {.Name = "Whiskers", .Age = 1}})

        ' Call DefaultIfEmtpy() on the collection that Select()
        ' returns, so that if the initial list is empty, there
        ' will always be at least one item in the returned array.
        Dim names() As String = pets.AsQueryable() _
            .Select(Function(Pet) Pet.Name) _
            .DefaultIfEmpty() _
            .ToArray()

        Dim first As String = names(0)
        MsgBox(first)

        ' This code produces the following output:
        '
        ' Barley

    End Sub