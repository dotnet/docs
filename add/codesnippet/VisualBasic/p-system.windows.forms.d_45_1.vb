        Private Sub CreateAndBindDataSet(ByVal myDataGrid As System.Windows.Forms.DataGrid)
            Dim myDataSet As New DataSet("myDataSet")
            Dim myEmpTable As New DataTable("Employee")
            ' Create two columns, and add them to employee table.
            Dim myEmpID As New DataColumn("EmpID", GetType(Integer))
            Dim myEmpName As New DataColumn("EmpName")
            myEmpTable.Columns.Add(myEmpID)
            myEmpTable.Columns.Add(myEmpName)
            ' Add table to DataSet.
            myDataSet.Tables.Add(myEmpTable)
            ' Populate table.
            Dim newRow1 As DataRow
            ' Create employee records in employee Table.
            Dim i As Integer
            For i = 1 To 5
                newRow1 = myEmpTable.NewRow()
                newRow1("EmpID") = i
                ' Add row to Employee table.
                myEmpTable.Rows.Add(newRow1)
            Next i
            ' Give each employee a distinct name.
            myEmpTable.Rows(0)("EmpName") = "Alpha"
            myEmpTable.Rows(1)("EmpName") = "Beta"
            myEmpTable.Rows(2)("EmpName") = "Omega"
            myEmpTable.Rows(3)("EmpName") = "Gamma"
            myEmpTable.Rows(4)("EmpName") = "Delta"
            ' Bind DataGrid to DataSet.
            myDataGrid.SetDataBinding(myDataSet, "Employee")
        End Sub 'CreateAndBindDataSet


        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set and Display myDataGrid.
            myDataGrid.DataMember = ""
            myDataGrid.Location = New System.Drawing.Point(72, 32)
            myDataGrid.Name = "myDataGrid"
            myDataGrid.Size = New System.Drawing.Size(240, 200)
            myDataGrid.TabIndex = 4
            ' Add it to controls.
            Controls.Add(myDataGrid)
            CreateAndBindDataSet(myDataGrid)
            myDataGridTableStyle.MappingName = "Employee"
            ' Set other properties.
            myDataGridTableStyle.AlternatingBackColor = Color.LightGray
            ' Add DataGridTableStyle instances to GridTableStylesCollection.
            myDataGridTableStyle.PreferredColumnWidth = 100
            myColWidth.Text = ""
            myDataGrid.TableStyles.Add(myDataGridTableStyle)
            AddHandler myDataGridTableStyle.PreferredColumnWidthChanged, AddressOf MyDelegatePreferredColWidthChanged
        End Sub 'Form1_Load


        Private Sub MyDelegatePreferredColWidthChanged(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("Preferred Column width has changed")
        End Sub 'MyDelegatePreferredColWidthChanged


        Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles myButton.Click
            Try
                If myColWidth.Text <> "" Then
                    Dim newwidth As Integer = Integer.Parse(myColWidth.Text)
                    myDataGridTableStyle.PreferredColumnWidth = newwidth
                    ' Dispose datagrid and datagridtablestyle and then create.
                    myDataGrid.Dispose()
                    myDataGridTableStyle.Dispose()
                    myDataGrid = New Windows.Forms.Datagrid()
                    myDataGridTableStyle = New DataGridTableStyle()
                    myDataGrid.DataMember = ""
                    myDataGrid.Location = New System.Drawing.Point(72, 32)
                    myDataGrid.Name = "myDataGrid"
                    myDataGrid.Size = New System.Drawing.Size(240, 200)
                    myDataGrid.TabIndex = 4
                    Controls.Add(myDataGrid)
                    CreateAndBindDataSet(myDataGrid)
                    myDataGridTableStyle.MappingName = "Employee"
                    ' Set other properties.
                    myDataGridTableStyle.AlternatingBackColor = Color.LightGray
                    ' Add DataGridTableStyle instances to GridTableStylesCollection.
                    myDataGridTableStyle.PreferredColumnWidth = newwidth
                    myColWidth.Text = ""
                    myDataGrid.TableStyles.Add(myDataGridTableStyle)
                    AddHandler myDataGridTableStyle.PreferredColumnWidthChanged, AddressOf MyDelegatePreferredColWidthChanged
                Else
                    MessageBox.Show("Please enter a number")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub 'myButton_Click