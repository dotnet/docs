        Public Sub LinkComponentChangedEvent(ByVal changeService As IComponentChangeService)
            ' Registers an event handler for the ComponentChanged event.
            AddHandler changeService.ComponentChanged, AddressOf Me.OnComponentChanged
        End Sub

        Private Sub OnComponentChanged(ByVal sender As Object, ByVal e As ComponentChangedEventArgs)
            ' Displays changed component information on the console.            
            Console.WriteLine(("Type of the component that has changed: " + e.Component.GetType().FullName))
            Console.WriteLine(("Name of the member of the component that has changed: " + e.Member.Name))
            Console.WriteLine(("Old value of the member: " + e.OldValue.ToString()))
            Console.WriteLine(("New value of the member: " + e.NewValue.ToString()))
        End Sub