    Sub ChangeAndPersistSettings()
        My.Settings.LastChanged = Today
        My.Settings.Save()
    End Sub