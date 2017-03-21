    Private Function CreateComboBoxColumn() _
        As DataGridViewComboBoxColumn
        Dim column As New DataGridViewComboBoxColumn()

        With column
            .DataPropertyName = ColumnName.TitleOfCourtesy.ToString()
            .HeaderText = ColumnName.TitleOfCourtesy.ToString()
            .DropDownWidth = 160
            .Width = 90
            .MaxDropDownItems = 3
            .FlatStyle = FlatStyle.Flat
        End With
        Return column
    End Function

    Private Sub SetAlternateChoicesUsingDataSource( _
        ByVal comboboxColumn As DataGridViewComboBoxColumn)
        With comboboxColumn
            .DataSource = RetrieveAlternativeTitles()
            .ValueMember = ColumnName.TitleOfCourtesy.ToString()
            .DisplayMember = .ValueMember
        End With
    End Sub

    Private Function RetrieveAlternativeTitles() As DataTable
        Return Populate( _
            "SELECT distinct TitleOfCourtesy FROM Employees")
    End Function

    Private connectionString As String = _
            "Integrated Security=SSPI;Persist Security Info=False;" _
            & "Initial Catalog=Northwind;Data Source=localhost"

    Private Function Populate(ByVal sqlCommand As String) As DataTable
        Dim northwindConnection As New SqlConnection(connectionString)
        northwindConnection.Open()

        Dim command As New SqlCommand(sqlCommand, _
            northwindConnection)
        Dim adapter As New SqlDataAdapter()
        adapter.SelectCommand = command
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter.Fill(table)

        Return table
    End Function

    ' Using an enum provides some abstraction between column index
    ' and column name along with compile time checking, and gives
    ' a handy place to store the column names.
    Enum ColumnName
        EmployeeId
        LastName
        FirstName
        Title
        TitleOfCourtesy
        BirthDate
        HireDate
        Address
        City
        Region
        PostalCode
        Country
        HomePhone
        Extension
        Photo
        Notes
        ReportsTo
        PhotoPath
        OutOfOffice
    End Enum