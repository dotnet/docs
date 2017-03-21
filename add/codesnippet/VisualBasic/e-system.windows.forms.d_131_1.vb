      Private Sub DataGridTableStyle_Sample_Load(ByVal sender As Object, _
                              ByVal e As EventArgs) Handles MyBase.Load
         myDataGridTableStyle1 = New DataGridTableStyle()

         mylabel.Text = "Sorting Status :" + myDataGridTableStyle1.AllowSorting.ToString()
         If myDataGridTableStyle1.AllowSorting = True Then
            btnApplyStyles.Text = "Remove Sorting"
         Else
            btnApplyStyles.Text = "Apply Sorting"
         End If
         ' Attach custom event handlers.
         AddHandler myDataGridTableStyle1.AllowSortingChanged, AddressOf AllowSortingChanged_Handler
         myDataGridTableStyle1.MappingName = "Customers"
      End Sub 'DataGridTableStyle_Sample_Load

      Private Sub AllowSortingChanged_Handler(ByVal sender As Object, ByVal e As EventArgs)
         mylabel.Text = "Sorting Status :" + myDataGridTableStyle1.AllowSorting.ToString()
      End Sub 'AllowSortingChanged_Handler

      Private Sub btnApplyStyles_Click(ByVal sender As Object, _
                                       ByVal e As EventArgs) Handles btnApplyStyles.Click
         If myDataGridTableStyle1.AllowSorting = True Then
            ' Remove sorting.
            myDataGridTableStyle1.AllowSorting = False
            btnApplyStyles.Text = "Allow Sorting"
         Else
            ' Allow sorting.
            myDataGridTableStyle1.AllowSorting = True
            btnApplyStyles.Text = "Remove Sorting"
         End If

         mylabel.Text = "Sorting Status :" + myDataGridTableStyle1.AllowSorting.ToString
         ' Add the DataGridTableStyle to DataGrid.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1)
      End Sub 'btnApplyStyles_Click