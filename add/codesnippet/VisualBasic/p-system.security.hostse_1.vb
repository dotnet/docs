    Private hostFlags As HostSecurityManagerOptions = HostSecurityManagerOptions.HostDetermineApplicationTrust Or HostSecurityManagerOptions.HostAssemblyEvidence

    Public Overrides ReadOnly Property Flags() As HostSecurityManagerOptions
        Get
            Return hostFlags
        End Get
    End Property
