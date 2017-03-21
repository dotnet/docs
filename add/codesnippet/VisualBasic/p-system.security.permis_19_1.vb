    ' Use the enumeration flags to indicate that this method exposes shared  
    ' state, self-affecting threading, and the security infrastructure.
    <HostProtectionAttribute(SharedState := True, _
        SelfAffectingThreading := True, _
        SecurityInfrastructure := True)> _
    Private Shared Function ApplyIdentity() As Integer

        ' ApplyIdentity sets the current identity.
        Dim roles(1) As String
        Try
            Dim mAD As AppDomain = AppDomain.CurrentDomain
            Dim mGenPr As _
                New GenericPrincipal(WindowsIdentity.GetCurrent(), roles)
            mAD.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
            mAD.SetThreadPrincipal(mGenPr)
            Return Success
        Catch e As Exception
            [Exit](e.ToString(), 5)
        End Try
        Return 0
    End Function 'ApplyIdentity