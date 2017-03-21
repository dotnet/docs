                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.UpdatePOName,
                        Content = SendContent.Create(new InArgument<PurchaseOrder>(po))
                    },           