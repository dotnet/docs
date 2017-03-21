private:
    DataGridViewComboBoxColumn^ CreateComboBoxColumn()
    {
        DataGridViewComboBoxColumn^ column =
            gcnew DataGridViewComboBoxColumn();
        {
            column->DataPropertyName = ColumnName::TitleOfCourtesy.ToString();
            column->HeaderText = ColumnName::TitleOfCourtesy.ToString();
            column->DropDownWidth = 160;
            column->Width = 90;
            column->MaxDropDownItems = 3;
            column->FlatStyle = FlatStyle::Flat;
        }
        return column;
    }

private:
    void SetAlternateChoicesUsingDataSource(DataGridViewComboBoxColumn^ comboboxColumn)
    {
        {
            comboboxColumn->DataSource = RetrieveAlternativeTitles();
            comboboxColumn->ValueMember = ColumnName::TitleOfCourtesy.ToString();
            comboboxColumn->DisplayMember = comboboxColumn->ValueMember;
        }
    }

private:
    DataTable^ RetrieveAlternativeTitles()
    {
        return Populate("SELECT distinct TitleOfCourtesy FROM Employees");
    }

    String^ connectionString;

private:
    DataTable^ Populate(String^ sqlCommand)
    {
        SqlConnection^ northwindConnection = gcnew SqlConnection(connectionString);
        northwindConnection->Open();

        SqlCommand^ command = gcnew SqlCommand(sqlCommand, northwindConnection);
        SqlDataAdapter^ adapter = gcnew SqlDataAdapter();
        adapter->SelectCommand = command;

        DataTable^ table = gcnew DataTable();
        adapter->Fill(table);

        return table;
    }

	// Using an enum provides some abstraction between column index
    // and column name along with compile time checking, and gives
    // a handy place to store the column names.
    enum class ColumnName
    {
        EmployeeID,
        LastName,
        FirstName,
        Title,
        TitleOfCourtesy,
        BirthDate,
        HireDate,
        Address,
        City,
        Region,
        PostalCode,
        Country,
        HomePhone,
        Extension,
        Photo,
        Notes,
        ReportsTo,
        PhotoPath,
        OutOfOffice
    };