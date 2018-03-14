' System.Runtime.Remoting.Channels.SoapClientFormatterSinkProvider.CreateSink
' System.Runtime.Remoting.Channels.BaseChannelSinkWithProperties

' The following example demonstrates the 'BaseChannelSinkWithProperties'
' class and 'CreateSink' method of 'SoapClientFormatterSinkProvider' class.
' Custom client formatter provider is defined by implementing
' the 'IClientChannelSinkProvider' interface and custom channel sink is
' defined by inheriting 'BaseChannelSinkWithProperties' abstract class.
' The sink provider chain has the custom sink provider and 
' 'SoapClientFormatterSinkProvider'. The 'CreateSink' method is used to 
' return a sink to the caller and form the sink chain which is used to process
' the message being passed through it.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels

Public Class ClientClass
   Public Shared Sub Main()
      Try
         Dim myFormatterProvider = New MyClientFormatterProvider()
         myFormatterProvider.Next = New SoapClientFormatterSinkProvider()
         Dim myTcpChannel As New TcpChannel(Nothing, myFormatterProvider, Nothing)
         ChannelServices.RegisterChannel(myTcpChannel)
         RemotingConfiguration.RegisterWellKnownClientType(GetType(HelloService), _
                           "tcp://localhost:8082/HelloServiceApplication/MyUri")
         Dim myService As New HelloService()
         Console.WriteLine(myService.HelloMethod("Welcome to .Net"))
      Catch ex As Exception
         Console.WriteLine("The following exception is raised at client side" + ex.Message)
      End Try
   End Sub 'Main
End Class 'ClientClass
