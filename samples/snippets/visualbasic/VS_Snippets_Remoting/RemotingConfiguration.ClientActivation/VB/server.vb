' <Snippet2>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp


Public Class ServerClass
      
   Public Shared Sub Main()
      
      ChannelServices.RegisterChannel(New TcpChannel(8082))     
      RemotingConfiguration.RegisterActivatedServiceType(GetType(HelloServiceClass))
      
      Console.WriteLine("Press enter to stop this process.")
      Console.ReadLine()

   End Sub 'Main

End Class 'ServerClass
' </Snippet2>