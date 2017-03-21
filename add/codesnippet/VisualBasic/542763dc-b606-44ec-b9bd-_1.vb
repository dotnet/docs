            ' Create an InstallContext object with the given parameters.
            Dim commandLine() As String = New String(args.Length - 2) {}
            Dim i As Integer
            For i = 1 To args.Length - 1
               commandLine(i-1) = args(i)
            Next i
            myInstallObject.myInstallContext = _
               New InstallContext("/LogFile:example.log", commandLine)