 ' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp


Public Class ServerClass
   
   Public Shared Sub Main()

      ' </Snippet1>
      ' <Snippet2>
      ChannelServices.RegisterChannel(New TcpChannel(8082))
      
      RemotingConfiguration.ApplicationName = "HelloServiceApplication"
      
      RemotingConfiguration.RegisterWellKnownServiceType(GetType(HelloService), "MyUri", WellKnownObjectMode.SingleCall)
      ' </Snippet2>
      ' <Snippet3>

      Console.WriteLine("Press enter to stop this process.")
      Console.ReadLine()

   End Sub 'Main

End Class 'ServerClass
' </Snippet3>