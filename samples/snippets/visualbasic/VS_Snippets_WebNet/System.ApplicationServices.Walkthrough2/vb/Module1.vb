'C:\_r8_08\code\WcfApplicationServices (4)\AppSvcClient\Module1.vb
'C:\_r8_08\code\_SD\WcfApplicationServices\VB\WcfApplicationServices
' orig C:\_bck\9-11bak\rWebs\winSetUp\z\VB\WcfApplicationServices\AppSvcClient\Module1.vb
#Const BigMain = True
#If (BigMain) Then
'<snippet999>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Channels
Imports System.ComponentModel
Imports System.Web
Imports System.Net

'Imports System.Web.ApplicationServices

Module Module1

    Class MyServiceTst

        Dim _host As String

        Public Property Host() As String
            Get
                Return _host
            End Get
            Set(ByVal value As String)
                _host = value
            End Set
        End Property

        Function GetCookies(ByVal oc As OperationContext) As CookieContainer
            Dim httpResponseProperty As HttpResponseMessageProperty = DirectCast(oc.IncomingMessageProperties(HttpResponseMessageProperty.Name), HttpResponseMessageProperty)
            If (httpResponseProperty.Equals(Nothing) = False) Then
                Dim cookieContainer As New CookieContainer()
                Dim header As String = httpResponseProperty.Headers(HttpResponseHeader.SetCookie)

                If header <> Nothing Then
                    cookieContainer.SetCookies(New Uri("http://someuri.tld"), header)
                End If
                Return cookieContainer
            End If
            Return Nothing
        End Function

        Sub SetCookies(ByVal oc As OperationContext, ByVal cookieContainer As CookieContainer)
            Dim httpRequestProperty = New HttpRequestMessageProperty()
            httpRequestProperty = Nothing
            If oc.OutgoingMessageProperties.ContainsKey(HttpRequestMessageProperty.Name) Then
                httpRequestProperty = TryCast(oc.OutgoingMessageProperties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)
            End If
            If httpRequestProperty Is Nothing Then
                httpRequestProperty = New HttpRequestMessageProperty()
                oc.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, httpRequestProperty)
            End If
            httpRequestProperty.Headers.Add(HttpRequestHeader.Cookie, cookieContainer.GetCookieHeader(New Uri("http://someuri.tld")))
        End Sub

        Sub GetUserRoles(ByVal cookieContainer As CookieContainer)

            Dim endPtAddr As String = strEndPtAddr("MyRoleSvcWrap")
            Dim roleSvc As New RoleServiceClient(New BasicHttpBinding(), New EndpointAddress(endPtAddr))

            Using New OperationContextScope(DirectCast(roleSvc.InnerChannel, IContextChannel))
                SetCookies(OperationContext.Current, cookieContainer)
                Dim roles As String() = roleSvc.GetRolesForCurrentUser()
                If roles.Length = 0 Then
                    Console.WriteLine("User does not belong to any role.")
                Else
                    Dim userRoles As String = ""
                    Dim i As Integer = 0
                    While i < roles.Length
                        userRoles &= roles(i) & " "
                        Global.System.Math.Max(Global.System.Threading.Interlocked.Increment(i), i - 1)
                    End While
                    Console.WriteLine("User's roles: " & userRoles)

                End If
            End Using
        End Sub

        Sub GetProfileInfo(ByVal cookieContainer As CookieContainer)

            Dim endPtAddr As String = strEndPtAddr("MyProfileSvcWrap")
            Dim profileSvc As New ProfileServiceClient(New BasicHttpBinding(), New EndpointAddress(endPtAddr))

            Using New OperationContextScope(DirectCast(profileSvc.InnerChannel, IContextChannel))
                SetCookies(OperationContext.Current, cookieContainer)
                Dim profileData As Dictionary(Of String, Object) = _
                profileSvc.GetPropertiesForCurrentUser(New String() _
                   {"FirstName", "LastName", "PhoneNumber"}, True)

                Console.WriteLine("FirstName: " & profileData("FirstName"))
                Console.WriteLine("LastName: " & profileData("LastName"))
                Console.WriteLine("PhoneNumber: " & profileData("PhoneNumber"))
            End Using
        End Sub

        Public Function strEndPtAddr(ByVal service As String) As String
            Dim endPtAddr As String = "http://" & Host & "/WcfApplicationServices/" & service & ".svc?wsdl"

            Return endPtAddr
        End Function

        Sub Init(ByVal args As String())

            If (args.Length = 3) Then 
                ' The host address was passed in, so that is used.
                Host = args(2)
            Else
                Host = "localhost:8080"
            End If

            Dim username As String = args(0)
            Dim password As String = args(1)
            Dim result As Boolean
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            Dim endPtAddr As String = strEndPtAddr("MyAuthenticationSvcWrap")

            Console.WriteLine("Attempting to connect as username = " & username & vbNewLine _
              & "password length = " & password.Length.ToString() & vbNewLine _
              & " on server " & Host & vbNewLine _
              &  vbNewLine & "End point address: " & endPtAddr _
              )

            ' BasicHttpBinding and endpoint are explicitly passed and ignored
            ' in the app.config file.
            Dim authService As AuthenticationServiceClient = New AuthenticationServiceClient(binding, _
                                                  New EndpointAddress(endPtAddr))

            Dim cookieContainer As CookieContainer = Nothing
            Dim customCredential As String = "Not used by the default membership provider."

            ' Authentication ticket remains valid across sessions.
            Dim isPersistent As Boolean = True   

            Using New OperationContextScope(authService.InnerChannel)
                Try
                    result = authService.Login(username, password, customCredential, isPersistent)
                    cookieContainer = GetCookies(OperationContext.Current)
                Catch enf As EndpointNotFoundException
                    Console.WriteLine(enf.Message)
                    Return
                End Try
            End Using

            If result Then
                Console.WriteLine("Welcome, " & username & ". You are logged in.")
                GetUserRoles(cookieContainer)

                GetProfileInfo(cookieContainer)
            Else
                Console.WriteLine("Credentials could not be validated.")
            End If


        End Sub
    End Class



    Sub Main(ByVal args As String())

        If (args.Length < 1) Then
            Console.WriteLine("Missing command-line arguments: username password [host]")
            Return
        End If

        Dim mst As MyServiceTst = New MyServiceTst()
        mst.Init(args)


        Console.WriteLine("Press any key to quit.")
        Console.Read()

    End Sub

End Module
'</snippet999>
#End If

#If (BigMain = False) Then

'<snippet99>
Imports System.ServiceModel

Module Module1

    Sub Main(ByVal args As String())


        Dim username As String = "joeM"
        Dim password As String = "*(IU89iu"
        Dim result As Boolean = False
        Dim customCredential As String = "Not used by the default membership provider."
        Dim isPersistent As Boolean = True ' authentication ticket remains valid across sessions.

        'BasicHttpBinding and endpoint are provided in app.config file.
        Dim authService As New AuthenticationServiceClient()

        result = authService.Login(username, password, customCredential, isPersistent)

        If result Then
            Console.WriteLine("Welcome, " & username & ". You are logged in.")
        Else
            Console.WriteLine("We could not validate your credentials.")
        End If

        Console.WriteLine("Press any key to quit.")
        Console.Read()

    End Sub

End Module
'</snippet99>
#End If