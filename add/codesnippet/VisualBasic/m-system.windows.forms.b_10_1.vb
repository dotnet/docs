    ' This event handler changes the value of the CompanyName
    ' property for the first item in the list.
    Private Sub changeItemBtn_Click(ByVal sender As Object, ByVal e As EventArgs) _
       Handles changeItemBtn.Click

        ' Get a reference to the list from the BindingSource.
        Dim customerList As List(Of DemoCustomer) = _
        CType(Me.customersBindingSource.DataSource, List(Of DemoCustomer))

        ' Change the value of the CompanyName property for the 
        ' first item in the list.
        customerList(0).CompanyName = "Tailspin Toys"

        ' Call ResetItem to alert the BindingSource that the 
        ' list has changed.
        Me.customersBindingSource.ResetItem(0)

    End Sub