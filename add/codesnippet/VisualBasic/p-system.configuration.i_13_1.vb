         ' Set the logfile name in the commandline argument array.
         Dim commandLineOptions(0) As String
         commandLineOptions(0) = "/LogFile=example.log"
         myAssemblyInstaller.CommandLine = commandLineOptions