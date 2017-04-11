' This is supporting program for the 'SoapClientFormatterSinkProvider_CreateSink_Client'.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Collections

Public Class ServerClass
   Public Shared Sub Main()
      Try
         Dim myDictionaryProperty = New Hashtable()
         myDictionaryProperty.Add("port", 8082)
         Dim mySoapProvider = New SoapServerFormatterSinkProvider()
         Dim myTcpChannel As New TcpChannel(myDictionaryProperty, Nothing, mySoapProvider)
         ChannelServices.RegisterChannel(myTcpChannel)
         RemotingConfiguration.ApplicationName = "HelloServiceApplication"
         RemotingConfiguration.RegisterWellKnownServiceType(GetType(HelloService), _
                                          "MyUri", WellKnownObjectMode.Singleton)
         Console.WriteLine("Press enter to stop this process.")
         Console.ReadLine()
      Catch ex As Exception
         Console.WriteLine("The following exception is raised at server side" + ex.Message)
      End Try
   End Sub 'Main
End Class 'ServerClass