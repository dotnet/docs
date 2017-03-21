    Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        ' The user has pressed the Submit button, prepare a parameterized
        ' SQL query to insert the values from the controls.
        AccessDataSource1.InsertCommand = _
        "INSERT INTO Employees (FirstName,LastName,Address,City,PostalCode,Country,ReportsTo) " & _
        "  VALUES (?,?,?,?,?,?,? ); "

        Dim firstName As New ControlParameter("FirstName", "TextBox1", "Text")
        AccessDataSource1.InsertParameters.Add(firstName)

        Dim lastName As New ControlParameter("LastName", "TextBox2", "Text")
        AccessDataSource1.InsertParameters.Add(lastName)

        Dim address As New ControlParameter("Address", "TextBox3", "Text")
        AccessDataSource1.InsertParameters.Add(address)

        Dim city As New ControlParameter("City", "TextBox4", "Text")
        AccessDataSource1.InsertParameters.Add(city)

        Dim postalCode As New ControlParameter("PostalCode", "TextBox5", "Text")
        AccessDataSource1.InsertParameters.Add(postalCode)

        Dim country As New ControlParameter("Country", "TextBox6", "Text")
        AccessDataSource1.InsertParameters.Add(country)

        Dim supervisor As New ControlParameter("ReportsTo", "DropDownList1", "SelectedValue")
        AccessDataSource1.InsertParameters.Add(supervisor)

        Try
            AccessDataSource1.Insert()
        Finally
            Button1.Visible = False
            Label9.Visible = True
        End Try

    End Sub