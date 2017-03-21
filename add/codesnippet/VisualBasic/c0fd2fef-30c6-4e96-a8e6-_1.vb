    Structure PetOwner
        Public Name As String
        Public Pets() As String
    End Structure

    Shared Sub SelectManyEx1()
        Dim petOwners() As PetOwner = _
            {New PetOwner With _
             {.Name = "Higa, Sidney", .Pets = New String() {"Scruffy", "Sam"}}, _
             New PetOwner With _
             {.Name = "Ashkenazi, Ronen", .Pets = New String() {"Walker", "Sugar"}}, _
             New PetOwner With _
             {.Name = "Price, Vernette", .Pets = New String() {"Scratches", "Diesel"}}}

        ' Query using SelectMany().
        Dim query1 As IEnumerable(Of String) = _
                    petOwners.AsQueryable().SelectMany(Function(petOwner) petOwner.Pets)

        Dim output As New System.Text.StringBuilder("Using SelectMany():" & vbCrLf)
        ' Only one foreach loop is required to iterate through 
        ' the results because it is a one-dimensional collection.
        For Each pet As String In query1
            output.AppendLine(pet)
        Next

        ' This code shows how to use Select() instead of SelectMany().
        Dim query2 As IEnumerable(Of String()) = _
                    petOwners.AsQueryable().Select(Function(petOwner) petOwner.Pets)

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

    ' Using SelectMany():
    ' Scruffy
    ' Sam
    ' Walker
    ' Sugar
    ' Scratches
    ' Diesel

    ' Using Select():
    ' Scruffy
    ' Sam
    ' Walker
    ' Sugar
    ' Scratches
    ' Diesel
