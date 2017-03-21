    ' Use the enumeration flags to indicate that this method exposes shared
    ' state, self-affecting process management, and self-affecting threading.
    <HostProtectionAttribute(SharedState := True, _
        SelfAffectingProcessMgmt := True, _
        SelfAffectingThreading := True, UI := True)> _
    Private Shared Sub ExecuteBreak()

        ' This method allows the user to quit the sample.
        Console.WriteLine("Executing Debugger.Break.")
        Debugger.Break()
        Debugger.Log(1, "info", "test message")
    End Sub 'ExecuteBreak