   ' This event handler provides custom item-creation behavior.
    Private Sub customersBindingSource_AddingNew( _
    ByVal sender As Object, _
    ByVal e As AddingNewEventArgs) _
    Handles customersBindingSource.AddingNew

        e.NewObject = DemoCustomer.CreateNewCustomer()

    End Sub