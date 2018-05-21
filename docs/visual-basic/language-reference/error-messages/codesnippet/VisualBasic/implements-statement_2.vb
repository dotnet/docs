    Public Sub testImplements()
        ' This procedure tests the interface implementation by
        ' creating an instance of the class that implements ICustomerInfo.
        Dim cust As ICustomerInfo = New customerInfo()
        ' Associate an event handler with the event that is raised by
        ' the cust object.
        AddHandler cust.updateComplete, AddressOf handleUpdateComplete
        ' Set the customerName Property
        cust.customerName = "Fred"
        ' Retrieve and display the customerName property.
        MsgBox("Customer name is: " & cust.customerName)
        ' Call the updateCustomerStatus procedure, which raises the
        ' updateComplete event.
        cust.updateCustomerStatus()
    End Sub

    Sub handleUpdateComplete()
        ' This is the event handler for the updateComplete event.
        MsgBox("Update is complete.")
    End Sub