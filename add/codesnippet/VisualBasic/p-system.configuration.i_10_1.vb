         Dim myStringDictionary As StringDictionary = myInstallContext.Parameters
         If myStringDictionary.Count = 0 Then
            Console.WriteLine("No parameters have been entered in the command line" + _
                        "hence, the install will take place in the silent mode")
         Else
            ' Check wether the "LogtoConsole" parameter has been set.
            If myInstallContext.IsParameterTrue("LogtoConsole") = True Then
               ' Display the message to the console and add it to the logfile.
               myInstallContext.LogMessage("The 'Install' method has been called")
            End If
         End If