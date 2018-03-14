' This file is a support file for demonstrating IClientChannelSinkProvider 
' and ServerProcessing. 

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Security.Permissions
Imports System.Collections
Imports MyLogging

Public Class MyServerClass
   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      Dim prop = New Hashtable()
      prop.Add("port", 8082)
      
      Dim myServerFormatterProvider = New SoapServerFormatterSinkProvider()
      Dim myServerLoggingProvider = New MyServerProcessingLogServerChannelSinkProviderData()
      myServerLoggingProvider.Next = myServerFormatterProvider
      
      Dim myClientFormatterProvider = New SoapClientFormatterSinkProvider()
      Dim myClientLoggingProvider = New MyServerProcessingLogClientChannelSinkProviderData()
      myClientLoggingProvider.Next = myClientFormatterProvider
      
      Dim channel As New TcpChannel(prop, myClientLoggingProvider, myServerLoggingProvider)
      
      ChannelServices.RegisterChannel(channel)
      
      RemotingConfiguration.ApplicationName = "HelloServiceApplication"
      
      RemotingConfiguration.RegisterWellKnownServiceType(GetType(MyHelloService), "MyUri", _
                   WellKnownObjectMode.SingleCall)
      Console.WriteLine("Press enter to stop this process.")
      Console.ReadLine()
   End Sub 'Main
End Class 'MyServerClass