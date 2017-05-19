'<Snippet1>
Module Module1
    'Add references to Microsoft.Build.Framework and
    'Microsoft.Build.BuildEngine
    Sub Main()
        'Create a new Engine object
        Dim engine As New Engine()

        'Point to the path that contains the .NET Framework 2.0 CLR and tools
        engine.BinPath = "c:\windows\microsoft.net\framework\v2.0.xxxxx"

        'Instantiate a new FileLogger to generate a build log
        Dim logger As New FileLogger()

        'Set logfile parameter to indicate the log destination
        logger.Parameters = "logfile=c:\temp\build.log"

        'Register the logger with the engine
        engine.RegisterLogger(logger)

        'Build the project file
        Dim success As Boolean = engine.BuildProjectFile("c:\temp\validate.proj")

        'Unregister all loggers to close the log file
        engine.UnregisterAllLoggers()

        If success Then
            Console.WriteLine("Build succeeded.")
        Else
            Console.WriteLine("Build failed. View C:\temp\build.log for details.")
        End If
    End Sub

End Module
'</Snippet1>