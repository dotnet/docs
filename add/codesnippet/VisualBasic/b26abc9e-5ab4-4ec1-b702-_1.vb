            Structure PetOwner
                Public Name As String
                Public Pets() As String
            End Structure

            Sub SelectManyEx1()
                ' Create an array of PetOwner objects.
                Dim petOwners() As PetOwner =
            {New PetOwner With
             {.Name = "Higa, Sidney", .Pets = New String() {"Scruffy", "Sam"}},
             New PetOwner With
             {.Name = "Ashkenazi, Ronen", .Pets = New String() {"Walker", "Sugar"}},
             New PetOwner With
             {.Name = "Price, Vernette", .Pets = New String() {"Scratches", "Diesel"}}}

                ' Call SelectMany() to gather all pets into a "flat" sequence.
                Dim query1 As IEnumerable(Of String) =
            petOwners.SelectMany(Function(petOwner) petOwner.Pets)

                Dim output As New System.Text.StringBuilder("Using SelectMany():" & vbCrLf)
                ' Only one foreach loop is required to iterate through 
                ' the results because it is a one-dimensional collection.
                For Each pet As String In query1
                    output.AppendLine(pet)
                Next

                ' This code demonstrates how to use Select() instead 
                ' of SelectMany() to get the same result.
                Dim query2 As IEnumerable(Of String()) =
            petOwners.Select(Function(petOwner) petOwner.Pets)
                output.AppendLine(vbCrLf & "Using Select():")
                ' Notice that two foreach loops are required to iterate through 
                ' the results because the query returns a collection of arrays.
                For Each petArray() As String In query2
                    For Each pet As String In petArray
                        output.AppendLine(pet)
                    Next
                Next

                ' Display the output.
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Using SelectMany():
            ' Scruffy
            ' Sam
            ' Walker
            ' Sugar
            ' Scratches
            ' Diesel
            '
            ' Using Select():
            ' Scruffy
            ' Sam
            ' Walker
            ' Sugar
            ' Scratches
            ' Diesel
