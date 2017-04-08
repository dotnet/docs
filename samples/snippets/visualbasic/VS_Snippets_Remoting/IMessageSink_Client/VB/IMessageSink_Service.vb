Imports System
Imports System.IO
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports Share


Public Class MyServiceClass

   Public Shared Sub Main()
      Dim myHttpChannel As New HttpChannel(8082)
      ChannelServices.RegisterChannel(myHttpChannel)
      RemotingConfiguration.RegisterActivatedServiceType(GetType(MyHelloService))
      Console.WriteLine("Press Enter to Exit the Server")
      Console.ReadLine()
   End Sub 'Main
End Class 'MyServiceClass