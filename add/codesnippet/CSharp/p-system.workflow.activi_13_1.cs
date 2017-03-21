            SendActivity RequestQuoteFromShipper3 = new SendActivity();
            TypedOperationInfo typedOperationInfo2 = new TypedOperationInfo();
            typedOperationInfo2.ContractType = typeof(IShippingRequest);
            typedOperationInfo2.Name = "RequestShippingQuote";
            RequestQuoteFromShipper3.ServiceOperationInfo = typedOperationInfo2;