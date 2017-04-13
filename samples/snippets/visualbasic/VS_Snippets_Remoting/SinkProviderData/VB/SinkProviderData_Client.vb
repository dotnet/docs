' The following program is the supporting program for demonstration of
' 'System.Runtime.Remoting.Channels.SinkProviderData' class and its 
' properties 'Children', 'Name', 'Properties'.

Imports System
Imports System.Runtime.Remoting

Public Class SinkProviderData_Client

   Public Shared Sub Main()
      RemotingConfiguration.Configure("channels.config")
      RemotingConfiguration.Configure("client.exe.config")
      Dim server As New mySharedStringClass()
      Console.WriteLine(server.PrintString("Welcome to .NET!."))
   End Sub 'Main
End Class 'SinkProviderData_Client