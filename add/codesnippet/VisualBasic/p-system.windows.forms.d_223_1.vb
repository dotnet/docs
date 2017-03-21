   Private Sub AddDataGridTableStyle()
      ' Create a new DataGridTableStyle and set MappingName.
      Dim myGridStyle As DataGridTableStyle = _
      new DataGridTableStyle()
      myGridStyle.MappingName = "Customers"

      ' Add two DataGridColumnStyle objects.
      Dim colStyle1 As DataGridColumnStyle = _
      new DataGridTextBoxColumn()
      colStyle1.MappingName = "firstName"
      
      Dim colStyle2 As DataGridColumnStyle = _
      new DataGridBoolColumn()
      colStyle2.MappingName = "Current"

      ' Add column styles to table style.
      myGridStyle.GridColumnStyles.Add(colStyle1)
      myGridStyle.GridColumnStyles.Add(colStyle2)   

      ' Add the grid style to the GridStylesCollection.
      myDataGrid.TableStyles.Add(myGridStyle)
   End Sub