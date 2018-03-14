' System.Runtime.Remoting.Channels.SoapServerFormatterSinkProvider.Next;

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
' <Snippet4>
         Dim myCustomProvider = New MyServerProvider()
         Dim mySoapProvider = New SoapServerFormatterSinkProvider()
         myCustomProvider.Next = mySoapProvider
         ' Set the Binary provider as the next 'IServerChannelSinkProvider' in the
         ' sink chain.
         mySoapProvider.Next = New BinaryServerFormatterSinkProvider()
' </Snippet4>
         Dim myTcpChannel As New TcpChannel(myDictionaryProperty, Nothing, myCustomProvider)

         ChannelServices.RegisterChannel(myTcpChannel)

         RemotingConfiguration.ApplicationName = "HelloServiceApplication"

         RemotingConfiguration.RegisterWellKnownServiceType(GetType(HelloService), "MyUri", _
                                                            WellKnownObjectMode.Singleton)
         Console.WriteLine("Press enter to stop this process.")
         Console.ReadLine()
      Catch ex As Exception
         Console.WriteLine("The following exception is raised at server side: " + ex.Message)
      End Try
   End Sub 'Main
End Class 'ServerClass