Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Namespace RemotingSamples
    
   Public Class Sample
      
      Public Shared Sub Main()
         Dim chan As New TcpChannel(8085)
         ChannelServices.RegisterChannel(chan)
         RemotingConfiguration.RegisterWellKnownServiceType(GetType(MyServerImpl), "SayHello", _ 
                                                             WellKnownObjectMode.Singleton)
         Console.WriteLine("Press <enter> to exit...")
         Console.ReadLine()
      End Sub 'Main
   End Class 'Sample
End Namespace 'RemotingSamples
