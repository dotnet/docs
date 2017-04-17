using System;
using System.Xml;
using System.ServiceModel.Channels;
using System.Configuration;
//using System.Messaging;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace UE.ServiceModel.Samples
{
    public class Snippets
    {
        public static void Snippet2()
        {
            // <Snippet2>
            NetMsmqBinding binding = new NetMsmqBinding();
            XmlDictionaryReaderQuotas readerQuotas = new XmlDictionaryReaderQuotas();
            readerQuotas.MaxArrayLength = 25 * 1024;
            binding.ReaderQuotas = readerQuotas;
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            NetMsmqBinding binding = new NetMsmqBinding();
            BindingElementCollection bindingElements = binding.CreateBindingElements();

            foreach (BindingElement element in bindingElements)
            {
                Console.WriteLine(element.ToString());
            }
            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            NetMsmqBinding binding = new NetMsmqBinding();
            binding.MaxBufferPoolSize = 524000L;
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            NetMsmqBinding binding = new NetMsmqBinding();
            binding.QueueTransferProtocol = QueueTransferProtocol.Native;
            // </Snippet5>
        }

        public static void Snippet6()
        {
            // <Snippet6>
            NetMsmqBinding binding = new NetMsmqBinding();
            binding.UseActiveDirectory = true;
            // </Snippet6>
        }

	// public NetMsmqBinding(NetMsmqSecurityMode)
	public static void Snippet7()
	{
	    // <Snippet7>
		NetMsmqBinding binding = new NetMsmqBinding();
        	NetMsmqSecurity security = binding.Security;
	    // </Snippet7>
	}
	
	// public NetMsmqBinding(NetMsmqSecurityMode)
	public static void Snippet8()
	{
		// <Snippet8>
		NetMsmqBinding binding = new NetMsmqBinding(NetMsmqSecurityMode.Message);
		// </Snippet8>
	}


	public static void Snippet9()
	{
		// <Snippet9>
		NetMsmqBinding binding = new NetMsmqBinding();
		EnvelopeVersion envelopeVersion = binding.EnvelopeVersion;
		// </Snippet9>
	}

    }


}
