' System.Runtime.Remoting.Lifetime.ILease
' System.Runtime.Remoting.Lifetime.ILease.InitialLeaseTime
' System.Runtime.Remoting.Lifetime.ILease.CurrentLeaseTime
' System.Runtime.Remoting.Lifetime.ILease.RenewOnCallTime
' System.Runtime.Remoting.Lifetime.ILease.SponsorshipTimeout
' System.Runtime.Remoting.Lifetime.ILease.CurrentState
' System.Runtime.Remoting.Lifetime.ILease.Register(ISponsor)
' System.Runtime.Remoting.Lifetime.ILease.Renew(TimeSpam)
' System.Runtime.Remoting.Lifetime.ILease.Unregister(ISponsor)
' System.Runtime.Remoting.Lifetime.ILease.Register(ISponsor,TimeSpam)
' The following example demonstrates 'InitialLeaseTime','CurrentLeaseTime',

' 'RenewOnCallTime','SponsorshipTimeout','CurrentState','Register','Renew',
' 'Unregister' and 'Register' methods of 'ClientSponsor' class.
'
' In the example using 'RemotingServices.GetLifetimeService' the lease information
' of the remote service is obtained. All the properties and methods 'ILease' are demonstrated
' using this lease variable. The client registers itself with 'ClientSponsor' class.
' After registeration the current lease time is displayed. The lease is expired
' and renewed. Then the renewed lease time is displayed. Finally the client unregister itself.
' The client a again registers itself. This time with initial lease time mentioned at
' the time of registeration. The lease time is displayed.
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
' <Snippet3>
         ' Register the channel.
         Dim myChannel As New TcpChannel()
         ChannelServices.RegisterChannel(myChannel)
         RemotingConfiguration.RegisterActivatedClientType( _
                           GetType(HelloService), "Tcp://localhost:8085")

         Dim myTimeSpan As TimeSpan = TimeSpan.FromMinutes(10)

         ' Create a remote object.
         Dim myService As New HelloService()

         Dim myLease As ILease
         myLease = CType(RemotingServices.GetLifetimeService(myService), ILease)
         If myLease Is Nothing Then
            Console.WriteLine("Cannot lease.")
            Return
         End If

         Console.WriteLine("Initial lease time is " & myLease.InitialLeaseTime.ToString())
         Console.WriteLine("Current lease time is " & myLease.CurrentLeaseTime.ToString())
         Console.WriteLine("Renew on call time is " & myLease.RenewOnCallTime.ToString())
         Console.WriteLine("Sponsorship timeout is " & myLease.SponsorshipTimeout.ToString())
         Console.WriteLine("Current lease state is " & myLease.CurrentState.ToString())
' </Snippet3>
         ' Register with a sponser.
         Dim mySponsor As New ClientSponsor()
         myLease.Register(mySponsor)
         Console.WriteLine("Wait for lease to expire (approx. 15 seconds)...")
         System.Threading.Thread.Sleep(myLease.CurrentLeaseTime)
         Console.WriteLine("Current lease time before renewal is " & _
                        myLease.CurrentLeaseTime.ToString())

         ' Renew the lease time.
         myLease.Renew(myTimeSpan)
         Console.WriteLine("Current lease time after renewal is " + _
                        myLease.CurrentLeaseTime.ToString())

         ' Call the Remote method.
         Console.WriteLine("Remote method output is " + myService.HelloMethod("Microsoft"))

         myLease.Unregister(mySponsor)
         GC.Collect()
         GC.WaitForPendingFinalizers()

         ' Register with lease time of 15 minutes.
         myLease.Register(mySponsor, TimeSpan.FromMinutes(15))
         Console.WriteLine("Registered client with lease time of 15 minutes.")
         Console.WriteLine("Current lease time is " + myLease.CurrentLeaseTime.ToString())

         ' Call the Remote method.
         Console.WriteLine("Remote method output is " + myService.HelloMethod("Microsoft"))
         myLease.Unregister(mySponsor)
      End Sub 'Main
   End Class 'HelloClient
' </Snippet2>

End Namespace 'RemotingSamples
' </Snippet1>