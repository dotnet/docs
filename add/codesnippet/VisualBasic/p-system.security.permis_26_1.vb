    ' Use the enumeration flags to indicate that this method exposes 
    ' shared state and self-affecting process management.
    ' Either of the following attribute statements can be used to set the 
    ' resource flags.
    <HostProtectionAttribute(SharedState := True, _
        SelfAffectingProcessMgmt := True), _
        HostProtectionAttribute( _
        Resources := HostProtectionResource.SharedState Or _
        HostProtectionResource.SelfAffectingProcessMgmt)> _
    Private Shared Sub [Exit](ByVal Message As String, ByVal Code As Integer)

        ' Exit the sample when an exception is thrown.
        Console.WriteLine((ControlChars.Lf & "FAILED: " & Message & " " & _
            Code.ToString()))
        Environment.ExitCode = Code
        Environment.Exit(Code)
    End Sub 'Exit