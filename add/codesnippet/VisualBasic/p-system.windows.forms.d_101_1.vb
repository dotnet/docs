      Private Sub Create_Table()
         ' Create DataSet.
         myDataSet = New DataSet("myDataSet")
         ' Create DataTable.
         Dim myCustomerTable As New DataTable("Customers")
         ' Create two columns, and add them to the table.
         Dim CustID As New DataColumn("CustID", GetType(Integer))
         Dim CustName As New DataColumn("CustName")
         myCustomerTable.Columns.Add(CustID)
         myCustomerTable.Columns.Add(CustName)
         ' Add table to DataSet.
         myDataSet.Tables.Add(myCustomerTable)
         dataGrid1.SetDataBinding(myDataSet, "Customers")
         myTableStyle = New DataGridTableStyle()
         myTableStyle.MappingName = "Customers"
         AddHandler myTableStyle.HeaderBackColorChanged, AddressOf HeaderBackColorChangedHandler
         AddHandler myTableStyle.HeaderForeColorChanged, AddressOf HeaderForeColorChangedHandler
      End Sub 'Create_Table
      
      
      ' Change header background color.
      Private Sub OnHeaderBackColor_Click(sender As Object, e As System.EventArgs) Handles button1.Click
         dataGrid1.TableStyles.Clear()
         Select Case comboBox1.SelectedItem.ToString()
            Case "Red"
               myTableStyle.HeaderBackColor = Color.Red
            Case "Yellow"
               myTableStyle.HeaderBackColor = Color.Yellow
            Case "Blue"
               myTableStyle.HeaderBackColor = Color.Blue
         End Select
         myTableStyle.AlternatingBackColor = Color.LightGray
         dataGrid1.TableStyles.Add(myTableStyle)
      End Sub 'OnHeaderBackColor_Click
      
        Private Sub HeaderBackColorChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("Changed Header Background color to : " + comboBox1.SelectedItem.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Sub 'HeaderBackColorChangedHandler
      
      ' Change header forecolor.
      Private Sub OnHeaderForeColor_Click(sender As Object, e As System.EventArgs) Handles button2.Click
         dataGrid1.TableStyles.Clear()
         Select Case comboBox2.SelectedItem.ToString()
            Case "Green"
               myTableStyle.HeaderForeColor = Color.Green
            Case "White"
               myTableStyle.HeaderForeColor = Color.White
            Case "Violet"
               myTableStyle.HeaderForeColor = Color.Violet
         End Select
         myTableStyle.AlternatingBackColor = Color.LightGray
         dataGrid1.TableStyles.Add(myTableStyle)
      End Sub 'OnHeaderForeColor_Click
      