
    // Define a service contract for the calculator.
    [ServiceContract()]
    public interface ICalculator
    {
        [OperationContract(IsOneWay = false)]
        double Add(double n1, double n2);
        [OperationContract(IsOneWay = false)]
        double Subtract(double n1, double n2);
        [OperationContract(IsOneWay = false)]
        double Multiply(double n1, double n2);
        [OperationContract(IsOneWay = false)]
        double Divide(double n1, double n2);
    }

    // Service class which implements the service contract.
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            return result;
        }

        // Create and configure bindings within this EXE console application.
        public static void Main()
        {
            // Create a WSHttpBinding
            WSHttpBinding binding1 = new WSHttpBinding();

	    binding1.BypassProxyOnLocal =  true;

	    EnvelopeVersion envelopeVersion =
		binding1.EnvelopeVersion;

	    HostNameComparisonMode hostnameComparisonMode =
		binding1.HostNameComparisonMode;

	    long maxBufferPoolSize =
	        binding1.MaxBufferPoolSize;


	    long maxReceivedMessageSize =
		binding1.MaxReceivedMessageSize;

	    WSMessageEncoding messageEncoding =
		binding1.MessageEncoding;

	    Uri proxyAddress =
	        binding1.ProxyAddress;

	    XmlDictionaryReaderQuotas readerQuotas =
		binding1.ReaderQuotas;

	    OptionalReliableSession reliableSession =
		binding1.ReliableSession;

	    string scheme = binding1.Scheme;

	    Encoding textEncoding =
	        binding1.TextEncoding;

	    bool transactionFlow =
	        binding1.TransactionFlow;

	    bool useDefaultWebProxy =
	        binding1.UseDefaultWebProxy;

	    BindingElementCollection bindingElements = 
			    binding1.CreateBindingElements();




            // Set WSHttpBinding binding property values
            binding1.Name = "Binding1";
            binding1.HostNameComparisonMode =
               HostNameComparisonMode.StrongWildcard;
            binding1.Security.Mode = SecurityMode.Message;
            binding1.ReliableSession.Enabled = false;
            binding1.TransactionFlow = false;
           // binding1.Security.Message.DefaultProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

            // Enumerate properties of the binding1.
            Console.WriteLine("WSHttpBinding binding1 properties:");
            Console.WriteLine("      - name:\t\t\t{0}", binding1.Name);
            Console.WriteLine("      - hostname comparison:\t{0}", binding1.HostNameComparisonMode);
            Console.WriteLine("      - security mode:\t\t{0}", binding1.Security.Mode);
            Console.WriteLine("      - RM enabled:\t\t{0}", binding1.ReliableSession.Enabled);
            Console.WriteLine("      - transaction flow:\t{0}", binding1.TransactionFlow);
            //Console.WriteLine("      - message security:\t{0}", binding1.Security.Message.DefaultProtectionLevel);
            Console.WriteLine("      - transport scheme:\t{0}", binding1.Scheme);
            Console.WriteLine("      - max message size:\t{0}", binding1.MaxReceivedMessageSize);
            Console.WriteLine("      - default text encoding:\t{0}", binding1.TextEncoding);
            Console.WriteLine();

            // Create a WSFederationBinding with a message security mode
            // and with a reliable session enabled.
            WSFederationHttpBinding binding3 = new WSFederationHttpBinding(WSFederationHttpSecurityMode.Message, true);

            // Enumerate properties of the binding2.
            Console.WriteLine("WSFederationBinding binding3 properties:");
            Console.WriteLine("      - security mode:\t\t{0}", binding3.Security.Mode);
            Console.WriteLine("      - RM enabled:\t\t{0}", binding3.ReliableSession.Enabled);
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate.");
            Console.ReadLine();

        }

	static void SnippetReceiveSynchronously ()
	{
		WSHttpBinding binding = new WSHttpBinding();
		IBindingRuntimePreferences s  =
					       binding.GetProperty<IBindingRuntimePreferences>
					       (new BindingParameterCollection());
		bool receiveSynchronously = s.ReceiveSynchronously;

	}

    }