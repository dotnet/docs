Private Sub AddDataGridBoolColumnStyle()
   Dim myColumn As DataGridBoolColumn  = new DataGridBoolColumn()
   myColumn.MappingName = "Current"
   myColumn.Width = 200
   dataGrid1.TableStyles("Customers").GridColumnStyles.Add(myColumn)
End Sub 