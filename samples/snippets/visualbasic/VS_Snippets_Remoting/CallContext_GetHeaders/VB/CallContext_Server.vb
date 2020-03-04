
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Namespace RemotingSamples
    Class HelloServer
      Shared Sub Main()
         Dim myChannel As New TcpChannel(8082)
         ChannelServices.RegisterChannel(myChannel)
         RemotingConfiguration.RegisterActivatedServiceType(GetType(HelloService))
         Console.WriteLine("Server started.")
         Console.WriteLine("Hit enter to terminate...")
         Console.Read()
      End Sub
   End Class
End Namespace 'RemotingSamples