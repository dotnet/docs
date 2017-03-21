        Public Sub LinkComponentChangingEvent(ByVal changeService As IComponentChangeService)
            ' Registers an event handler for the ComponentChanging event.
            AddHandler changeService.ComponentChanging, AddressOf Me.OnComponentChanging
        End Sub

        Private Sub OnComponentChanging(ByVal sender As Object, ByVal e As ComponentChangingEventArgs)
            ' Displays changing component information on the console.
            Console.WriteLine(("Type of the component that is about to change: " + e.Component.GetType().FullName))
            Console.WriteLine(("Name of the member of the component that is about to change: " + e.Member.Name))
        End Sub