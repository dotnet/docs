// 
// 
using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace WSHttpBindingSample
{
    //<snippet0>

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
	    // <Snippet3>
	    // <Snippet1>
            WSHttpBinding binding1 = new WSHttpBinding();
	    // </Snippet1>

	    binding1.BypassProxyOnLocal =  true;
	    // </Snippet3>

	    // <Snippet4>
	    EnvelopeVersion envelopeVersion =
		binding1.EnvelopeVersion;
	    // </Snippet4>

	    // <Snippet5>
	    HostNameComparisonMode hostnameComparisonMode =
		binding1.HostNameComparisonMode;
	    // </Snippet5>

	    // <Snippet6>
	    long maxBufferPoolSize =
	        binding1.MaxBufferPoolSize;
	    // </Snippet6>


	    // <Snippet7>
	    long maxReceivedMessageSize =
		binding1.MaxReceivedMessageSize;
	    // </Snippet7>

	    // <Snippet8>
	    WSMessageEncoding messageEncoding =
		binding1.MessageEncoding;
	    // </Snippet8>

	    // <Snippet9>
	    Uri proxyAddress =
	        binding1.ProxyAddress;
	    // </Snippet9>

	    // <Snippet10>
	    XmlDictionaryReaderQuotas readerQuotas =
		binding1.ReaderQuotas;
	    // </Snippet10>

	    // <Snippet11>
	    OptionalReliableSession reliableSession =
		binding1.ReliableSession;
	    // </Snippet11>

	    // <Snippet12>
	    string scheme = binding1.Scheme;
	    // </Snippet12>

	    // <Snippet13>
	    Encoding textEncoding =
	        binding1.TextEncoding;
	    // </Snippet13>

	    // <Snippet14>
	    bool transactionFlow =
	        binding1.TransactionFlow;
	    // </Snippet14>

	    // <Snippet15>
	    bool useDefaultWebProxy =
	        binding1.UseDefaultWebProxy;
	    // </Snippet15>

	    // <Snippet16>
	    BindingElementCollection bindingElements = 
			    binding1.CreateBindingElements();
	    // </Snippet16>




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

	// <Snippet19>
	static void SnippetReceiveSynchronously ()
	{
		WSHttpBinding binding = new WSHttpBinding();
		IBindingRuntimePreferences s  =
					       binding.GetProperty<IBindingRuntimePreferences>
					       (new BindingParameterCollection());
		bool receiveSynchronously = s.ReceiveSynchronously;

	}
       // </Snippet19>

    }
    //</snippet0>
}


