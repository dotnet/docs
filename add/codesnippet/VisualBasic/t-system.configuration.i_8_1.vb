      Dim options As New ArrayList()
      Dim myOption As String
      Dim toUnInstall As Boolean = False
      Dim toPrintHelp As Boolean = False
      Dim myTransactedInstaller As New TransactedInstaller()
      Dim myAssemblyInstaller As AssemblyInstaller
      Dim myInstallContext As InstallContext

      Try
         Dim i As Integer
         For i = 1 To args.Length - 1
            ' Process the arguments.
            If args(i).StartsWith("/") Or args(i).StartsWith("-") Then
               myOption = args(i).Substring(1)
               ' Determine whether the option is to 'uninstall' an assembly.
               If String.Compare(myOption, "u", True) = 0 Or _
                  String.Compare(myOption,"uninstall", True) = 0 Then
                  toUnInstall = True
                  GoTo ContinueFor1
               End If
               ' Determine whether the option is for printing help information.
               If String.Compare(myOption, "?", True) = 0 Or _
                  String.Compare(myOption, "help", True) = 0 Then
                  toPrintHelp = True
                  GoTo ContinueFor1
               End If
               ' Add the option encountered to the list of all options
               ' encountered for the current assembly.
               options.Add(myOption)
            Else
               ' Determine whether the assembly file exists.
               If Not File.Exists(args(i)) Then
                  ' If assembly file doesn't exist then print error.
                  Console.WriteLine(ControlChars.Newline + _
                           "Error : {0} - Assembly file doesn't exist.", args(i))
                  Return
               End If

               ' Create a instance of 'AssemblyInstaller' that installs the given assembly.
               myAssemblyInstaller = New AssemblyInstaller(args(i), _
                              CType(options.ToArray(GetType(String)), String()))
               ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
               myTransactedInstaller.Installers.Add(myAssemblyInstaller)
            End If
         ContinueFor1:
         Next i
         ' If user requested help or didn't provide any assemblies to install
         ' then print help message.
         If toPrintHelp Or myTransactedInstaller.Installers.Count = 0 Then
            PrintHelpMessage()
            Return
         End If

         ' Create a instance of 'InstallContext' with the options specified.
         myInstallContext = New InstallContext("Install.log", _
                     CType(options.ToArray(GetType(String)), String()))
         myTransactedInstaller.Context = myInstallContext

         ' Install or Uninstall an assembly depending on the option provided.
         If Not toUnInstall Then
            myTransactedInstaller.Install(New Hashtable())
         Else
            myTransactedInstaller.Uninstall(Nothing)
         End If
      Catch e As Exception
         Console.WriteLine(ControlChars.Newline + "Exception raised : {0}", e.Message)
      End Try