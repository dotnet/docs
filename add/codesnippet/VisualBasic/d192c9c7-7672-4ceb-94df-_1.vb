   Private Sub RemoveColumnStyle_Clicked(sender As Object, e As EventArgs) Handles removeStyle.Click
      Dim myTableStyle As DataGridTableStyle = myDataGrid.TableStyles(0)
      
      ' Get the GridColumnStylesCollection of Data Grid.
      myColumns = myTableStyle.GridColumnStyles
      Dim i As Integer
      
      ' Remove the CustName ColumnStyle from the data grid.
      If myColumns.Contains("CustName") Then
         Dim myDataColumnStyle As DataGridColumnStyle = myColumns("CustName")
         i = myColumns.IndexOf(myDataColumnStyle)
         myColumns.RemoveAt(i)
      End If
   End Sub 'RemoveColumnStyle_Clicked