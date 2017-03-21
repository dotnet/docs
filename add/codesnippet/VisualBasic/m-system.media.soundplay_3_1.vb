        Try
            ' Assign the selected file's path to the SoundPlayer object.
            player.SoundLocation = Me.filepathTextbox.Text

            ' Load the .wav file.
            player.LoadAsync()
        Catch ex As Exception
            ReportStatus(ex.Message)
        End Try