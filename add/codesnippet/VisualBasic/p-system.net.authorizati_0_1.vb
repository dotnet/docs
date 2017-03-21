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
