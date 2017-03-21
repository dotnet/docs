    public class OrderProcessorService : IOrderProcessor
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> ordermsg)
        {
            PurchaseOrder po = (PurchaseOrder)ordermsg.Body;
            Random statusIndexer = new Random();
            po.Status = (OrderStates)statusIndexer.Next(3);
            Console.WriteLine("Processing {0} ", po);
        }

	    // Host the service within this EXE console application.
	public static void Main()
	{
	    // Get base address from appsettings in configuration.
		Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);

	    // Create a ServiceHost for the CalculatorService type and provide the base address.
		using (ServiceHost serviceHost = new ServiceHost(typeof(IOrderProcessor), baseAddress))
		{
		// Open the ServiceHostBase to create listeners and start listening for messages.
			serviceHost.Open();

		// The service can now be accessed.
			Console.WriteLine("The service is ready.");
			Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name);
			Console.WriteLine("Press <ENTER> to terminate service.");
			Console.WriteLine();
			Console.ReadLine();

		// Close the ServiceHostBase to shutdown the service.
			serviceHost.Close();
		}
	}

    }