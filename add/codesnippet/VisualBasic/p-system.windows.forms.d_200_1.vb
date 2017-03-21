    Private Sub WatchRowsModeChanges(ByVal sender As Object, _
        ByVal modeEvent As DataGridViewAutoSizeModeEventArgs) _
        Handles DataGridView1.AutoSizeRowsModeChanged

        Dim label As Label = CType(FlowLayoutPanel1.Controls _
            (currentLayoutName), Label)

        If modeEvent.PreviousModeAutoSized Then
            label.Text = "changed to different " & label.Name & _
                DataGridView1.AutoSizeRowsMode.ToString()
        Else
            label.Text = label.Name & _
                DataGridView1.AutoSizeRowsMode.ToString()
        End If
    End Sub