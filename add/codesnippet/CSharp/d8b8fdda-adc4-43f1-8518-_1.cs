            return new Sequence
            {
                Variables = { po, customer },
                Activities =
                {                    
                    new Assign<PurchaseOrder> 
                    {
                        To = po,
                        Value = new InArgument<PurchaseOrder>( (e) => new PurchaseOrder() { PartName = "Widget", Quantity = 150 } )
                    },
                    new Assign<Customer>
                    {
                        To = customer,
                        Value = new InArgument<Customer>( (e) => new Customer() { Id = 12345678, Name = "John Smith" } )
                    },
                    new WriteLine { Text = new InArgument<string>( (e) => string.Format("Submitting new PurchaseOrder for {0} {1}s", po.Get(e).Quantity, po.Get(e).PartName) ) },
                    new CorrelationScope
                    {
                        Body = new Sequence
                        { 
                            Activities = 
                            {
                                submitPO,
                                new ReceiveReply
                                {
                                    Request = submitPO,
                                    Content = ReceiveContent.Create(new OutArgument<int>( (e) => po.Get(e).Id ))
                                }
                            }
                        }
                    },                    
                    new WriteLine { Text = new InArgument<string>( (e) => string.Format("Received ID for new PO: {0}", po.Get(e).Id) ) },
                    new Assign<int> { To = new OutArgument<int>( (e) => po.Get(e).Quantity ), Value = 250 },
                    new WriteLine { Text = "Updated PO with new quantity: 250.  Resubmitting updated PurchaseOrder based on POId." },
                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.UpdatePOName,
                        Content = SendContent.Create(new InArgument<PurchaseOrder>(po))
                    },           
                    new Assign<int> 
                    { 
                        To = new OutArgument<int>( (e) => po.Get(e).CustomerId ), 
                        Value = new InArgument<int>( (e) => customer.Get(e).Id )
                    },
                    new WriteLine { Text = "Updating customer data based on CustomerId." },
                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.AddCustomerInfoName,
                        Content = SendContent.Create(new InArgument<PurchaseOrder>(po))
                    },                    
                    new Send
                    {
                        Endpoint = clientEndpoint,
                        ServiceContractName = Constants.POContractName,
                        OperationName = Constants.UpdateCustomerName,
                        Content = SendContent.Create(new InArgument<Customer>(customer))
                    },
                    new WriteLine { Text = "Client completed." }
                }
            };