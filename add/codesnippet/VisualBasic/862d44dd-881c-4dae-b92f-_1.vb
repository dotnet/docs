            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            ' Returns an array of Pet objects.
            Function GetCats() As Pet()
                Dim cats() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                             New Pet With {.Name = "Boots", .Age = 4},
                             New Pet With {.Name = "Whiskers", .Age = 1}}

                Return cats
            End Function

            ' Returns an array of Pet objects.
            Function GetDogs() As Pet()
                Dim dogs() As Pet = {New Pet With {.Name = "Bounder", .Age = 3},
                             New Pet With {.Name = "Snoopy", .Age = 14},
                             New Pet With {.Name = "Fido", .Age = 9}}
                Return dogs
            End Function

            Sub ConcatEx1()
                ' Create two arrays of Pet objects.
                Dim cats() As Pet = GetCats()
                Dim dogs() As Pet = GetDogs()

                ' Project the Name of each cat and concatenate
                ' the collection of cat name strings with a collection
                ' of dog name strings.
                Dim query As IEnumerable(Of String) =
            cats _
            .Select(Function(cat) cat.Name) _
            .Concat(dogs.Select(Function(dog) dog.Name))

                Dim output As New System.Text.StringBuilder
                For Each name As String In query
                    output.AppendLine(name)
                Next

                ' Display the output.
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Barley
            ' Boots
            ' Whiskers
            ' Bounder
            ' Snoopy
            ' Fido
