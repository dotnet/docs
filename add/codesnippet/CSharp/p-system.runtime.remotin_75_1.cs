         // Register the channel.
         TcpChannel myChannel = new TcpChannel ();
         ChannelServices.RegisterChannel(myChannel);
         RemotingConfiguration.RegisterActivatedClientType(
                                typeof(HelloService),"Tcp://localhost:8085");

         TimeSpan myTimeSpan = TimeSpan.FromMinutes(10);

         // Create a remote object.
         HelloService myService = new HelloService();

         ILease myLease;
         myLease = (ILease)RemotingServices.GetLifetimeService(myService);
         if (myLease == null)
         {
            Console.WriteLine("Cannot lease.");
            return;
         }

         Console.WriteLine ("Initial lease time is " + myLease.InitialLeaseTime);
         Console.WriteLine ("Current lease time is " + myLease.CurrentLeaseTime);
         Console.WriteLine ("Renew on call time is " + myLease.RenewOnCallTime);
         Console.WriteLine ("Sponsorship timeout is " + myLease.SponsorshipTimeout);
         Console.WriteLine ("Current lease state is " + myLease.CurrentState.ToString());