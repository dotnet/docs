 ' This program demonstrates the contructor 'Authorization(string,bool,string)' of the authorization 
' * class.
' * 
' * We implement the interface "IAuthenticationModule" to make CloneBasic which is a custom authentication module.
' * The custom authentication module encodes username and password as base64 strings and then returns 
' * back an authorization instance. This authorization is internally used by the HttpWebRequest for 
' * authentication.
' * * 
' * Please Note : This program has to be compiled as a dll.
' 
Imports System
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic

Namespace CloneBasicAuthentication
    
    
    Public Class CloneBasic
        Implements IAuthenticationModule
        Private m_authenticationType As String
        Private m_canPreAuthenticate As Boolean
        
        
        Public Sub New()
            m_authenticationType = "CloneBasic"
            m_canPreAuthenticate = False
        End Sub 'New
        
        Public ReadOnly Property AuthenticationType() As String Implements IAuthenticationModule.AuthenticationType
            Get
                Return m_authenticationType
            End Get
        End Property
        
        Public ReadOnly Property CanPreAuthenticate() As Boolean Implements IAuthenticationModule.CanPreAuthenticate
            Get
                Return m_canPreAuthenticate
            End Get
        End Property
        
        
' <Snippet1>
        Public Function Authenticate(challenge As String, request As WebRequest, credentials As ICredentials) As Authorization Implements IAuthenticationModule.Authenticate
            Try
                Dim message As String
                ' Check if Challenge string was raised by a site which requires CloneBasic authentication.
                If challenge Is Nothing Or Not challenge.StartsWith("CloneBasic") Then
                    Return Nothing
                End If
                Dim myCredentials As NetworkCredential
                If TypeOf credentials Is CredentialCache Then
                    myCredentials = credentials.GetCredential(request.RequestUri, "CloneBasic")
                    If myCredentials Is Nothing Then
                        Return Nothing
                    End If
                Else
                    myCredentials = CType(credentials, NetworkCredential)
                End If 'Message encryption scheme : 
                '        a)Concatenate username and password seperated by space
                '        b)Apply ASCII encoding to obtain a stream of bytes
                '        c)Apply Base64 Encoding to this array of bytes to obtain our encoded authorization message

                message = myCredentials.UserName + " " + myCredentials.Password
                'Apply AsciiEncoding to our user name and password to obtain it as an array of bytes
                Dim asciiEncoding As Encoding = Encoding.ASCII
                Dim byteArray(asciiEncoding.GetByteCount(message)) As Byte
                byteArray = asciiEncoding.GetBytes(message)

                'Perform Base64 transform
                message = Convert.ToBase64String(byteArray)
                'The following overloaded contructor sets the 'Message' property of authorization to the base64 string
                '         *that  we just formed and it also sets the 'Complete' property to true and the connection group id
                '         *to the domain of the NetworkCredential object
                Dim myAuthorization As New Authorization("CloneBasic " + message, True, request.ConnectionGroupName)
                Return myAuthorization
            Catch e As Exception
                Console.WriteLine(("Exception Raised ...:" + e.Message))
                Return Nothing
            End Try
        End Function 'Authenticate
' </Snippet1>


        Public Function PreAuthenticate(request As WebRequest, credentials As ICredentials) As Authorization Implements IAuthenticationModule.PreAuthenticate
            Return Nothing
        End Function 'PreAuthenticate

    End Class 'CloneBasic
'End of namespace CloneBasicAuthentication
End Namespace 'CloneBasicAuthentication 