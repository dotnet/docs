    Private Function LoadControlProperties(ByVal serializedProperties As String) As ICollection

        Dim controlProperties As ICollection = Nothing

        ' Create an ObjectStateFormatter to deserialize the properties.
        Dim formatter As New ObjectStateFormatter()

        Try
            ' Call the Deserialize method.
            controlProperties = CType(formatter.Deserialize(serializedProperties), ArrayList)
        Catch e As HttpException
            Dim vse As ViewStateException
            Dim logMessage As String

            vse = e.InnerException

            logMessage = "ViewStateException. Path: " + vse.Path + Environment.NewLine
            logMessage += "PersistedState: " + vse.PersistedState + Environment.NewLine
            logMessage += "Referer: " + vse.Referer + Environment.NewLine
            logMessage += "UserAgent: " + vse.UserAgent + Environment.NewLine

            LogEvent(logMessage)

            If (vse.IsConnected) Then
                HttpContext.Current.Response.Redirect("ErrorPage.aspx")
            Else
                Throw e
            End If
        End Try
        Return controlProperties
    End Function 'LoadControlProperties   