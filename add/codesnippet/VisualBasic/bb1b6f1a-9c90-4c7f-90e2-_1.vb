
    ' This method creates and returns an array of Pet objects.
    Shared Function GetCats() As Pet()
        Dim cats() As Pet = _
            {New Pet With {.Name = "Barley", .Age = 8}, _
             New Pet With {.Name = "Boots", .Age = 4}, _
             New Pet With {.Name = "Whiskers", .Age = 1}}

        Return cats
    End Function

    ' This method creates and returns an array of Pet objects.
    Shared Function GetDogs() As Pet()
        Dim dogs() As Pet = _
            {New Pet With {.Name = "Bounder", .Age = 3}, _
             New Pet With {.Name = "Snoopy", .Age = 14}, _
             New Pet With {.Name = "Fido", .Age = 9}}

        Return dogs
    End Function

    Shared Sub ConcatEx1()
        Dim cats() As Pet = GetCats()
        Dim dogs() As Pet = GetDogs()

        ' Concatenate a collection of cat names to a
        ' collection of dog names by using Concat().
        Dim query As IEnumerable(Of String) = _
            cats.AsQueryable() _
            .Select(Function(cat) cat.Name) _
            .Concat(dogs.Select(Function(dog) dog.Name))

        For Each name As String In query
            MsgBox(name)
        Next
    End Sub

    Structure Pet
        Dim Name As String
        Dim Age As Integer
    End Structure

    ' This code produces the following output:
    '
    ' Barley
    ' Boots
    ' Whiskers
    ' Bounder
    ' Snoopy
    ' Fido
