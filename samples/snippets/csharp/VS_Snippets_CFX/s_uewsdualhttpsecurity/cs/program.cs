using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Runtime.Serialization;

namespace CS
{
    class Program
    {

        // from http://blogs.msdn.com/drnick/archive/2006/07/19/670789.aspx
        static void WSDualHttpMain()
        {
            // <Snippet1>
            WSDualHttpBinding binding = new WSDualHttpBinding();
            // </Snippet1>


            // <Snippet2>
            string configName = "string";
            WSDualHttpBinding bindingString = new WSDualHttpBinding(configName);
            // </Snippet2>

            // <Snippet3>
            WSDualHttpBinding bindingSecurityMode =
                new WSDualHttpBinding(WSDualHttpSecurityMode.Message);
            // </Snippet3>


            /*            String clientBaseAddress = "http://localhost:8080/Discovery/" + Guid.NewGuid().ToString();
                        Uri clientBaseAddressUri = new Uri(clientBaseAddress);
                        WSDualHttpBinding bindingClientBaseAddress = 
                            new WSDualHttpBinding(clientBaseAddressUri);
          */
            // <Snippet8>
            WSDualHttpBinding dualBinding = new WSDualHttpBinding();
            EndpointAddress endptadr = new EndpointAddress("http://localhost:12000/DuplexTestUsingCode/Server");
            dualBinding.ClientBaseAddress = new Uri("http://localhost:8000/DuplexTestUsingCode/Client/");

            // </Snippet8>

            // <Snippet9>
            // Set to StrongWildCard
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            // </Snippet9>

            // <Snippet10>
            binding.MaxBufferPoolSize = 900000;
            // </Snippet10>

            // <Snippet11>
            binding.MessageEncoding = WSMessageEncoding.Mtom;
            // </Snippet11>

            // <Snippet12>
            string proxyAddressString = "http://localhost:5049";
            Uri proxyBaseAddressUri = new Uri(proxyAddressString);
            binding.ProxyAddress = proxyBaseAddressUri;
            // </Snippet12>

            // <Snippet13>
            XmlDictionaryReaderQuotas readerQuotas =
                binding.ReaderQuotas;
            // </Snippet13>

            // <Snippet14>
            ReliableSession reliableSession =
                binding.ReliableSession;
            // </Snippet14>

            // <Snippet15>
            string scheme = binding.Scheme;
            // </Snippet15>

            // <Snippet16>
            WSDualHttpSecurity security = binding.Security;
            // </Snippet16>

            // <Snippet17>
            Encoding bindingEncoding = binding.TextEncoding;
            // </Snippet17>

            // <Snippet18>
            binding.TransactionFlow = true;
            // </Snippet18>

            // <Snippet19>
            binding.UseDefaultWebProxy = true;
            // </Snippet19>

            // <Snippet20>
            BindingElementCollection bec = binding.CreateBindingElements();
            // </Snippet20>

            // <Snippet21>
            EnvelopeVersion envelopeversion = binding.EnvelopeVersion;
            // </Snippet21>

            // <Snippet22>
            long maxReceivedMessageSize = binding.MaxReceivedMessageSize;
            // </Snippet22>




            binding.Security.Mode = WSDualHttpSecurityMode.None;
            //<snippet30>
            WSDualHttpBinding binding3 = new WSDualHttpBinding();
            binding3.Security.Mode = WSDualHttpSecurityMode.None;
            binding3.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256;
            binding3.MessageEncoding = WSMessageEncoding.Mtom;
            //</snippet30>

            // <Snippet6>
            WSDualHttpBinding BypassProxyOnLocalBinding =
                new WSDualHttpBinding();
            BypassProxyOnLocalBinding.BypassProxyOnLocal = true;
            // <//Snippet6>

            //AnalyzeBindings(binding1, binding2, binding3);
        }
        static void Main(string[] args)
        {
            // <Snippet24>
            TcpChunkingBinding tcb = new TcpChunkingBinding();
            bool isSynchronous = tcb.ReceiveSynchronously;
            // </Snippet24>
        }
    }

    // <Snippet23>
    public class TcpChunkingBinding : IBindingRuntimePreferences
    {
    // </Snippet23>
        //TcpTransportBindingElement tcpbe;
        //ChunkingBindingElement be;

        public TcpChunkingBinding()
            : base()
        {
            Initialize();
        }
        //public override BindingElementCollection CreateBindingElements()
        //{
        //    BindingElementCollection col = new BindingElementCollection();
        //    col.Add(be);
        //    col.Add(tcpbe);
        //    return col;
        //}

        //public override string Scheme
        //{
        //    get { return tcpbe.Scheme; }
        // }
        public int MaxBufferedChunks
        {
            get { return 0 ;/*this.be.MaxBufferedChunks;*/ }
            set { /*this.be.MaxBufferedChunks = value;*/ }
        }

        void Initialize()
        {
//            be = new ChunkingBindingElement();
//            tcpbe = new TcpTransportBindingElement();
//            tcpbe.TransferMode = TransferMode.Buffered; //no transport streaming
//            tcpbe.MaxReceivedMessageSize = ChunkingUtils.ChunkSize + 100 * 1024; //add 100KB for headers
//            this.SendTimeout = new TimeSpan(0, 5, 0);
//            this.ReceiveTimeout = this.SendTimeout;

        }

        #region IBindingRuntimePreferences Members

        public bool ReceiveSynchronously
        {
            get { return true; }
        }

        #endregion
    }

    /*
     //<snippet134>
      <client>
        <endpoint 
          name ="ServerEndpoint" 
          address="http://localhost:12000/DuplexUsingConfig/Server"
          bindingConfiguration="WSDualHttpBinding_IDuplex" 
          binding="wsDualHttpBinding"
          contract="IDuplex" 
      />
      </client>
      <bindings>
        <wsDualHttpBinding>
          <binding 
            name="WSDualHttpBinding_IDuplex"  
            clientBaseAddress="http://localhost:8000/myClient/" 
          />
        </wsDualHttpBinding>
      </bindings>
     //</snippet134>
    */
  }
