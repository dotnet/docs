		<OperationBehavior(TransactionScopeRequired := True, TransactionAutoComplete := True)> _
		Public Sub SimpleSubmitPurchaseOrder(ByVal po As PurchaseOrder)
			Console.WriteLine("Submitting purchase order did not succeed ", po)
			Dim mqProp As MsmqMessageProperty = TryCast(OperationContext.Current.IncomingMessageProperties(MsmqMessageProperty.Name), MsmqMessageProperty)

			Console.WriteLine("Message Delivery Status: {0} ", mqProp.DeliveryStatus)
			Console.WriteLine("Message Delivery Failure: {0}", mqProp.DeliveryFailure)
			Console.WriteLine()
		End Sub