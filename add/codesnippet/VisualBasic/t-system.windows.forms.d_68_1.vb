    Private WithEvents dataGridView1 As New DataGridView()

    Private Sub AddColorColumn()

        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.Items.AddRange( _
            Color.Red, Color.Yellow, Color.Green, Color.Blue)
        comboBoxColumn.ValueType = GetType(Color)
        dataGridView1.Columns.Add(comboBoxColumn)

    End Sub

    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, _
        ByVal e As DataGridViewEditingControlShowingEventArgs) _
        Handles dataGridView1.EditingControlShowing

        Dim combo As ComboBox = CType(e.Control, ComboBox)
        If (combo IsNot Nothing) Then

            ' Remove an existing event-handler, if present, to avoid 
            ' adding multiple handlers when the editing control is reused.
            RemoveHandler combo.SelectedIndexChanged, _
                New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

            ' Add the event handler. 
            AddHandler combo.SelectedIndexChanged, _
                New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

        End If

    End Sub

    Private Sub ComboBox_SelectedIndexChanged( _
        ByVal sender As Object, ByVal e As EventArgs)

        Dim comboBox1 As ComboBox = CType(sender, ComboBox)
        comboBox1.BackColor = _
            CType(CType(sender, ComboBox).SelectedItem, Color)

    End Sub