    [ServiceContract(Namespace = "http://UE.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
    }

    // Service class which implements the service contract.
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static void Main()
        {
            Uri baseAddress = new Uri("http://localhost:8000/uesamples/service");
            string address = "net.pipe://localhost/uesamples/calc";

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address);

                // Add a mex endpoint
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = new Uri("http://localhost:8001/uesamples");
                serviceHost.Description.Behaviors.Add(smb);

		long maxBufferPoolSize = binding.MaxBufferPoolSize;

		int maxBufferSize = binding.MaxBufferSize;

		int maxConnections = binding.MaxConnections;

		long maxReceivedMessageSize =
		    binding.MaxReceivedMessageSize;

		NetNamedPipeSecurity security = binding.Security;

		string scheme = binding.Scheme;

		XmlDictionaryReaderQuotas readerQuotas =
			binding.ReaderQuotas;

		BindingElementCollection bCollection = binding.CreateBindingElements();

		HostNameComparisonMode hostNameComparisonMode =
			binding.HostNameComparisonMode;

		bool TransactionFlow = binding.TransactionFlow;

		TransactionProtocol transactionProtocol =
			binding.TransactionProtocol;

		EnvelopeVersion envelopeVersion =
			binding.EnvelopeVersion;

		TransferMode transferMode =
			binding.TransferMode;


				
                serviceHost.Open();
        
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                serviceHost.Close();
            }
        }

	static void SnippetReceiveSynchronously ()
	{

		NetNamedPipeBinding binding = new NetNamedPipeBinding();
		IBindingRuntimePreferences s  =
		       binding.GetProperty<IBindingRuntimePreferences>
		       (new BindingParameterCollection());
		bool receiveSynchronously = s.ReceiveSynchronously;


	}
    }