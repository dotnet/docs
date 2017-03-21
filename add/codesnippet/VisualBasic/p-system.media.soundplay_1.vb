        Try
            ' Assign the selected file's path to the SoundPlayer object.
            player.SoundLocation = filepathTextbox.Text

            ' Load the .wav file.
            player.Load()
        Catch ex As Exception
            ReportStatus(ex.Message)
        End Try