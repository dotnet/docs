    Structure Person
        Public Name As String
    End Structure

    Structure Pet
        Public Name As String
        Public Owner As Person
    End Structure

    Shared Sub JoinEx1()
        Dim magnus As New Person With {.Name = "Hedlund, Magnus"}
        Dim terry As New Person With {.Name = "Adams, Terry"}
        Dim charlotte As New Person With {.Name = "Weiss, Charlotte"}

        Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
        Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
        Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte})
        Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, daisy})

        ' Join the list of Person objects and the list of Pet objects 
        ' to create a list of person-pet pairs where each element is 
        ' an anonymous type that contains pet's name and the name of the
        ' Person object that owns the pet.
        Dim query = people.AsQueryable().Join(pets, _
                        Function(person) person, _
                        Function(pet) pet.Owner, _
                        Function(person, pet) _
                            New With {.OwnerName = person.Name, .Pet = pet.Name})

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            output.AppendLine(String.Format( _
                "{0} - {1}", obj.OwnerName, obj.Pet))
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' Hedlund, Magnus - Daisy
    ' Adams, Terry - Barley
    ' Adams, Terry - Boots
    ' Weiss, Charlotte - Whiskers
