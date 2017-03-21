    Public Sub LinkToolboxComponentsCreatedEvent(ByVal item As ToolboxItem)
        AddHandler item.ComponentsCreated, AddressOf Me.OnComponentsCreated
    End Sub

    Private Sub OnComponentsCreated(ByVal sender As Object, ByVal e As ToolboxComponentsCreatedEventArgs)
        ' Lists created components on the Console.
        Dim i As Integer
        For i = 0 To e.Components.Length - 1
            Console.WriteLine(("Component #" + i.ToString() + ": " + e.Components(i).Site.Name.ToString()))
        Next i
    End Sub