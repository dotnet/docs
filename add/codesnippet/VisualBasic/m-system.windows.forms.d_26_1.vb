    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        ' Initialize the DataGridView control.
        Me.DataGridView1.ColumnCount = 5
        Me.DataGridView1.Rows.Add(New String() {"A", "B", "C", "D", "E"})
        Me.DataGridView1.Rows.Add(New String() {"F", "G", "H", "I", "J"})
        Me.DataGridView1.Rows.Add(New String() {"K", "L", "M", "N", "O"})
        Me.DataGridView1.Rows.Add(New String() {"P", "Q", "R", "S", "T"})
        Me.DataGridView1.Rows.Add(New String() {"U", "V", "W", "X", "Y"})
        Me.DataGridView1.AutoResizeColumns()
        Me.DataGridView1.ClipboardCopyMode = _
            DataGridViewClipboardCopyMode.EnableWithoutHeaderText

    End Sub

    Private Sub CopyPasteButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles CopyPasteButton.Click

        If Me.DataGridView1.GetCellCount( _
            DataGridViewElementStates.Selected) > 0 Then

            Try

                ' Add the selection to the clipboard.
                Clipboard.SetDataObject( _
                    Me.DataGridView1.GetClipboardContent())

                ' Replace the text box contents with the clipboard text.
                Me.TextBox1.Text = Clipboard.GetText()

            Catch ex As System.Runtime.InteropServices.ExternalException
                Me.TextBox1.Text = _
                    "The Clipboard could not be accessed. Please try again."
            End Try

        End If

    End Sub