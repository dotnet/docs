' <Snippet2>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions


Public Class Server
   
   Public Shared Sub Main()
      Dim myServer As New Server()
      myServer.Run()
   End Sub 'Main

<SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.Infrastructure)> _ 
   Public Sub Run()
      LifetimeServices.LeaseTime = TimeSpan.FromSeconds(5)
      LifetimeServices.LeaseManagerPollTime = TimeSpan.FromSeconds(3)
      LifetimeServices.RenewOnCallTime = TimeSpan.FromSeconds(2)
      LifetimeServices.SponsorshipTimeout = TimeSpan.FromSeconds(1)
      
      
      ChannelServices.RegisterChannel(New HttpChannel(8080), True)
      RemotingConfiguration.RegisterActivatedServiceType(GetType(ClientActivatedType))
      
      Console.WriteLine("The server is listening. Press Enter to exit....")
      Console.ReadLine()
      
      Console.WriteLine("GC'ing.")
      GC.Collect()
      GC.WaitForPendingFinalizers()
   End Sub 'Run
   
End Class 'Server
' </Snippet2>
