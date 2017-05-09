'<Snippet1>
' To replace the default security manager with MySecurityManager, add the 
' assembly to the GAC and call MySecurityManager in the
' custom implementation of the AppDomainManager.
Imports System
Imports System.Collections
Imports System.Net
Imports System.Reflection
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Policy
Imports System.Security.Principal
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Runtime.Hosting



<Assembly: System.Security.AllowPartiallyTrustedCallersAttribute()> 

<Serializable(), SecurityPermissionAttribute(SecurityAction.Demand, Flags:=SecurityPermissionFlag.Infrastructure)> _
Public Class MySecurityManager
    Inherits HostSecurityManager

    Public Sub New()
        Console.WriteLine(" Creating MySecurityManager.")

    End Sub 'New


    '<Snippet2>
    Private hostFlags As HostSecurityManagerOptions = HostSecurityManagerOptions.HostDetermineApplicationTrust Or HostSecurityManagerOptions.HostAssemblyEvidence

    Public Overrides ReadOnly Property Flags() As HostSecurityManagerOptions
        Get
            Return hostFlags
        End Get
    End Property

    '</Snippet2>
    '<Snippet5>
    Public Overrides Function ProvideAssemblyEvidence(ByVal loadedAssembly As [Assembly], ByVal evidence As Evidence) As Evidence
        Console.WriteLine("Provide assembly evidence for: " + IIf(loadedAssembly Is Nothing, "Unknown", loadedAssembly.ToString()) + ".") 'TODO: For performance reasons this should be changed to nested IF statements
        If evidence Is Nothing Then
            Return Nothing
        End If
        evidence.AddAssemblyEvidence(New CustomEvidenceType())
        Return evidence

    End Function 'ProvideAssemblyEvidence

    '</Snippet5>
    '<Snippet6>
    Public Overrides Function ProvideAppDomainEvidence(ByVal evidence As Evidence) As Evidence
        Console.WriteLine("Provide evidence for the " + AppDomain.CurrentDomain.FriendlyName + " AppDomain.")
        If evidence Is Nothing Then
            Return Nothing
        End If
        evidence.AddHostEvidence(New CustomEvidenceType())
        Return evidence

    End Function 'ProvideAppDomainEvidence

    '</Snippet6>
    '<Snippet3>
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
        '<Snippet4>
        Dim trust As New ApplicationTrust(activationContext.Identity)
        Dim asi As New ApplicationSecurityInfo(activationContext)
        trust.DefaultGrantSet = New PolicyStatement(asi.DefaultRequestSet, PolicyStatementAttribute.Nothing)
        trust.IsApplicationTrustedToRun = True
        '</Snippet4>
        Return trust

    End Function 'DetermineApplicationTrust
End Class
'</Snippet3>
<Serializable()> _
Public Class CustomEvidenceType
    Inherits EvidenceBase

    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return "CustomEvidenceType"

    End Function 'ToString
End Class
'</Snippet1>