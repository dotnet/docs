' The following program is the supporting program for demonstration of
' 'System.Runtime.Remoting.Channels.SinkProviderData' class and its 
' properties 'Children', 'Name', 'Properties'.

Imports System
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Security.Permissions
Imports System.Threading
Imports IPFilter

Public Class Server
<SecurityPermission(SecurityAction.Demand)> _
   Public Shared Sub Main()
      RemotingConfiguration.Configure("channels.config")
      RemotingConfiguration.Configure("server.exe.config")
      Console.WriteLine("Server Listening...")
      ' Obtain filter interface.
      Dim myIDictionary As IDictionary = CType(ChannelServices.GetChannel("MyHttpChannel"), _
                                                            HttpServerChannel).Properties
      Dim keyState As String = ""
      While String.Compare(keyState, "0", True) <> 0
         Console.WriteLine("***** Press 0 to exit this service *****")
         keyState = Console.ReadLine()
      End While
   End Sub 'Main
End Class 'Server