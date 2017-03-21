            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>();
            Variable<Customer> customer = new Variable<Customer>();

            Endpoint clientEndpoint = new Endpoint
            {
                Binding = Constants.Binding,
                AddressUri = new Uri(Constants.ServiceAddress)
            };

            Send submitPO = new Send
            {
                Endpoint = clientEndpoint,
                ServiceContractName = Constants.POContractName,
                OperationName = Constants.SubmitPOName,
                Content = new SendMessageContent(new InArgument<PurchaseOrder>(po))               
            };