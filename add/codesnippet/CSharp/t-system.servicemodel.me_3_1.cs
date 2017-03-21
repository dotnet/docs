                    new SendReply
                    {
                        Request = submitPO,
                        Content = SendContent.Create(new InArgument<int>( (e) => po.Get(e).Id)), // creates a SendMessageContent
                        CorrelationInitializers =
                        {
                            new QueryCorrelationInitializer
                            {
                                // initializes a correlation based on the PurchaseOrder Id sent in the reply message and stores it in the handle
                                CorrelationHandle = poidHandle,
                                MessageQuerySet = new MessageQuerySet
                                {
                                    // int is the name of the parameter being sent in the outgoing response
                                    { "PoId", new XPathMessageQuery("sm:body()/ser:int", Constants.XPathMessageContext) }
                                }
                            }
                        }                        
                    }, 