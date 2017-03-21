        static void Main(string[] args)
        {
            // Create service host.
            WorkflowServiceHost host = new WorkflowServiceHost(new CountingWorkflow(), new Uri(hostBaseAddress));

            // Add service endpoint.
            host.AddServiceEndpoint("ICountingWorkflow", new BasicHttpBinding(), "");

            // Define SqlWorkflowInstanceStoreBehavior:
            //   Set interval to renew instance lock to 5 seconds.
            //   Set interval to check for runnable instances to 2 seconds.
            //   Instance Store does not keep instances after it is completed.
            //   Select exponential back-off algorithm when retrying to load a locked instance.
            //   Instance state information is compressed using the GZip compressing algorithm. 
            SqlWorkflowInstanceStoreBehavior instanceStoreBehavior = new SqlWorkflowInstanceStoreBehavior(connectionString);
            instanceStoreBehavior.HostLockRenewalPeriod = new TimeSpan(0, 0, 5);
            instanceStoreBehavior.RunnableInstancesDetectionPeriod = new TimeSpan(0, 0, 2);
            instanceStoreBehavior.InstanceCompletionAction = InstanceCompletionAction.DeleteAll;
            instanceStoreBehavior.InstanceLockedExceptionAction = InstanceLockedExceptionAction.AggressiveRetry;
            instanceStoreBehavior.InstanceEncodingOption = InstanceEncodingOption.GZip;
            host.Description.Behaviors.Add(instanceStoreBehavior);

            // Open service host.
            host.Open();

            // Create a client that sends a message to create an instance of the workflow.
            ICountingWorkflow client = ChannelFactory<ICountingWorkflow>.CreateChannel(new BasicHttpBinding(), new EndpointAddress(hostBaseAddress));
            client.start();

            Console.WriteLine("(Press [Enter] at any time to terminate host)");
            Console.ReadLine();
            host.Close();
        }