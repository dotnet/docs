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