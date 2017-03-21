                ServiceEndpoint endpoint;
                endpoint = serviceHost.AddServiceEndpoint(typeof(IQueueCalculator), new NetMsmqBinding(),"net.msmq://localhost/private/ServiceModelSamples");
                TransactedBatchingBehavior batchBehavior = new TransactedBatchingBehavior(10);
                batchBehavior.MaxBatchSize = 100;
                endpoint.Behaviors.Add(new TransactedBatchingBehavior(10));