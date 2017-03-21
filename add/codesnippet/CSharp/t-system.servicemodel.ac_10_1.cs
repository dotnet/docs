            Variable<string> message = new Variable<string>("message", "client");
            Variable<string> result = new Variable<string> { Name = "result" };
            
            Endpoint endpoint = new Endpoint
            {
                AddressUri = new Uri(Common.Constants.ServiceBaseAddress),
                Binding = new BasicHttpBinding(),
            };

            Send requestEcho = new Send
            {
                ServiceContractName = XName.Get("Echo", "http://tempuri.org/"),
                Endpoint = endpoint,
                OperationName = "Echo",
                Content = new SendParametersContent
                {
                    Parameters = 
                        { 
                            { "message", new InArgument<string>(message) }
                        }
                }
            };
            workflow = new CorrelationScope
            {
                Body = new Sequence
                {
                    Variables = { message, result },
                    Activities =
                    {
                        new WriteLine {
                            Text = new InArgument<string>("Hello")
                        },
                        requestEcho,
                        new ReceiveReply
                        {
                            Request = requestEcho,
                            Content = new ReceiveParametersContent                            
                            {
                                Parameters = 
                                {
                                    { "echo", new OutArgument<string>(result) }
                                }
                            }
                        },                        
                        new WriteLine {
                            Text = new InArgument<string>(result)
                        }
                    }
                }
            };