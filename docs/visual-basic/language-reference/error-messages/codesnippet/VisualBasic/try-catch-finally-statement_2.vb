        Try
            Process.Start("http://www.microsoft.com")
        Catch ex As Exception
            MsgBox("Can't load Web page" & vbCrLf & ex.Message)
        End Try