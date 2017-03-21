      private void CreateAndBindDataSet(DataGrid myDataGrid)
      {
         DataSet myDataSet = new DataSet("myDataSet");
         DataTable myEmpTable = new DataTable("Employee");
         // Create two columns, and add them to employee table.
         DataColumn myEmpID = new DataColumn("EmpID", typeof(int));
         DataColumn myEmpName = new DataColumn("EmpName");
         myEmpTable.Columns.Add(myEmpID);
         myEmpTable.Columns.Add(myEmpName);
         // Add table to DataSet.
         myDataSet.Tables.Add(myEmpTable);
         // Populate table.
         DataRow newRow1;
         // Create employee records in employee Table.
         for(int i = 1; i < 6; i++)
         {
            newRow1 = myEmpTable.NewRow();
            newRow1["EmpID"] = i;
            // Add row to Employee table.
            myEmpTable.Rows.Add(newRow1);
         }
         // Give each employee a distinct name.
         myEmpTable.Rows[0]["EmpName"] = "Alpha";
         myEmpTable.Rows[1]["EmpName"] = "Beta";
         myEmpTable.Rows[2]["EmpName"] = "Omega";
         myEmpTable.Rows[3]["EmpName"] = "Gamma";
         myEmpTable.Rows[4]["EmpName"] = "Delta";
         // Bind DataGrid to DataSet.
         myDataGrid.SetDataBinding(myDataSet, "Employee");
      }

      private void Form1_Load(object sender, System.EventArgs e)
      {
         // Set and Display myDataGrid.
         myDataGrid.DataMember = "";
         myDataGrid.Location = new System.Drawing.Point(72, 32);
         myDataGrid.Name = "myDataGrid";
         myDataGrid.Size = new System.Drawing.Size(240, 200);
         myDataGrid.TabIndex = 4;
         // Add it to controls.
         Controls.Add(myDataGrid);
         CreateAndBindDataSet(myDataGrid);
         myDataGridTableStyle.MappingName = "Employee";
         // Set other properties.
         myDataGridTableStyle.AlternatingBackColor = Color.LightGray;
         // Add DataGridTableStyle instances to GridTableStylesCollection.
         myDataGridTableStyle.PreferredColumnWidth = 100;
         myColWidth.Text = "";
         myDataGrid.TableStyles.Add(myDataGridTableStyle);
         myDataGridTableStyle.PreferredColumnWidthChanged +=
               new EventHandler(MyDelegatePreferredColWidthChanged);
      }

      private void MyDelegatePreferredColWidthChanged(object sender, EventArgs e)
      {
         MessageBox.Show("Preferred Column width has changed");
      }

      private void myButton_Click(object sender, System.EventArgs e)
      {
         try
         {
            if( myColWidth.Text != "" )
            {
               int newwidth = myDataGridTableStyle.PreferredColumnWidth = 
                  int.Parse(myColWidth.Text);
               // Dispose datagrid and datagridtablestyle and then create.
               myDataGrid.Dispose();
               myDataGridTableStyle.Dispose();
               myDataGrid = new DataGrid();
               myDataGridTableStyle = new DataGridTableStyle();
               myDataGrid.DataMember = "";
               myDataGrid.Location = new System.Drawing.Point(72, 32);
               myDataGrid.Name = "myDataGrid";
               myDataGrid.Size = new System.Drawing.Size(240, 200);
               myDataGrid.TabIndex = 4;
               Controls.Add(myDataGrid);
               CreateAndBindDataSet(myDataGrid);
               myDataGridTableStyle.MappingName = "Employee";
               // Set other properties.
               myDataGridTableStyle.AlternatingBackColor = Color.LightGray;
               // Add DataGridTableStyle instances to GridTableStylesCollection.
               myDataGridTableStyle.PreferredColumnWidth = newwidth;
               myColWidth.Text = "";
               myDataGrid.TableStyles.Add(myDataGridTableStyle);
               myDataGridTableStyle.PreferredColumnWidthChanged += 
                  new EventHandler(MyDelegatePreferredColWidthChanged);
            }
            else
            {
               MessageBox.Show("Please enter a number");
            }
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }