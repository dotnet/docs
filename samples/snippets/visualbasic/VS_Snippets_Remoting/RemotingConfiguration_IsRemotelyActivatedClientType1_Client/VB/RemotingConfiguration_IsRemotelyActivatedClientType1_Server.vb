Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class ServerClass
   
   Shared Sub Main()
      ChannelServices.RegisterChannel(New TcpChannel(8085))
      RemotingConfiguration.RegisterActivatedServiceType(GetType(MyServerImpl))
      Console.WriteLine("Press enter to stop this process.")
      Console.ReadLine()
   End Sub 'Main
End Class 'ServerClass