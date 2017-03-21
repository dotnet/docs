    
    Private Sub ListView1_BeforeLabelEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.LabelEditEventArgs) _
        Handles ListView1.BeforeLabelEdit

        ' Allow all but the first two items of the list to be modified by
        ' the user.
        If (e.Item < 2) Then
            e.CancelEdit = True
        End If
    End Sub