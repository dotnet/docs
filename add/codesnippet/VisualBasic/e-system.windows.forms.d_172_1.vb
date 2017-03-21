            ' Add the 'Customer ID' column style.
            Dim myIDCol As DataGridTextBoxColumn = New DataGridTextBoxColumn()
            myIDCol.MappingName = "custID"
            myIDCol.HeaderText = "Customer ID"
            myIDCol.Width = 100
            AddHandler myIDCol.WidthChanged, AddressOf MyIDColumnWidthChanged
            myDataGridTableStyle.GridColumnStyles.Add(myIDCol)