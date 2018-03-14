' <snippet25>
Public Class SampleIPrincipal
    ' <snippet14>
    Implements System.Security.Principal.IPrincipal
    ' </snippet14>

    ' <snippet15>
    Private identityValue As SampleIIdentity
    ' </snippet15>

    Public ReadOnly Property Identity() As System.Security.Principal.IIdentity Implements System.Security.Principal.IPrincipal.Identity
        Get
            ' <snippet16>
            Return identityValue
            ' </snippet16>
        End Get
    End Property

    Public Function IsInRole(ByVal role As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole
        ' <snippet17>
        Return role = identityValue.Role.ToString
        ' </snippet17>
    End Function

    ' <snippet18>
    Public Sub New(ByVal name As String, ByVal password As String)
        identityValue = New SampleIIdentity(name, password)
    End Sub
    ' </snippet18>

End Class
' </snippet25>
