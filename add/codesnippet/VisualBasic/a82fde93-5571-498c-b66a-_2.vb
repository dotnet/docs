            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Structure Person
                Public LastName As String
                Public Pets() As Pet
            End Structure

            Sub AllEx2()
                Dim people As New List(Of Person)(New Person() _
            {New Person With {.LastName = "Haas",
                              .Pets = New Pet() {New Pet With {.Name = "Barley", .Age = 10},
                                                 New Pet With {.Name = "Boots", .Age = 14},
                                                 New Pet With {.Name = "Whiskers", .Age = 6}}},
              New Person With {.LastName = "Fakhouri",
                               .Pets = New Pet() {New Pet With {.Name = "Snowball", .Age = 1}}},
              New Person With {.LastName = "Antebi",
                               .Pets = New Pet() {New Pet With {.Name = "Belle", .Age = 8}}},
              New Person With {.LastName = "Philips",
                               .Pets = New Pet() {New Pet With {.Name = "Sweetie", .Age = 2},
                                                  New Pet With {.Name = "Rover", .Age = 13}}}})

                ' Determine which people have pets that are all older than 5.
                Dim names = From person In people
                            Where person.Pets.All(Function(pet) pet.Age > 5)
                            Select person.LastName

                For Each name As String In names
                    Console.WriteLine(name)
                Next

                ' This code produces the following output:
                '
                ' Haas
                ' Antebi

            End Sub