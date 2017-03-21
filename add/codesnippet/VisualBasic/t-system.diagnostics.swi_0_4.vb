Public Class Class1
    ' Create an instance of MyMethodTracingSwitch.
    Private Shared mySwitch As New _
        MyMethodTracingSwitch("Methods", "Trace entering and exiting method")

    Public Shared Sub Main()
        ' Add the console listener to see trace messages as console output
        Trace.Listeners.Add(New ConsoleTraceListener(True))
        Debug.AutoFlush = True

        ' Set the switch level to both enter and exit
        mySwitch.Level = MethodTracingSwitchLevel.Both

        ' Write a diagnostic message if the switch is set to entering.
        Debug.WriteLineIf(mySwitch.OutputEnter, "Entering Main")

        ' Insert code to handle processing here...

        ' Write another diagnostic message if the switch is set to exiting.
        Debug.WriteLineIf(mySwitch.OutputExit, "Exiting Main")
    End Sub
End Class 'MyClass