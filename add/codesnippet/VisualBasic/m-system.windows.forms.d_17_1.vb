    ' Override OnMouseClick in a class derived from DataGridViewCell to 
    ' enter edit mode when the user clicks the cell. 
    Protected Overrides Sub OnMouseClick( _
        ByVal e As DataGridViewCellMouseEventArgs)

        If MyBase.DataGridView IsNot Nothing Then

            Dim point1 As Point = MyBase.DataGridView.CurrentCellAddress
            If point1.X = e.ColumnIndex And _
                point1.Y = e.RowIndex And _
                e.Button = MouseButtons.Left And _
                Not MyBase.DataGridView.EditMode = _
                DataGridViewEditMode.EditProgrammatically Then

                MyBase.DataGridView.BeginEdit(True)

            End If
        End If
    End Sub