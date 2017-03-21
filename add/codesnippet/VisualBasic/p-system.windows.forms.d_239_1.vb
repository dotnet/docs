        Private Sub Create_Table()
            ' Create a DataSet.
            myDataSet = New DataSet("myDataSet")
            ' Create DataTable.
            Dim myCustomerTable As New DataTable("Customers")
            ' Create two columns, and add to the table.
            Dim CustID As New DataColumn("CustID", GetType(Integer))
            Dim CustName As New DataColumn("CustName")
            myCustomerTable.Columns.Add(CustID)
            myCustomerTable.Columns.Add(CustName)
            Dim newRow1 As DataRow
            ' Create three customers in the Customers Table.
            Dim i As Integer
            For i = 1 To 2
                newRow1 = myCustomerTable.NewRow()
                newRow1("custID") = i
                ' Add row to the Customers table.
                myCustomerTable.Rows.Add(newRow1)
            Next i
            ' Give each customer a distinct name.
            myCustomerTable.Rows(0)("custName") = "Alpha"
            myCustomerTable.Rows(1)("custName") = "Beta"
            ' Add table to DataSet.
            myDataSet.Tables.Add(myCustomerTable)
            dataGrid1.SetDataBinding(myDataSet, "Customers")
            myTableStyle = New DataGridTableStyle()
            myTableStyle.MappingName = "Customers"
            myTableStyle.ForeColor = Color.DarkMagenta
            dataGrid1.TableStyles.Add(myTableStyle)
        End Sub 'Create_Table

        ' Set table's forecolor.
        Private Sub OnForeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button2.Click
            dataGrid1.TableStyles.Clear()
            Select Case myComboBox.SelectedItem.ToString()
                Case "Green"
                    myTableStyle.ForeColor = Color.Green
                Case "Red"
                    myTableStyle.ForeColor = Color.Red
                Case "Violet"
                    myTableStyle.ForeColor = Color.Violet
            End Select
            dataGrid1.TableStyles.Add(myTableStyle)
        End Sub 'OnForeColor_Click