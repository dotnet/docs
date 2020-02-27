Imports System.Net

Public Class ListenerBasic
    ' <Snippet1>
    Public Shared Sub DisplayPrefixesAndState(ByVal listener As HttpListener)
        ' List the prefixes to which the server listens.
        Dim prefixes As HttpListenerPrefixCollection = listener.Prefixes

        If prefixes.Count = 0 Then
            Console.WriteLine("There are no prefixes.")
        End If

        For Each prefix As String In prefixes
            Console.WriteLine(prefix)
        Next

        ' Show the listening state.
        If listener.IsListening Then
            Console.WriteLine("The server is listening.")
        End If
    End Sub
    ' </Snippet1>

    ' <Snippet2>
    Public Shared Sub SimpleListenerExample(prefixes As String())
        If Not HttpListener.IsSupported Then
            Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.")
            Return
        End If
        ' URI prefixes are required,
        ' for example "http://contoso.com:8080/index/".
        If prefixes Is Nothing Or prefixes.Length = 0 Then
            Throw New ArgumentException("prefixes")
        End If

        ' Create a listener
        Dim listener = New HttpListener()

        For Each s As String In prefixes
            listener.Prefixes.Add(s)
        Next
        listener.Start()
        Console.WriteLine("Listening...")
        ' Note: The GetContext method blocks while waiting for a request.
        Dim context As HttpListenerContext = listener.GetContext()
        Console.WriteLine("Listening...")
        ' Obtain a response object
        Dim request As HttpListenerRequest = context.Request
        ' Construct a response.
        Dim response As HttpListenerResponse = context.Response
        Dim responseString As String = "<HTML><BODY> Hello world!</BODY></HTML>"
        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
        ' Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length
        Dim output As System.IO.Stream = response.OutputStream
        output.Write(buffer, 0, buffer.Length)
        'You must close the output stream.
        output.Close()
        listener.Stop()
    End Sub
    ' </Snippet2>

    ' <Snippet3>
    ' This example requires the System and System.Net namespaces.
    ' <Snippet8>
    Public Shared Function ClientInformation(ByVal context As HttpListenerContext) As String
        Dim user As System.Security.Principal.IPrincipal = context.User
        Dim id As System.Security.Principal.IIdentity = user.Identity

        If id Is Nothing Then
            Return "Client authentication is not enabled for this Web server."
        End If

        Dim display As String

        If id.IsAuthenticated Then
            display = String.Format("{0} was authenticated using {1}", id.Name, id.AuthenticationType)
        Else
            display = String.Format("{0} was not authenticated", id.Name)
        End If

        Return display
    End Function
    ' </Snippet8>

    Public Shared Sub SimpleListenerWithAuthentication(ByVal prefixes As String())
        If Not HttpListener.IsSupported Then
            Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.")
            Return
        End If

        ' URI prefixes are required,
        ' for example "http://contoso.com:8080/index/"
        If prefixes Is Nothing OrElse prefixes.Length = 0 Then Throw New ArgumentException("prefixes")
        Dim listener As HttpListener = New HttpListener()

        ' <Snippet9>
        For Each s As String In prefixes
            listener.Prefixes.Add(s)
        Next

        listener.Start()
        ' </Snippet9>
        ' Specify Negotiate as the authentication scheme.
        listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate
        Console.WriteLine("Listening...")
        ' GetContext blocks while waiting for a request.
        Dim context As HttpListenerContext = listener.GetContext()
        Dim request As HttpListenerRequest = context.Request
        ' Obtain a response object.
        Dim response As HttpListenerResponse = context.Response
        Dim clientInformationString As String = ClientInformation(context)
        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes("<HTML><BODY> " & clientInformationString & "</BODY></HTML>")
        ' Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length
        Dim output As System.IO.Stream = response.OutputStream
        output.Write(buffer, 0, buffer.Length)
        output.Close()
        listener.Stop()
    End Sub
    ' </Snippet3>

    ' <Snippet4>
    Public Shared Function CheckForPrefix(ByVal listener As HttpListener, ByVal prefix As String) As Boolean
        Dim prefixes As HttpListenerPrefixCollection = listener.Prefixes

        ' Get the prefixes that the Web server is listening to.
        If prefixes.Count = 0 OrElse prefix Is Nothing Then
            Return False
        End If

        Return prefixes.Contains(prefix)
    End Function
    ' </Snippet4>

    ' <Snippet6>
    Public Shared Function RemoveAllPrefixes(ByVal listener As HttpListener) As Boolean
        ' Get the prefixes that the Web server is listening to.
        Dim prefixes As HttpListenerPrefixCollection = listener.Prefixes

        Try
            prefixes.Clear()
        Catch ' If the operation failed, return false.
            Return False
        End Try

        Return True
    End Function
    ' </Snippet6>

    ' <Snippet7>
    Public Shared Function CopyPrefixes(ByVal listener As HttpListener) As String()
        Dim prefixes As HttpListenerPrefixCollection = listener.Prefixes
        Dim prefixArray As String() = New String(prefixes.Count - 1) {}
        prefixes.CopyTo(prefixArray, 0)
        Return prefixArray
    End Function
    ' </Snippet7>

    ' <Snippet10>
    Public Shared Sub ConfigureListener1(ByVal listener As HttpListener)
        ' Specify an authentication realm.
        listener.Realm = "ExampleRealm"
    End Sub
    ' </Snippet10>

    ' <Snippet11>
    Public Shared Sub CheckTestUrl(ByVal listener As HttpListener, ByVal request As HttpListenerRequest)
        If request.RawUrl = "/www.contoso.com/test/NoReply" Then
            listener.Abort()
            Return
        End If
    End Sub
    ' </Snippet11>

    ' <Snippet12>
    Public Shared Sub NonblockingListener(ByVal prefixes As String())
        Dim listener As HttpListener = New HttpListener()

        For Each s As String In prefixes
            listener.Prefixes.Add(s)
        Next

        listener.Start()
        Dim result As IAsyncResult = listener.BeginGetContext(New AsyncCallback(AddressOf ListenerCallback), listener)
        ' Applications can do some work here while waiting for the 
        ' request. If no work can be done until you have processed a request,
        ' use a wait handle to prevent this thread from terminating
        ' while the asynchronous operation completes.
        Console.WriteLine("Waiting for request to be processed asyncronously.")
        result.AsyncWaitHandle.WaitOne()
        Console.WriteLine("Request processed asyncronously.")
        listener.Close()
    End Sub
    ' </Snippet12>

    ' <Snippet13>
    Public Shared Sub ListenerCallback(ByVal result As IAsyncResult)
        Dim listener As HttpListener = CType(result.AsyncState, HttpListener)
        ' Call EndGetContext to complete the asynchronous operation.
        Dim context As HttpListenerContext = listener.EndGetContext(result)
        Dim request As HttpListenerRequest = context.Request
        ' Obtain a response object.
        Dim response As HttpListenerResponse = context.Response
        ' Construct a response.
        Dim responseString As String = "<HTML><BODY> Hello world!</BODY></HTML>"
        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
        ' Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length
        Dim output As System.IO.Stream = response.OutputStream
        output.Write(buffer, 0, buffer.Length)
        ' You must close the output stream.
        output.Close()
    End Sub
    ' </Snippet13>

    ' <Snippet14>
    Public Shared Sub SimpleListenerWithUnsafeAuthentication(ByVal prefixes As String())
        ' URI prefixes are required,
        ' for example "http://contoso.com:8080/index/".
        If prefixes Is Nothing OrElse prefixes.Length = 0 Then Throw New ArgumentException("prefixes")
        ' Set up a listener.
        Dim listener As HttpListener = New HttpListener()

        For Each s As String In prefixes
            listener.Prefixes.Add(s)
        Next

        listener.Start()
        ' Specify Negotiate as the authentication scheme.
        listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate
        ' If NTLM Is used, we will allow multiple requests on the same
        ' connection to use the authentication information of first request.
        ' This improves performance but does reduce the security of your 
        ' application. 
        listener.UnsafeConnectionNtlmAuthentication = True
        ' This listener does Not want to receive exceptions 
        ' that occur when sending the response to the client.
        listener.IgnoreWriteExceptions = True
        Console.WriteLine("Listening...")
        ' ... process requests here.

        listener.Close()
    End Sub
    ' </Snippet14>

    ' <Snippet15>
    Public Shared Sub ShowRequestProperties1(ByVal request As HttpListenerRequest)
        ' Display the MIME types that can be used in the response.
        Dim types As String() = request.AcceptTypes

        If types IsNot Nothing Then
            Console.WriteLine("Acceptable MIME types:")

            For Each s As String In types
                Console.WriteLine(s)
            Next
        End If

        ' Display the language preferences for the response.
        types = request.UserLanguages

        If types IsNot Nothing Then
            Console.WriteLine("Acceptable natural languages:")

            For Each l As String In types
                Console.WriteLine(l)
            Next
        End If

        ' Display the URL used by the client.
        Console.WriteLine("URL: {0}", request.Url.OriginalString)
        Console.WriteLine("Raw URL: {0}", request.RawUrl)
        Console.WriteLine("Query: {0}", request.QueryString)

        ' Display the referring URI.
        Console.WriteLine("Referred by: {0}", request.UrlReferrer)

        ' Display the HTTP method.
        Console.WriteLine("HTTP Method: {0}", request.HttpMethod)

        ' Display the host information specified by the client.
        Console.WriteLine("Host name: {0}", request.UserHostName)
        Console.WriteLine("Host address: {0}", request.UserHostAddress)
        Console.WriteLine("User agent: {0}", request.UserAgent)
    End Sub
    ' </Snippet15>

    ' <Snippet16>
    Public Shared Sub ShowRequestData(ByVal request As HttpListenerRequest)
        If Not request.HasEntityBody Then
            Console.WriteLine("No client data was sent with the request.")
            Return
        End If

        Dim body As System.IO.Stream = request.InputStream
        Dim encoding As System.Text.Encoding = request.ContentEncoding
        Dim reader As System.IO.StreamReader = New System.IO.StreamReader(body, encoding)

        If request.ContentType IsNot Nothing Then
            Console.WriteLine("Client data content type {0}", request.ContentType)
        End If

        Console.WriteLine("Client data content length {0}", request.ContentLength64)
        Console.WriteLine("Start of client data:")
        ' Convert the data to a string and display it on the console.
        Dim s As String = reader.ReadToEnd()
        Console.WriteLine(s)
        Console.WriteLine("End of client data:")
        body.Close()
        reader.Close()
        ' If you are finished with the request, it should be closed also.
    End Sub
    ' </Snippet16>

    ' <Snippet17>
    Public Shared Sub ShowRequestProperties2(ByVal request As HttpListenerRequest)
        Console.WriteLine("KeepAlive: {0}", request.KeepAlive)
        Console.WriteLine("Local end point: {0}", request.LocalEndPoint.ToString())
        Console.WriteLine("Remote end point: {0}", request.RemoteEndPoint.ToString())
        Console.WriteLine("Is local? {0}", request.IsLocal)
        Console.WriteLine("HTTP method: {0}", request.HttpMethod)
        Console.WriteLine("Protocol version: {0}", request.ProtocolVersion)
        Console.WriteLine("Is authenticated: {0}", request.IsAuthenticated)
        Console.WriteLine("Is secure: {0}", request.IsSecureConnection)
    End Sub
    ' </Snippet17>

    ' <Snippet18>
    ' This example requires the System and System.Net namespaces.
    Public Shared Sub DisplayCookies(ByVal request As HttpListenerRequest)
        ' Print the properties of each cookie.
        For Each cook As Cookie In request.Cookies
            Console.WriteLine("Cookie:")
            Console.WriteLine("{0} = {1}", cook.Name, cook.Value)
            Console.WriteLine("Domain: {0}", cook.Domain)
            Console.WriteLine("Path: {0}", cook.Path)
            Console.WriteLine("Port: {0}", cook.Port)
            Console.WriteLine("Secure: {0}", cook.Secure)

            Console.WriteLine("When issued: {0}", cook.TimeStamp)
            Console.WriteLine("Expires: {0} (expired? {1})", cook.Expires, cook.Expired)
            Console.WriteLine("Don't save: {0}", cook.Discard)
            Console.WriteLine("Comment: {0}", cook.Comment)
            Console.WriteLine("Uri for comments: {0}", cook.CommentUri)
            Console.WriteLine("Version: RFC {0}", If(cook.Version = 1, "2109", "2965"))

            ' Show the string representation of the cookie.
            Console.WriteLine("String: {0}", cook.ToString())
        Next
    End Sub
    ' </Snippet18>

    ' <Snippet19>
    ' This example requires the System and System.Net namespaces.
    Public Shared Sub DisplayCookies(ByVal response As HttpListenerResponse)
        ' Print the properties of each cookie.
        For Each cook As Cookie In response.Cookies
            Console.WriteLine("Cookie:")
            Console.WriteLine("{0} = {1}", cook.Name, cook.Value)
            Console.WriteLine("Domain: {0}", cook.Domain)
            Console.WriteLine("Path: {0}", cook.Path)
            Console.WriteLine("Port: {0}", cook.Port)
            Console.WriteLine("Secure: {0}", cook.Secure)
            Console.WriteLine("When issued: {0}", cook.TimeStamp)
            Console.WriteLine("Expires: {0} (expired? {1})", cook.Expires, cook.Expired)
            Console.WriteLine("Don't save: {0}", cook.Discard)
            Console.WriteLine("Comment: {0}", cook.Comment)
            Console.WriteLine("Uri for comments: {0}", cook.CommentUri)
            Console.WriteLine("Version: RFC {0}", If(cook.Version = 1, "2109", "2965"))

            ' Show the string representation of the cookie.
            Console.WriteLine("String: {0}", cook.ToString())
        Next
    End Sub
    ' </Snippet19>

    ' <Snippet20>
    ' This example requires the System and System.Net namespaces.
    Public Shared Function NextCustomerID() As String
        ' A real-world application would do something more robust
        ' to ensure uniqueness.
        Return DateTime.Now.ToString()
    End Function

    Public Shared Sub SimpleListenerCookieExample(ByVal prefixes As String())
        ' Create a listener
        Dim listener As HttpListener = New HttpListener()

        ' Add the prefixes
        For Each s As String In prefixes
            listener.Prefixes.Add(s)
        Next

        listener.IgnoreWriteExceptions = True
        listener.Start()
        Console.WriteLine("Listening...")
        ' Note: The GetContext method blocks while waiting for a request. 
        Dim context As HttpListenerContext = listener.GetContext()
        Dim request As HttpListenerRequest = context.Request
        Dim customerID As String = Nothing

        ' Did the request come with a cookie?
        Dim cookie As Cookie = request.Cookies("ID")

        If cookie IsNot Nothing Then
            customerID = cookie.Value
        End If

        If customerID IsNot Nothing Then
            Console.WriteLine("Found the cookie!")
        End If

        ' Get the response object.
        Dim response As HttpListenerResponse = context.Response
        ' If they didn't provide a cookie containing their ID, give them one.
        If customerID Is Nothing Then
            customerID = NextCustomerID()
            Dim cook As Cookie = New Cookie("ID", customerID)
            response.AppendCookie(cook)
        End If
        ' Construct a response.
        Dim responseString As String = "<HTML><BODY> Hello " & customerID & "!</BODY></HTML>"
        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
        ' Get the response stream and write the response to it.
        response.ContentLength64 = buffer.Length
        Dim output As System.IO.Stream = response.OutputStream
        output.Write(buffer, 0, buffer.Length)
        ' You must close the output stream.
        output.Close()
        response.Close()
        listener.Stop()
    End Sub
    ' </Snippet20>

    ' <Snippet21>
    Public Shared Sub DisplayWebHeaderCollection(ByVal request As HttpListenerRequest)
        Dim headers As System.Collections.Specialized.NameValueCollection = request.Headers

        ' Get each header and display each value.
        For Each key As String In headers.AllKeys
            Dim values As String() = headers.GetValues(key)

            If values.Length > 0 Then
                Console.WriteLine("The values of the {0} header are: ", key)

                For Each value As String In values
                    Console.WriteLine("   {0}", value)
                Next
            Else
                Console.WriteLine("There is no value associated with the header.")
            End If
        Next
    End Sub
    ' </Snippet21>

    ' <Snippet22>
    Public Shared Sub ShowSendFormat(ByVal response As HttpListenerResponse)
    End Sub
    ' </Snippet22>

    ' <Snippet23>
    ' Displays the header information that accompanied a request.
    Public Shared Sub DisplayWebHeaderCollection(ByVal response As HttpListenerResponse)
        Dim headers As WebHeaderCollection = response.Headers

        ' Get each header and display each value.
        For Each key As String In headers.AllKeys
            Dim values As String() = headers.GetValues(key)

            If values.Length > 0 Then
                Console.WriteLine("The values of the {0} header are: ", key)

                For Each value As String In values
                    Console.WriteLine("   {0}", value)
                Next
            Else
                Console.WriteLine("There is no value associated with the header.")
            End If
        Next
    End Sub
    ' </Snippet23>

    ' <Snippet24>
    Public Shared Sub SimpleListenerExample2(ByVal prefixes As String())
        ' URI prefixes are required,
        ' for example "http://contoso.com:8080/index/".
        If prefixes Is Nothing Or prefixes.Length = 0 Then
            Throw New ArgumentException("prefixes")
        End If

        ' Create a listener
        Dim listener As HttpListener = New HttpListener()
        ' Add the prefixes
        For Each s As String In prefixes
            listener.Prefixes.Add(s)
        Next

        listener.Start()
        Console.WriteLine("Listening...")
        ' Note: The GetContext method blocks while waiting for a request. 
        Dim context As HttpListenerContext = listener.GetContext()
        Dim request As HttpListenerRequest = context.Request
        ' Obtain a response object.
        Dim response As HttpListenerResponse = context.Response
        ' Construct a response
        Dim responseString As String = "<HTML><BODY> Hello world!</BODY></HTML>"
        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
        ' Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length
        ' Demonstrate using the close overload that takes an 
        ' entity body.
        ' Specify true to block while data Is transmitted.
        response.Close(buffer, True)
        listener.Stop()
    End Sub
    ' </Snippet24>

    ' <Snippet25>
    Public Shared Sub TemporaryRedirect(ByVal request As HttpListenerRequest, ByVal response As HttpListenerResponse)
        If request.Url.OriginalString = "http://www.contoso.com/index.html" Then
            response.RedirectLocation = "http://www.contoso.com/indexServer/index.html"
        End If
    End Sub
    ' </Snippet25>

    ' <Snippet26>
    Public Shared Sub SetExpirationDate(ByVal seconds As Long, ByVal response As HttpListenerResponse)
        response.AddHeader("Expires", seconds.ToString())
    End Sub
    ' </Snippet26>

    ' <Snippet27>
    Public Shared Sub PermanentRedirect(ByVal request As HttpListenerRequest, ByVal response As HttpListenerResponse)
        If request.Url.OriginalString = "http://www.contoso.com/index.html" Then
            ' Sets the location header, status code and status description.
            response.Redirect("http://www.contoso.com/indexServer/index.html")
        End If
    End Sub
    ' </Snippet27>

    ' <Snippet28>
    ' This example requires the System and System.Net namespaces.
    Public Shared Sub SimpleCookieExample(ByVal prefixes As String())
        ' Create a listener
        Dim listener As HttpListener = New HttpListener()
        ' Add the prefixes
        For Each s As String In prefixes
            listener.Prefixes.Add(s)
        Next

        listener.Start()
        Console.WriteLine("Listening...")
        ' Note: The GetContext method blocks while waiting for a request.
        Dim context As HttpListenerContext = listener.GetContext()
        Dim request As HttpListenerRequest = context.Request

        ' This application sends a cookie to the client marking the time
        ' they visited.
        Dim timeStampCookie As Cookie = New Cookie("VisitDate", DateTime.Now.ToString())
        ' Obtain a response object.
        Dim response As HttpListenerResponse = context.Response
        ' Add the cookie to the response.
        response.SetCookie(timeStampCookie)
        ' Construct a response.
        Dim responseString As String = "<HTML><BODY> Hello world!</BODY></HTML>"
        response.ContentEncoding = System.Text.Encoding.UTF8
        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
        ' Send the response.
        response.Close(buffer, True)
        listener.Stop()
    End Sub
    ' </Snippet28>

    Public Shared Sub Main()
        Dim prefixes As String() = {"http://localhost:8080/"}

        ' run test code here

        Console.Read()
    End Sub

End Class
