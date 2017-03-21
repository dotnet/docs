    ' Run this method from within a method protected by the PrincipalPermissionAttribute
    ' to see the security context data, including the primary identity.
    Public Sub WriteServiceSecurityContextData(ByVal fileName As String)
        Dim sw As New StreamWriter(fileName)
        Try
            ' Write the primary identity and Windows identity. The primary identity is derived from the
            ' the credentials used to authenticate the user. The Windows identity may be a null string.
            sw.WriteLine("PrimaryIdentity: {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
            sw.WriteLine("WindowsIdentity: {0}", ServiceSecurityContext.Current.WindowsIdentity.Name)
            sw.WriteLine()
            ' Write the claimsets in the authorization context. By default, there is only one claimset
            ' provided by the system. 
            Dim claimset As ClaimSet
            For Each claimset In ServiceSecurityContext.Current.AuthorizationContext.ClaimSets
                Dim claim As Claim
                For Each claim In claimset
                    ' Write out each claim type, claim value, and the right. There are two
                    ' possible values for the right: "identity" and "possessproperty". 
                    sw.WriteLine("Claim Type = {0}", claim.ClaimType)
                    sw.WriteLine(vbTab + " Resource = {0}", claim.Resource.ToString())
                    sw.WriteLine(vbTab + " Right = {0}", claim.Right)
                Next claim
            Next claimset
        Finally
            sw.Dispose()
        End Try

    End Sub