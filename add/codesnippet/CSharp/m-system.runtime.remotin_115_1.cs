         // Register the channel.
         TcpChannel myChannel = new TcpChannel ();
         ChannelServices.RegisterChannel(myChannel);
         RemotingConfiguration.RegisterActivatedClientType(typeof(HelloService),"Tcp://localhost:8082");


         GenericIdentity myIdentity = new GenericIdentity("Bob");
         GenericPrincipal myPrincipal = new GenericPrincipal(myIdentity,new string[] {"Level1"});
         MyLogicalCallContextData myData = new MyLogicalCallContextData(myPrincipal);

         // Set DataSlot with name parameter.
         CallContext.SetData("test data",myData);

         // Create a remote object.
         HelloService myService = new HelloService();
         if (myService == null)
         {
            Console.WriteLine("Cannot locate server.");
            return;
         }

         // Call the Remote methods.
         Console.WriteLine("Remote method output is " + myService.HelloMethod("Microsoft"));

         MyLogicalCallContextData myReturnData =
                                    (MyLogicalCallContextData) CallContext.GetData("test data");
         if (myReturnData == null )
            Console.WriteLine("Data is null.");
         else
            Console.WriteLine("Data is '{0}'", myReturnData.numOfAccesses);

         // DataSlot with same Name Parameter which was Set is Freed.
         CallContext.FreeNamedDataSlot("test data");
         MyLogicalCallContextData myReturnData1 =
                                 (MyLogicalCallContextData) CallContext.GetData("test data");
         if (myReturnData1 == null )
            Console.WriteLine("FreeNamedDataSlot Successful for test data");
         else
            Console.WriteLine("FreeNamedDataSlot Failed  for test data");