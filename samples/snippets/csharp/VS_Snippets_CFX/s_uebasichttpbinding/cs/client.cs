//  client.cs, snippet for S_UEEnvelopeVersion Copyright (c) Microsoft
//  Corporation.  All Rights Reserved.

using System;
using System.Text;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;
using System.Xml;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Net.Security;
   
// Define a service contract.
[ServiceContract(Namespace = "http://UE.ServiceModel.Samples")]
public interface ICalculator
{
    [OperationContract]
    double Add(double n1, double n2);
    [OperationContract]
    double Subtract(double n1, double n2);
    [OperationContract]
    double Multiply(double n1, double n2);
    [OperationContract]
    double Divide(double n1, double n2);
}

namespace UE.ServiceModel.Samples
{

    class Client
    {
	
	    static void SnippetSupportsServerAuthentication()
	    {
		    // <Snippet36>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    ISecurityCapabilities b =
			    binding.GetProperty<ISecurityCapabilities>
			    (new BindingParameterCollection());
		    
		    bool SupportsServerAuthentication =
			    b.SupportsServerAuthentication;
		    // </Snippet36>
	    }

	    static void SnippetSupportsClientAuthentication()
	    {
		    // <Snippet35>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    ISecurityCapabilities s  =
			    binding.GetProperty<ISecurityCapabilities>
			    (new BindingParameterCollection());
		    bool ClientAuthentication =
			    s.SupportsClientAuthentication;
		    // </Snippet35>
	    }


	    static void SnippetSupportedRequestProtectionLevel()
	    {
		    // <Snippet34>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    ISecurityCapabilities s  =
			    binding.GetProperty<ISecurityCapabilities>
			    (new BindingParameterCollection());
		    ProtectionLevel p = s.SupportedResponseProtectionLevel;
		    // </Snippet34>
	    }

	    static void SnippetIsMulticast()
	    {
		    // <Snippet33>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    IBindingMulticastCapabilities s  =
					      binding.GetProperty<IBindingMulticastCapabilities>
					      (new BindingParameterCollection());
		    bool isMulticast = s.IsMulticast;
		    // </Snippet33>
	    }

	    static void SnippetQueuedDelivery()
	    {
		    // <Snippet32>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    IBindingDeliveryCapabilities s  =
		        binding.GetProperty<IBindingDeliveryCapabilities>
			    (new BindingParameterCollection());
		    bool queuedDelivery = s.QueuedDelivery;
		    // </Snippet32>
	    }
	    
	    static void SnippetSupportsClientWindowsIdentity()
	    {
		    // <Snippet31>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    ISecurityCapabilities s  =
			binding.GetProperty<ISecurityCapabilities>
			 (new BindingParameterCollection());
		    //bool supportsClientWindowsIdentity p =
		    //	s.SupportedClientWindowsIdentity;
		    // </Snippet31>
	    }
	    
	    static void SnippetSupportedResponseProtectionLevel ()
	    {
		    // <Snippet30>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    ISecurityCapabilities s  =
			binding.GetProperty<ISecurityCapabilities>
		          (new BindingParameterCollection());
		    ProtectionLevel p = s.SupportedResponseProtectionLevel;
          	    // </Snippet30>

	    }

	    static void SnippetReceiveSynchronously ()
	    {
		    // <Snippet29>

		    BasicHttpBinding binding = new BasicHttpBinding();
		    IBindingRuntimePreferences s  =
			    (binding as IBindingRuntimePreferences);
		    bool receiveSynchronously = s.ReceiveSynchronously;
		    
		    // </Snippet29>
						
	    }
	    
	    static void SnippetAssuresOrderedDelivery ()
	    {
	          // <Snippet28>
                  BasicHttpBinding binding = new BasicHttpBinding();
		  IBindingDeliveryCapabilities s  =
			  binding.GetProperty<IBindingDeliveryCapabilities>
			  (new BindingParameterCollection());
		  bool assuresOrderedDelivery = s.AssuresOrderedDelivery;

		// </Snippet28>
	    }
	    
	    static void SnippetUseDefaultWebProxy()
	    {

		// <Snippet27>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    binding.UseDefaultWebProxy = false;
		// </Snippet27>
	    }
	    
