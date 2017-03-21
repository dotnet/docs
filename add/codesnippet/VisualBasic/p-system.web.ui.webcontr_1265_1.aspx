        If sourcePriority.SelectedValue = "Normal" Then
            md.Priority = MailPriority.Normal
        ElseIf sourcePriority.SelectedValue = "High" Then
            md.Priority = MailPriority.High
        ElseIf sourcePriority.SelectedValue = "Low" Then
            md.Priority = MailPriority.Low
        End If