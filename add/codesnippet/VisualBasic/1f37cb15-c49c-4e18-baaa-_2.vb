    Class Pet
        Public Name As String
        Public Age As Integer
    End Class

    Shared Sub SequenceEqualEx2()
        Dim pet1 As New Pet With {.Name = "Turbo", .Age = 2}
        Dim pet2 As New Pet With {.Name = "Peanut", .Age = 8}

        ' Create two lists of pets.
        Dim pets1 As New List(Of Pet)()
        pets1.Add(pet1)
        pets1.Add(pet2)

        Dim pets2 As New List(Of Pet)()
        pets2.Add(New Pet With {.Name = "Turbo", .Age = 2})
        pets2.Add(New Pet With {.Name = "Peanut", .Age = 8})

        ' Determine if the lists are equal.
        Dim equal As Boolean = pets1.AsQueryable().SequenceEqual(pets2)

        ' Display the output.
        Dim text As String = IIf(equal, "are", "are not")
        MsgBox("The lists " & text & " equal.")
    End Sub

    ' This code produces the following output:

    ' The lists are not equal.
