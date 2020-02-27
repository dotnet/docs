' <snippet24>
Public Class SampleIIdentity
    ' <snippet5>
    Implements System.Security.Principal.IIdentity
    ' </snippet5>

    ' <snippet6>
    Private nameValue As String
    Private authenticatedValue As Boolean
    Private roleValue As ApplicationServices.BuiltInRole
    ' </snippet6>

    Public ReadOnly Property AuthenticationType() As String Implements System.Security.Principal.IIdentity.AuthenticationType
        Get
            ' <snippet7>
            Return "Custom Authentication"
            ' </snippet7>
        End Get
    End Property

    Public ReadOnly Property IsAuthenticated() As Boolean Implements System.Security.Principal.IIdentity.IsAuthenticated
        Get
            ' <snippet8>
            Return authenticatedValue
            ' </snippet8>
        End Get
    End Property

    Public ReadOnly Property Name() As String Implements System.Security.Principal.IIdentity.Name
        Get
            ' <snippet9>
            Return nameValue
            ' </snippet9>
        End Get
    End Property

    ' <snippet10>
    Public ReadOnly Property Role() As ApplicationServices.BuiltInRole
        Get
            Return roleValue
        End Get
    End Property
    ' </snippet10>

    ' <snippet11>
    Public Sub New(ByVal name As String, ByVal password As String)
        ' The name is not case sensitive, but the password is.
        If IsValidNameAndPassword(name, password) Then
            nameValue = name
            authenticatedValue = True
            roleValue = ApplicationServices.BuiltInRole.Administrator
        Else
            nameValue = ""
            authenticatedValue = False
            roleValue = ApplicationServices.BuiltInRole.Guest
        End If
    End Sub
    ' </snippet11>

    ' <snippet12>
    Private Function IsValidNameAndPassword( 
        ByVal username As String, 
        ByVal password As String) As Boolean

        ' Look up the stored hashed password and salt for the username.
        Dim storedHashedPW As String = GetHashedPassword(username)
        Dim salt As String = GetSalt(username)

        'Create the salted hash.
        Dim rawSalted As String = salt & Trim(password)
        Dim saltedPwBytes() As Byte = 
            System.Text.Encoding.Unicode.GetBytes(rawSalted)
        Dim sha1 As New System.Security.Cryptography.
            SHA1CryptoServiceProvider
        Dim hashedPwBytes() As Byte = sha1.ComputeHash(saltedPwBytes)
        Dim hashedPw As String = Convert.ToBase64String(hashedPwBytes)

        ' Compare the hashed password with the stored password.
        Return hashedPw = storedHashedPW
    End Function
    ' </snippet12>

    ' <snippet13>
    Private Function GetHashedPassword(ByVal username As String) As String
        ' Code that gets the user's hashed password goes here.
        ' This example uses a hard-coded hashed passcode.
        ' In general, the hashed passcode should be stored 
        ' outside of the application.
        If Trim(username).ToLower = "testuser" Then
            Return "ZFFzgfsGjgtmExzWBRmZI5S4w6o="
        Else
            Return ""
        End If
    End Function

    Private Function GetSalt(ByVal username As String) As String
        ' Code that gets the user's salt goes here.
        ' This example uses a hard-coded salt.
        ' In general, the salt should be stored 
        ' outside of the application.
        If Trim(username).ToLower = "testuser" Then
            Return "Should be a different random value for each user"
        Else
            Return ""
        End If
    End Function
    ' </snippet13>

End Class
' </snippet24>
