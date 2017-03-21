    Private Sub Status_DataBinding(ByVal sender As Object, _
        ByVal e As ListDataBindEventArgs)

        ' Increment initial counts
        Select Case e.ListItem.Value
            Case "done"
                doneCount += 1
            Case "scheduled"
                schedCount += 1
            Case "pending"
                pendCount += 1
        End Select
    End Sub