    Sub ShowLocalizedMessage()
        Dim culture As String = My.Application.UICulture.Name
        My.Application.ChangeUICulture("fr-FR")
        MsgBox(My.Resources.Message)
        My.Application.ChangeUICulture(culture)
    End Sub