	    static void SnippetCreateBindingElements()
	    {
		// from S_UEBinding\cs\Snippets.cs
		// <Snippet26>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    binding.Name = "binding1";
		    binding.Namespace = "http:\\My.ServiceModel.Samples";
		    BindingElementCollection elements = binding.CreateBindingElements();
		// </Snippet26>
	    }
	    static void SnippetTransferMode()
	    {
		// <Snippet25>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    binding.TransferMode = TransferMode.Streamed;

		// </Snippet25>
	    }
	    
	    static void SnippetBasicTextEncoding()
	    {
		// <Snippet24>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    binding.TextEncoding = System.Text.Encoding.Unicode;

		// </Snippet24>
	    }

	    static void SnippetBasicHttpSecurity ()
	    {
		// <Snippet23>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    BasicHttpSecurity security = binding.Security;
		    		    
		// </Snippet23>
	    }
	    
	    static void SnippetSchmeme ()
	    {
		// <Snippet22>
                BasicHttpBinding binding = new BasicHttpBinding();
		string thisScheme = binding.Scheme;
		// </Snippet22>
	    }
	    
	    static void SnippetReaderQuotas ()
	    {
                // <Snippet21>
		BasicHttpBinding binding =
			new BasicHttpBinding();
		XmlDictionaryReaderQuotas readerQuotas = new XmlDictionaryReaderQuotas();
		readerQuotas.MaxArrayLength = 25 * 1024;
		
	        binding.ReaderQuotas = readerQuotas;
		// </Snippet21>
	    }
	    
	    static void SnippetMessageProxyAddress ()
	    {
	    // <Snippet20>
                    // Get base address from app settings in configuration
		    Uri baseAddress = new Uri(ConfigurationManager.
			    AppSettings["baseAddress"]);

		    BasicHttpBinding binding = new BasicHttpBinding();

		    binding.ProxyAddress = baseAddress;

	    // </Snippet20>
	    }

	    static void SnippetMessageEncoding ()
	    {
	    // <Snippet19>
		    
		    BasicHttpBinding binding = new BasicHttpBinding();
		    // Use double the default value
		    binding.MessageEncoding = WSMessageEncoding.Text;

	    // </Snippet19>
	    }
	    
	    static void SnippetMaxReceivedMessageSize ()
	    {
	    // <Snippet18>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    // Use double the default value
		    binding.MaxReceivedMessageSize = 65536 * 2;

	    // </Snippet18>

	    }

	    static void SnippetMaxBufferSize ()
	    {
	    // <Snippet17>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    
		    // set to one million
		    binding.MaxBufferSize = 1000000;

	    // </Snippet17>
	    }
 

	    static void SnippetMaxBufferPoolSize ()
	    {
	    // <Snippet16>
		    BasicHttpBinding binding = new BasicHttpBinding();
		    // Use double the default value
		    binding.MaxBufferPoolSize = 0x80000 * 2;

	    // </Snippet16>

	    }
	    
	static void SnippetHostNameComparisonMode ()
	{
	    // <Snippet14>
		BasicHttpBinding binding = new BasicHttpBinding();
		binding.HostNameComparisonMode =
 		HostNameComparisonMode.Exact;
	    // </Snippet14>
	}

	static void SnippetAllowCookies()
	{
	    // <Snippet40>
		BasicHttpBinding binding = new BasicHttpBinding();
		binding.AllowCookies = true;
	    // </Snippet40>
		
	}
	
	
        static void Main()
        {
	    int i = 0;
		
	    // <Snippet12>		
            BasicHttpBinding binding = new BasicHttpBinding();
	    binding.BypassProxyOnLocal = true;

	    // </Snippet12>

	    // <Snippet13>
	    if (binding.EnvelopeVersion == EnvelopeVersion.Soap11)
		    i++;
	    
	    // </Snippet13>

	    
            binding.Name = "binding1";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.None;

            String url = "http://localhost:8000/servicemodelsamples/service/calc";
            EndpointAddress address = new EndpointAddress(url);
            ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>(binding, address);
            ICalculator channel = channelFactory.CreateChannel();

            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = channel.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = channel.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = channel.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = channel.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            ((IChannel)channel).Close();
            Console.ReadLine();


        }
    }
}
