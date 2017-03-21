            IWorkflowCreation creationClient = new ChannelFactory<IWorkflowCreation>(new BasicHttpBinding(), "http://localhost/DataflowControl.xaml/Creation").CreateChannel();
            Guid instanceId = creationClient.CreateSuspended(null);
            WorkflowControlClient controlClient = new WorkflowControlClient(
                new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost/DataflowControl.xaml")));

            controlClient.Unsuspend(instanceId);
            
            // ...

            controlClient.Terminate(instanceId);