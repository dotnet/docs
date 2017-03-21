         // Add the 'Customer ID' column style.
         DataGridColumnStyle^ myIDCol = gcnew DataGridTextBoxColumn;
         myIDCol->MappingName = "custID";
         myIDCol->HeaderText = "Customer ID";
         myIDCol->Width = 100;
         myIDCol->WidthChanged += gcnew EventHandler( this, &MyForm::MyIDColumnWidthChanged );
         myDataGridTableStyle->GridColumnStyles->Add( myIDCol );