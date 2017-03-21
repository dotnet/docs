    <SecurityPermissionAttribute(SecurityAction.Demand, Execution:=True), SecurityPermissionAttribute(SecurityAction.Assert, Unrestricted:=True)> _
    Public Overrides Function DetermineApplicationTrust(ByVal applicationEvidence As Evidence, ByVal activatorEvidence As Evidence, ByVal context As TrustManagerContext) As ApplicationTrust
        If applicationEvidence Is Nothing Then
            Throw New ArgumentNullException("applicationEvidence")
        End If
        ' Get the activation context from the application evidence.
        ' This HostSecurityManager does not examine the activator evidence
        ' nor is it concerned with the TrustManagerContext;
        ' it simply grants the requested grant in the application manifest.
        Dim enumerator As IEnumerator = applicationEvidence.GetHostEnumerator()
        Dim activationArgs As ActivationArguments = Nothing
        While enumerator.MoveNext()
            activationArgs = enumerator.Current '
            If Not (activationArgs Is Nothing) Then
                Exit While
            End If
        End While
        If activationArgs Is Nothing Then
            Return Nothing
        End If
        Dim activationContext As ActivationContext = activationArgs.ActivationContext
        If activationContext Is Nothing Then
            Return Nothing
        End If
        Dim trust As New ApplicationTrust(activationContext.Identity)
        Dim asi As New ApplicationSecurityInfo(activationContext)
        trust.DefaultGrantSet = New PolicyStatement(asi.DefaultRequestSet, PolicyStatementAttribute.Nothing)
        trust.IsApplicationTrustedToRun = True
        Return trust

    End Function 'DetermineApplicationTrust
End Class