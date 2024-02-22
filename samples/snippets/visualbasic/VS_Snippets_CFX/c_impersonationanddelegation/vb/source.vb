Imports System.ServiceModel.Description
Imports System.ServiceModel.Security
Imports System.ServiceModel
Imports System.Security.Principal
Imports System.Security.Permissions

Namespace SnippetsPart1

    Interface IHelloService
        Function Hello(ByVal message As String) As String
    End Interface


    Friend Class Test

        Shared Sub Main()

        End Sub
    End Class

    '<snippet1>
    <ServiceContract()> _
    Public Interface IHelloContract
        <OperationContract()> _
        Function Hello(ByVal message As String) As String
    End Interface


    Public Class HelloService
        Implements IHelloService

        <OperationBehavior(Impersonation:=ImpersonationOption.Required)> _
        Public Function Hello(ByVal message As String) As String Implements IHelloService.Hello
            Return "hello"
        End Function
    End Class
    '</snippet1>
End Namespace

Namespace SnippetsPart2

    Interface IHelloService
        Function Hello(ByVal message As String) As String
    End Interface

    '<snippet2>
    Public Class HelloService
        Implements IHelloService

        <OperationBehavior()> _
        Public Function Hello(ByVal message As String) As String _
           Implements IHelloService.Hello
            Dim callerWindowsIdentity As WindowsIdentity = _
                ServiceSecurityContext.Current.WindowsIdentity
            If (callerWindowsIdentity Is Nothing) Then
                Throw New InvalidOperationException( _
                  "The caller cannot be mapped to a WindowsIdentity")
            End If
            Dim cxt As WindowsImpersonationContext = callerWindowsIdentity.Impersonate()
            Using (cxt)
                ' Access a file as the caller.
            End Using

            Return "Hello"

        End Function
    End Class
    '</snippet2>

    Interface IEcho
        Sub SayHello()
    End Interface


    Friend Class MoreSnippets

        Private Sub ServiceAuthorizationBehaviorStuff()
            Dim myUri As New Uri("hello")
            Dim addresses() As Uri = {myUri}
            Dim c As Type = GetType(HelloService)
            Dim serviceHost As New ServiceHost(c, addresses)

            '<snippet3>
            ' Code to create a ServiceHost not shown.
            Dim MyServiceAuthorizationBehavior As ServiceAuthorizationBehavior
            MyServiceAuthorizationBehavior = serviceHost.Description.Behaviors.Find _
            (Of ServiceAuthorizationBehavior)()
            MyServiceAuthorizationBehavior.ImpersonateCallerForAllOperations = True
            '</snippet3>

            '<snippet4>
            Dim cf As ChannelFactory(Of IEcho) = New ChannelFactory(Of IEcho)("EchoEndpoint")
            cf.Credentials.Windows.AllowedImpersonationLevel = _
            System.Security.Principal.TokenImpersonationLevel.Impersonation
            '</snippet4>

        End Sub


        Private Sub BuildStuff()
            '<snippet5>
            Dim cf As ChannelFactory(Of IEcho) = new ChannelFactory(Of IEcho)("EchoEndpoint")
            cf.Credentials.Windows.AllowedImpersonationLevel = _
                 System.Security.Principal.TokenImpersonationLevel.Impersonation
            '</snippet5>
        End Sub
    End Class
End Namespace
