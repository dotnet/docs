                ' Create two arrays of Pet objects.
                Dim cats() As Pet = GetCats()
                Dim dogs() As Pet = GetDogs()

                ' Create an IEnumerable collection that contains two elements.
                ' Each element is an array of Pet objects.
                Dim animals() As IEnumerable(Of Pet) = {cats, dogs}

                Dim query As IEnumerable(Of String) =
            (animals.SelectMany(Function(pets) _
                                    pets.Select(Function(pet) pet.Name)))

                Dim output As New System.Text.StringBuilder
                For Each name As String In query
                    output.AppendLine(name)
                Next

                ' Display the output.
                MsgBox(output.ToString())

                ' This code produces the following output:
                '
                ' Barley
                ' Boots
                ' Whiskers
                ' Bounder
                ' Snoopy
                ' Fido
