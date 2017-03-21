    Public Sub LinkToolboxComponentsCreatingEvent(ByVal item As ToolboxItem)
        AddHandler item.ComponentsCreating, AddressOf Me.OnComponentsCreating
    End Sub

    Private Sub OnComponentsCreating(ByVal sender As Object, ByVal e As ToolboxComponentsCreatingEventArgs)
        ' Displays ComponentsCreating event information on the Console.
        Console.WriteLine(("Name of the class of the root component of the designer host receiving new components: " + e.DesignerHost.RootComponentClassName))
    End Sub