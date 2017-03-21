   private:
      void CreateAndBindDataSet( DataGrid^ myDataGrid )
      {
         DataSet^ myDataSet = gcnew DataSet( "myDataSet" );
         DataTable^ myEmpTable = gcnew DataTable( "Employee" );

         // Create two columns, and add them to employee table.
         DataColumn^ myEmpID = gcnew DataColumn( "EmpID",int::typeid );
         DataColumn^ myEmpName = gcnew DataColumn( "EmpName" );
         myEmpTable->Columns->Add( myEmpID );
         myEmpTable->Columns->Add( myEmpName );

         // Add table to DataSet.
         myDataSet->Tables->Add( myEmpTable );

         // Populate table.
         DataRow^ newRow1;

         // Create employee records in employee Table.
         for ( int i = 1; i < 6; i++ )
         {
            newRow1 = myEmpTable->NewRow();
            newRow1[ "EmpID" ] = i;
            
            // Add row to Employee table.
            myEmpTable->Rows->Add( newRow1 );
         }
         myEmpTable->Rows[ 0 ][ "EmpName" ] = "Alpha";
         myEmpTable->Rows[ 1 ][ "EmpName" ] = "Beta";
         myEmpTable->Rows[ 2 ][ "EmpName" ] = "Omega";
         myEmpTable->Rows[ 3 ][ "EmpName" ] = "Gamma";
         myEmpTable->Rows[ 4 ][ "EmpName" ] = "Delta";

         // Bind DataGrid to DataSet.
         myDataGrid->SetDataBinding( myDataSet, "Employee" );
      }

      void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Set and Display myDataGrid.
         myDataGrid->DataMember = "";
         myDataGrid->Location = System::Drawing::Point( 72, 32 );
         myDataGrid->Name = "myDataGrid";
         myDataGrid->Size = System::Drawing::Size( 240, 200 );
         myDataGrid->TabIndex = 4;

         // Add it to controls.
         Controls->Add( myDataGrid );
         CreateAndBindDataSet( myDataGrid );
         myDataGridTableStyle->MappingName = "Employee";

         // Set other properties.
         myDataGridTableStyle->AlternatingBackColor = Color::LightGray;

         // Add DataGridTableStyle instances to GridTableStylesCollection.
         myDataGridTableStyle->PreferredColumnWidth = 100;
         myColWidth->Text = "";
         myDataGrid->TableStyles->Add( myDataGridTableStyle );
         myDataGridTableStyle->PreferredColumnWidthChanged += gcnew EventHandler( this, &Form1::MyDelegatePreferredColWidthChanged );
      }

   private:
      void MyDelegatePreferredColWidthChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( "Preferred Column width has changed" );
      }

   private:
      void myButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         try
         {
            if (  !myColWidth->Text->Equals( "" ) )
            {
               Int32 newwidth = myDataGridTableStyle->PreferredColumnWidth;
               myDataGridTableStyle->PreferredColumnWidth = Int32::Parse( myColWidth->Text );

               // Dispose datagrid and datagridtablestyle and then create.
               delete myDataGrid;
               delete myDataGridTableStyle;
               myDataGrid = gcnew DataGrid;
               myDataGridTableStyle = gcnew DataGridTableStyle;
               myDataGrid->DataMember = "";
               myDataGrid->Location = System::Drawing::Point( 72, 32 );
               myDataGrid->Name = "myDataGrid";
               myDataGrid->Size = System::Drawing::Size( 240, 200 );
               myDataGrid->TabIndex = 4;
               Controls->Add( myDataGrid );
               CreateAndBindDataSet( myDataGrid );
               myDataGridTableStyle->MappingName = "Employee";

               // Set other properties.
               myDataGridTableStyle->AlternatingBackColor = Color::LightGray;

               // Add DataGridTableStyle instances to GridTableStylesCollection.
               myDataGridTableStyle->PreferredColumnWidth = newwidth;
               myColWidth->Text = "";
               myDataGrid->TableStyles->Add( myDataGridTableStyle );
               myDataGridTableStyle->PreferredColumnWidthChanged += gcnew EventHandler( this, &Form1::MyDelegatePreferredColWidthChanged );
            }
            else
            {
               MessageBox::Show( "Please enter a number" );
            }
         }
         catch ( Exception^ ex ) 
         {
            MessageBox::Show( ex->Message );
         }
      }