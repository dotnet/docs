    Public Sub LinkResolveNameEvent(ByVal serializationManager As IDesignerSerializationManager)
        ' Registers an event handler for the resolve name event.
        AddHandler serializationManager.ResolveName, AddressOf Me.OnResolveName
    End Sub

    Private Sub OnResolveName(ByVal sender As Object, ByVal e As ResolveNameEventArgs)
        ' Displays ResolveName event information on the Console.
        Console.WriteLine(("Name of the name to resolve: " + e.Name))
        Console.WriteLine(("ToString output of the object that no name was resolved for: " + e.Value.ToString()))
    End Sub