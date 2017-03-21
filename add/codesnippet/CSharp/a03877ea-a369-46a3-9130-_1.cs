            // Create the purchase order.
            PurchaseOrder po = new PurchaseOrder();
            po.customerId = "somecustomer.com";
            po.poNumber = Guid.NewGuid().ToString();

            PurchaseOrderLineItem lineItem1 = new PurchaseOrderLineItem();
            lineItem1.productId = "Blue Widget";
            lineItem1.quantity = 54;
            lineItem1.unitCost = 29.99F;

            PurchaseOrderLineItem lineItem2 = new PurchaseOrderLineItem();
            lineItem2.productId = "Red Widget";
            lineItem2.quantity = 890;
            lineItem2.unitCost = 45.89F;

            po.orderLineItems = new PurchaseOrderLineItem[2];
            po.orderLineItems[0] = lineItem1;
            po.orderLineItems[1] = lineItem2;
         
            OrderProcessorClient client = new OrderProcessorClient("OrderResponseEndpoint");
            MsmqMessage<PurchaseOrder> ordermsg = new MsmqMessage<PurchaseOrder>(po);
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.SubmitPurchaseOrder(ordermsg);
                scope.Complete();
            }

            Console.WriteLine("Order has been submitted:{0}", po);

            //Closing the client gracefully closes the connection and cleans up resources.
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();