            ' Check wether the "LogtoConsole" parameter has been set.
            If myInstallContext.IsParameterTrue("LogtoConsole") = True Then
               ' Display the message to the console and add it to the logfile.
               myInstallContext.LogMessage("The 'Install' method has been called")
            End If