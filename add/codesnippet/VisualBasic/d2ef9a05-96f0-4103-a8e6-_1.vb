    Structure Person
        Public Name As String
    End Structure

    Structure Pet
        Public Name As String
        Public Owner As Person
    End Structure

    Shared Sub GroupJoinEx1()
        Dim magnus As New Person With {.Name = "Hedlund, Magnus"}
        Dim terry As New Person With {.Name = "Adams, Terry"}
        Dim charlotte As New Person With {.Name = "Weiss, Charlotte"}

        Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
        Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
        Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte})
        Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, daisy})

        ' Create a list where each element is an anonymous 
        ' type that contains a person's name and a collection
        ' of the names of the pets that are owned by them.
        Dim query = _
            people.AsQueryable().GroupJoin(pets, _
                       Function(person) person, _
                       Function(pet) pet.Owner, _
                       Function(person, petCollection) _
                           New With {.OwnerName = person.Name, _
                                     .Pets = petCollection.Select( _
                                                        Function(pet) pet.Name)})

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            ' Output the owner's name.
            output.AppendLine(String.Format("{0}:", obj.OwnerName))
            ' Output each of the owner's pet's names.
            For Each pet As String In obj.Pets
                output.AppendLine(String.Format("  {0}", pet))
            Next
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' Hedlund, Magnus:
    '   Daisy
    ' Adams, Terry:
    '   Barley
    '   Boots
    ' Weiss, Charlotte:
    '   Whiskers
