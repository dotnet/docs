Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class Sample
   
   Public Shared Sub Main()
      ChannelServices.RegisterChannel(New TcpChannel(8085))
      RemotingConfiguration.RegisterWellKnownServiceType(GetType(MyServerImpl), "SayHello", _ 
                                                   WellKnownObjectMode.Singleton)
      Console.WriteLine("Press <enter> to exit...")
      Console.ReadLine()
   End Sub 'Main
End Class 'Sample
