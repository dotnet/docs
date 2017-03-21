    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        ' Create the connection string, data adapter and data table.
        Dim connectionString As New SqlConnection("Initial Catalog=Northwind;" & _
            "Data Source=localhost;Integrated Security=SSPI;")
        Dim customersTableAdapter As New SqlDataAdapter("Select * from Customers", _
            connectionString)
        Dim customerTable As New DataTable()

        ' Fill the the adapter with the contents of the customer table.
        customersTableAdapter.Fill(customerTable)

        ' Set data source for BindingSource1.
        BindingSource1.DataSource = customerTable

        ' Set the label text to the number of items in the collection before
        ' an item is removed.
        label1.Text = "Starting count: " + BindingSource1.Count.ToString()

        ' Access the List property and remove an item.
        BindingSource1.List.RemoveAt(4)

        ' Remove an item directly from the BindingSource. 
        ' This is equivalent to the previous line of code.
        BindingSource1.RemoveAt(4)

        ' Show the new count.
        label2.Text = "Count after removal: " + BindingSource1.Count.ToString()

    End Sub
End Class