using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;
using System.Security.Principal;
using System.ServiceModel.Security;
using System.Runtime.Serialization;
using System.Xml;

namespace UE.Samples
{
    // <Snippet2>
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

		//<Snippet5>
		long maxBufferPoolSize = binding.MaxBufferPoolSize;
		//</Snippet5>

		//<Snippet6>
		int maxBufferSize = binding.MaxBufferSize;
		//</Snippet6>

		//<Snippet7>
		int maxConnections = binding.MaxConnections;
		//</Snippet7>

		//<Snippet8>
		long maxReceivedMessageSize =
		    binding.MaxReceivedMessageSize;
		//</Snippet8>

		//<Snippet9>
		NetNamedPipeSecurity security = binding.Security;
		//</Snippet9>

		//<Snippet10>
		string scheme = binding.Scheme;
		//</Snippet10>

		//<Snippet11>
		XmlDictionaryReaderQuotas readerQuotas =
			binding.ReaderQuotas;
		//</Snippet11>

		//<Snippet12>
		BindingElementCollection bCollection = binding.CreateBindingElements();
		//</Snippet12>

		//<Snippet13>
		HostNameComparisonMode hostNameComparisonMode =
			binding.HostNameComparisonMode;
		//</Snippet13>

		//<Snippet14>
		bool TransactionFlow = binding.TransactionFlow;
		//</Snippet14>

		//<Snippet15>
		TransactionProtocol transactionProtocol =
			binding.TransactionProtocol;
		//</Snippet15>

		//<Snippet16>
		EnvelopeVersion envelopeVersion =
			binding.EnvelopeVersion;
		//</Snippet16>

		//<Snippet18>
		TransferMode transferMode =
			binding.TransferMode;
		//</Snippet18>


				
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
		// <Snippet17>

		NetNamedPipeBinding binding = new NetNamedPipeBinding();
		IBindingRuntimePreferences s  =
		       binding.GetProperty<IBindingRuntimePreferences>
		       (new BindingParameterCollection());
		bool receiveSynchronously = s.ReceiveSynchronously;

		// </Snippet17>

	}
    }
    // </Snippet2>
}
