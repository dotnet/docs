' System.Runtime.Remoting.Channels.SoapClientFormatterSinkProvider
' System.Runtime.Remoting.Channels.SoapClientFormatterSinkProvider.Next

' The following program demonstrates the 'SoapClientFormatterSinkProvider' class
' and 'Next' property of 'SoapClientFormatterSinkProvider' class ,'CreateSink'
' method and 'Next' property of 'ServerFormatterSinkProvider' class.
' Custom client and server formatter provider are created by implementing
' the interfaces IClientChannelSinkProvider and IServerChannelSinkProvider.
' In the client side the custom client provider is assigned to 'Next' property
' of 'SoapClientFormatterSinkProvider'.In the server side, the
' 'BinaryServerFormatterSinkProvider' is assigned to 'Next' property
' of 'SoapServerFormatterSinkProvider'.

' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels
Imports System.Security.Permissions

Public Class ClientClass
    <SecurityPermission(SecurityAction.Demand)> _
    Public Shared Sub Main()
        Try
            ' <Snippet2>
            Dim mySoapProvider = New SoapClientFormatterSinkProvider()
            Dim myClientProvider = New MyClientProvider()
            ' Set the custom provider as the next 'IClientChannelSinkProvider' in the
            ' sink chain.
            mySoapProvider.Next = myClientProvider
            ' </Snippet2>
            Dim myTcpChannel As New TcpChannel(Nothing, mySoapProvider, Nothing)

            ChannelServices.RegisterChannel(myTcpChannel)

            RemotingConfiguration.RegisterWellKnownClientType(GetType(HelloService), _
                                 "tcp://localhost:8082/HelloServiceApplication/MyUri")

            Dim myService As New HelloService()

            Console.WriteLine(myService.HelloMethod("Welcome to .Net"))
        Catch ex As Exception
            Console.WriteLine("The following  exception is raised at client side :" + ex.Message)
        End Try
    End Sub 'Main
End Class 'ClientClass
' </Snippet1>