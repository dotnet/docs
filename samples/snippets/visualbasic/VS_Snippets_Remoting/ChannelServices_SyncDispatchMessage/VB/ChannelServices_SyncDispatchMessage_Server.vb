' The example demonstrates the remoting version of a server. When a client
' calls the 'MyPrintMethod' on the 'PrintServer' class, the server object 
' prints the parameters passed from the client and returns the last 
' parameter back to the client. 

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class Sample
   Overloads Public Shared Sub Main()
      Dim myTcpChannel As New TcpChannel(8085)
      ChannelServices.RegisterChannel(myTcpChannel)
      RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("PrintServer, " + _
            "ChannelServices_SyncDispatchMessage_Share"), "SayHello", WellKnownObjectMode.SingleCall)
      Console.WriteLine("Hit <enter> to exit...")
      Console.ReadLine()
   End Sub 'Main
End Class 'Sample
