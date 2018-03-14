' <Snippet4>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Lifetime

Namespace RemotingSamples
   Class HelloServer

      Shared Sub Main()
         Dim myChannel As New TcpChannel(8085)
         ChannelServices.RegisterChannel(myChannel)
         RemotingConfiguration.RegisterActivatedServiceType(GetType(HelloService))
         Console.WriteLine("Server started.")
         Console.WriteLine("Hit enter to terminate...")
         Console.Read()
      End Sub 'Main
   End Class 'HelloServer
End Namespace 'RemotingSamples
' </Snippet4>
