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