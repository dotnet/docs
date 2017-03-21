            // Add the 'Customer ID' column style.
            DataGridColumnStyle myIDCol = new DataGridTextBoxColumn();
            myIDCol.MappingName = "custID";
            myIDCol.HeaderText = "Customer ID";
            myIDCol.Width = 100;
            myIDCol.WidthChanged += new EventHandler(MyIDColumnWidthChanged);
            myDataGridTableStyle.GridColumnStyles.Add(myIDCol);