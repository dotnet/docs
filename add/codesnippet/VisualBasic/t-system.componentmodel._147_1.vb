        Public Sub LinkComponentRenameEvent(ByVal changeService As IComponentChangeService)
            ' Registers an event handler for the ComponentRename event.
            AddHandler changeService.ComponentRename, AddressOf Me.OnComponentRename
        End Sub

        Private Sub OnComponentRename(ByVal sender As Object, ByVal e As ComponentRenameEventArgs)
            ' Displays component renamed information on the console.           
            Console.WriteLine(("Type of the component that has been renamed: " + e.Component.GetType().FullName))
            Console.WriteLine(("New name of the component that has been renamed: " + e.NewName))
            Console.WriteLine(("Old name of the component that has been renamed: " + e.OldName))
        End Sub