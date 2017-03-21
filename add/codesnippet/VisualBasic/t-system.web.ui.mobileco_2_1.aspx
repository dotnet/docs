    Private Sub Status_ItemCommand(ByVal sender As Object, _
        ByVal e As ListCommandEventArgs)

        Const spec As String = "You now have {0} tasks done, {1} " & _
            "tasks scheduled, and {2} tasks pending."

        ' Move selection to next status toward 'done'
        Select Case e.ListItem.Value
            Case "scheduled"
                schedCount -= 1
                pendCount += 1
                e.ListItem.Value = "pending"
            Case "pending"
                pendCount -= 1
                doneCount += 1
                e.ListItem.Value = "done"
                
        End Select

        ' Show the status of the current task
        Label1.Text = e.ListItem.Text & " is " & _
            e.ListItem.Value

        ' Show current selection counts
        Label2.Text = String.Format(spec, doneCount, _
            schedCount, pendCount)
    End Sub