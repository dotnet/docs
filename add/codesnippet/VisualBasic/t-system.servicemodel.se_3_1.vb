    ' When this method runs, the caller must be an authenticated user and the ServiceSecurityContext 
    ' is not a null instance. 
    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
        ' Write data from the ServiceSecurityContext to a file using the StreamWriter class.
        Dim sw As New StreamWriter("c:\ServiceSecurityContextInfo.txt")
        Try
            ' Write the primary identity and Windows identity. The primary identity is derived from 
            ' the credentials used to authenticate the user. The Windows identity may be a null string.
            sw.WriteLine("PrimaryIdentity: {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
            sw.WriteLine("WindowsIdentity: {0}", ServiceSecurityContext.Current.WindowsIdentity.Name)

            ' Write the claimsets in the authorization context. By default, there is only one claimset
            ' provided by the system. 
            Dim claimset As ClaimSet
            For Each claimset In ServiceSecurityContext.Current.AuthorizationContext.ClaimSets
                Dim claim As Claim
                For Each claim In claimset
                    ' Write out each claim type, claim value, and the right. There are two
                    ' possible values for the right: "identity" and "possessproperty". 
                    sw.WriteLine("Claim Type: {0}, Resource: {1} Right: {2}", _
                    claim.ClaimType, _
                    claim.Resource.ToString(), _
                    claim.Right)
                    sw.WriteLine()
                Next claim
            Next claimset
        Finally
            sw.Dispose()
        End Try
        Return n1 + n2
    End Function