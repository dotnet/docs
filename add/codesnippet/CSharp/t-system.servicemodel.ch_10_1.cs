        public void SimpleSubmitPurchaseOrder(PurchaseOrder po)
        {
            Console.WriteLine("Submitting purchase order did not succeed ", po);
            MsmqMessageProperty mqProp = OperationContext.Current.IncomingMessageProperties[MsmqMessageProperty.Name] as MsmqMessageProperty;

            Console.WriteLine("Message Delivery Status: {0} ", mqProp.DeliveryStatus);
            Console.WriteLine("Message Delivery Failure: {0}", mqProp.DeliveryFailure);
            Console.WriteLine();
        }