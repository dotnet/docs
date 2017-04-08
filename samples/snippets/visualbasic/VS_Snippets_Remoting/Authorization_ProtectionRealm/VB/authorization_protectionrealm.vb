' System.Net.Authorization.Authorization(string,bool);System.Net.Authorization.ProtectionRealm
'   This program demonstrates the 'ProtectionRealm' property and 'Authorization(string,bool)' constructor of 
'   the "Authorization" class. The "IAuthenticationModule" interface is implemented in 'CloneBasic' to make
'   it a custom authentication module. The custom authentication module encodes username and password as
'   base64 strings and then returns back an 'Authorization' instance. The 'Authorization' instance encapsulates
'   a list of Uri's for which it is applicable using the "ProtectionRealm" property.
' 
Imports System
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic

Namespace CloneBasicAuthentication
    
    ' The 'CloneBasic' authentication module class implements 'IAuthenticationModule'.
    Class CloneBasic
        Implements IAuthenticationModule

        Private m_authenticationType As String
        Private m_canPreAuthenticate As Boolean
        
        
        Public Sub New()
            m_authenticationType = "CloneBasic"
            m_canPreAuthenticate = False
        End Sub 'New
        
        ReadOnly Property AuthenticationType() As String Implements IAuthenticationModule.AuthenticationType
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
' <Snippet2>
        Function Authenticate(ByVal challenge As String, ByVal request As WebRequest, ByVal credentials As ICredentials) As Authorization Implements IAuthenticationModule.Authenticate
            Try
                Dim message As String
                ' Check if Challenge string was raised by a site which requires 'CloneBasic' authentication.
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
                End If
                ' Message encryption scheme : 
                ' a)Concatenate username and password seperated by space
                ' b)Apply ASCII encoding to obtain a stream of bytes
                ' c)Apply Base64 Encoding to this array of bytes to obtain our encoded authorization message
                message = myCredentials.UserName + " " + myCredentials.Password
                ' Apply AsciiEncoding to 'message' string to obtain it as an array of bytes.
                Dim ascii As Encoding = Encoding.ASCII
                Dim byteArray(ascii.GetByteCount(message)) As Byte
                byteArray = ascii.GetBytes(message)

                ' Performing Base64 transformation.
                message = Convert.ToBase64String(byteArray)
                Dim myAuthorization As New Authorization("CloneBasic " + message, True)
                Dim protectionRealm() As String = {request.RequestUri.AbsolutePath}
                myAuthorization.ProtectionRealm = protectionRealm

                Return myAuthorization
            Catch e As Exception
                Console.WriteLine("The following exception was raised in Authenticate method:{0}", e.Message)
                Return Nothing
            End Try
        End Function 'Authenticate

        ' </Snippet1>
        ' </Snippet2>

        Function PreAuthenticate(ByVal request As WebRequest, ByVal credentials As ICredentials) As Authorization Implements IAuthenticationModule.PreAuthenticate
            PreAuthenticate = Nothing
        End Function 'PreAuthenticate
    End Class 'CloneBasic
    ' 'CloneBasic' class ends here.

    ' The 'Client' class is defined here to test the above  custom authentication module.
    Class Client

        'Entry point which delegates to C-style main Private Function
        Public Overloads Shared Sub Main()
            Main2(System.Environment.GetCommandLineArgs())
        End Sub

        Public Overloads Shared Sub Main2(ByVal args() As String)
            Dim url, userName, passwd As String
            If args.Length < 4 Then
                Client.PrintUsage()
                Return
            Else
                url = args(1)
                userName = args(2)
                passwd = args(3)
            End If
            Console.WriteLine()
            Dim authenticationModule As New CloneBasic
            AuthenticationManager.Register(authenticationModule)
            AuthenticationManager.Unregister("Basic")
            ' Get the response from the Uri. 
            GetPage(url, userName, passwd)
        End Sub 'Main


        Public Shared Sub GetPage(ByVal url As [String], ByVal username As String, ByVal passwd As String)
            Try
                Dim challenge As String
                Dim myHttpWebRequest As HttpWebRequest
                Try
                    ' Create a 'HttpWebRequest' object for the above 'url'.
                    myHttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
                    ' The following method call throws the WebException.
                    Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
                    ' Release resources of response object.
                    myHttpWebResponse.Close()
                Catch e As WebException
                    Dim i As Integer

                    While i < e.Response.Headers.Count
                        ' Retrieve the challenge string from the header "WWW-Authenticate"
                        If [String].Compare(e.Response.Headers.Keys(i), "WWW-Authenticate", True) = 0 Then
                            challenge = e.Response.Headers(i)
                        End If
                        i = i + 1
                    End While
                End Try 'end of catch block
                If Not (challenge Is Nothing) Then
                    ' Challenge was raised by the client.Declare your credentials
                    Dim myCredentials As New NetworkCredential(username, passwd)

                    ' Pass the challenge , 'NetworkCredential' object and the 'HttpWebRequest' object to the
                    ' Authenticate' method of the  "AuthenticationManager" to retrieve an "Authorization" 
                    ' instance. 
                    Dim urlAuthorization As Authorization = AuthenticationManager.Authenticate(challenge, myHttpWebRequest, myCredentials)
                    If Not (urlAuthorization Is Nothing) Then
                        Console.WriteLine("Successfully Created 'Authorization' object with authorization Message: ")
                        Console.WriteLine(urlAuthorization.Message)
                        Console.WriteLine("This authorization is valid for the following Uri's:")
                        Dim count As Integer = 0
                        Dim uri As String
                        For Each uri In urlAuthorization.ProtectionRealm
                            count = count + 1
                            Console.WriteLine(ControlChars.Cr + "Uri[{0}]: {1}", count, uri)
                        Next uri
                    Else
                        Console.WriteLine(ControlChars.Cr + "Authorization object was returned as null. Please check if site accepts 'CloneBasic' authentication")
                    End If
                End If
            Catch e As Exception
                Console.WriteLine(ControlChars.Cr + " The following exception was raised : {0}", e.Message)
            End Try
        End Sub 'GetPage


        Public Shared Sub PrintUsage()
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Usage: Try a site which requires CloneBasic(custom made) authentication as below")
            Console.WriteLine("   Authorization_ProtectionRealm URLname username password")
            Console.WriteLine(ControlChars.Cr + "Example:")
            Console.WriteLine(ControlChars.Cr + "   Authorization_ProtectionRealm http://www.microsoft.com/net/ george george123")
        End Sub 'PrintUsage
    End Class 'Client class ends here.	
End Namespace 'CloneBasicAuthentication
