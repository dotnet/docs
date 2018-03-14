' System.Runtime.Remoting.Lifetime.ClientSponsor.Register(MarshalByRefObject)
' System.Runtime.Remoting.Lifetime.ClientSponsor.Unregister(MarshalByRefObject)
' System.Runtime.Remoting.Lifetime.ClientSponsor.RenewalTime
' System.Runtime.Remoting.Lifetime.ClientSponsor.InitializeLifetimeService()
' System.Runtime.Remoting.Lifetime.ClientSponsor.Renewal(ILease)
' System.Runtime.Remoting.Lifetime.ClientSponsor.Close()
' System.Runtime.Remoting.Lifetime.ClientSponsor

' The following example demonstrates 'RenewalTime', 'Register', 'UnRegister' and
' 'Close' methods of 'ClientSponsor' class.
' A remote object is created and registered with 'ClientSponsor' class. The renewal
' time is set. Then the leased time is renewed and the method of remote object is invoked.
' Finally the remote object is unregistered.
'

' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Lifetime

Namespace RemotingSamples

' <Snippet2>
   Class HelloClient

      Shared Sub Main()
         ' Register a channel.
         Dim myChannel As New TcpChannel()
         ChannelServices.RegisterChannel(myChannel)
         RemotingConfiguration.RegisterActivatedClientType( _
                     GetType(HelloService), "tcp://localhost:8085")

         ' Get the remote object.
         Dim myService As New HelloService()

         ' Get a sponsor for renewal of time.
         Dim mySponsor As New ClientSponsor()

         ' Register the service with sponsor.
         mySponsor.Register(myService)

         ' Set renewaltime.
         mySponsor.RenewalTime = TimeSpan.FromMinutes(2)

         ' Renew the lease.
         Dim myLease As ILease = CType(mySponsor.InitializeLifetimeService(), ILease)
         Dim myTime As TimeSpan = mySponsor.Renewal(myLease)
         Console.WriteLine("Renewed time in minutes is " & myTime.Minutes)

         ' Call the remote method.
         Console.WriteLine(myService.HelloMethod("World"))

         ' Unregister the channel.
         mySponsor.Unregister(myService)
         mySponsor.Close()
      End Sub 'Main
   End Class 'HelloClient
' </Snippet2>


End Namespace 'RemotingSamples
' </Snippet1>