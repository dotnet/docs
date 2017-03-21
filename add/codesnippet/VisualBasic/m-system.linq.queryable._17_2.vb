    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Structure Person
        Public LastName As String
        Public Pets() As Pet
    End Structure

    Sub AnyEx2()
        Dim people As New List(Of Person)(New Person() _
            {New Person With {.LastName = "Haas", _
                              .Pets = New Pet() {New Pet With {.Name = "Barley", .Age = 10}, _
                                                 New Pet With {.Name = "Boots", .Age = 14}, _
                                                 New Pet With {.Name = "Whiskers", .Age = 6}}}, _
              New Person With {.LastName = "Fakhouri", _
                               .Pets = New Pet() {New Pet With {.Name = "Snowball", .Age = 1}}}, _
              New Person With {.LastName = "Antebi", _
                               .Pets = New Pet() {}}, _
              New Person With {.LastName = "Philips", _
                               .Pets = New Pet() {New Pet With {.Name = "Sweetie", .Age = 2}, _
                                                  New Pet With {.Name = "Rover", .Age = 13}}}})

        ' Determine which people have a non-empty Pet array.
        Dim names = From person In people _
                    Where person.Pets.AsQueryable().Any() _
                    Select person.LastName

        For Each name As String In names
            Console.WriteLine(name)
        Next

        ' This code produces the following output:
        '
        ' Haas
        ' Fakhouri
        ' Philips

    End Sub