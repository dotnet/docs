    ' Declare a new BindingListOfT with the Part business object.
    Private WithEvents listOfParts As BindingList(Of Part)

    Private Sub InitializeListOfParts()

        ' Create the new BindingList of Part type.
        listOfParts = New BindingList(Of Part)

        ' Allow new parts to be added, but not removed once committed.        
        listOfParts.AllowNew = True
        listOfParts.AllowRemove = False

        ' Raise ListChanged events when new parts are added.
        listOfParts.RaiseListChangedEvents = True

        ' Do not allow parts to be edited.
        listOfParts.AllowEdit = False

        ' Add a couple of parts to the list.
        listOfParts.Add(New Part("Widget", 1234))
        listOfParts.Add(New Part("Gadget", 5647))

    End Sub