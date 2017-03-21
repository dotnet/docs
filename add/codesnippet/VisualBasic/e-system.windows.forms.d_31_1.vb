   ' Create an instance of the 'CurrentCellChanged' EventHandler.
   Private Sub CallCurrentCellChanged()
      AddHandler myDataGrid.CurrentCellChanged, AddressOf Grid_CurCellChange
   End Sub 'CallCurrentCellChanged
   
   
   ' Raise the event when focus on DataGrid cell changes.
    Private Sub Grid_CurCellChange(ByVal sender As Object, ByVal e As EventArgs)
        ' String variable used to show message.
        Dim myString As String = "CurrentCellChanged event raised, cell focus is at "
        ' Get the co-ordinates of the focussed cell.
        Dim myPoint As String = myDataGrid.CurrentCell.ColumnNumber + "," + myDataGrid.CurrentCell.RowNumber
        ' Create the alert message.
        myString = myString + "(" + myPoint + ")"
        ' Show Co-ordinates when CurrentCellChanged event is raised.
        MessageBox.Show(myString, "Current cell co-ordinates")
    End Sub 'Grid_CurCellChange
   