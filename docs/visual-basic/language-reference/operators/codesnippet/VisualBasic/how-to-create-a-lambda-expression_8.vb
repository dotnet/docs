        Dim writeToLog = Sub(msg As String)
                             Dim log As New EventLog()
                             log.Source = "Application"
                             log.WriteEntry(msg)
                             log.Close()
                         End Sub