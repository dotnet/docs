using System;
using System.Net;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Collections.Generic;

namespace CustomHttpHeaderSample
{
    [ServiceContract]
    public interface IUntypedService
    {
        [OperationContract]
        void ProcessMessage(Message input);
    }

    [ServiceContract]
    public interface ITypedService
    {
        [OperationContract]
        void ProcessTypedInput(string input);
    }


    public class Program : IUntypedService, ITypedService
    {
        static ServiceHost serviceHost;
        static Uri address = new Uri("http://" + Environment.MachineName + ":8000");
        static EndpointAddress epa = new EndpointAddress(address.ToString());

        static void Main(string[] args)
        {
            StartService();

            Console.WriteLine("UNTYPED");
            StartUntypedClient();

            Console.WriteLine("TYPED");
            StartTypedClient();

            serviceHost.Close();
            Console.WriteLine("exiting");
            Console.ReadLine();
        }

        static void StartService()
        {
            serviceHost = new ServiceHost(typeof(Program), address);
            BasicHttpBinding binding = new BasicHttpBinding();
            ServiceEndpoint endpoint = new ServiceEndpoint(
                                            ContractDescription.GetContract(typeof(IUntypedService)),
                                            binding,
                                            epa);
            ServiceEndpoint anotherEndpoint = new ServiceEndpoint(
                                            ContractDescription.GetContract(typeof(ITypedService)),
                                            binding,
                                            epa);
            serviceHost.Description.Endpoints.Add(endpoint);
            serviceHost.Description.Endpoints.Add(anotherEndpoint);
            serviceHost.Open();
        }

        static void StartUntypedClient()
        {
            Message message = BuildMessage();
            ChannelFactory<IUntypedService> channelFactory = new ChannelFactory<IUntypedService>(new BasicHttpBinding());
            channelFactory.Open();
            IUntypedService proxy = channelFactory.CreateChannel(epa);

            try
            {
                proxy.ProcessMessage(message);
                Console.WriteLine("sent untyped message to service");
            }
            catch (Exception e)
            {
                Console.WriteLine("received an exception for the untyped message scenario: " + e.ToString());
            }
        }
        // <snippet3>
        static Message BuildMessage()
        {
            Message messageToSend = null;
            // <snippet2>
            HttpRequestMessageProperty reqProps = new HttpRequestMessageProperty();
            reqProps.SuppressEntityBody = false;
            // </snippet2>
            reqProps.Headers.Add("CustomHeader", "Test Value");
            reqProps.Headers.Add(HttpRequestHeader.UserAgent, "my user agent");

            try
            {
                messageToSend = Message.CreateMessage(MessageVersion.Soap11, "http://tempuri.org/IUntypedService/ProcessMessage", "Hello WCF");
            }
            catch (Exception e)
            {
                Console.WriteLine("got exception when sending message: " + e.ToString());
            }

            messageToSend.Properties[HttpRequestMessageProperty.Name] = reqProps;
            return messageToSend;
        }
        // </snippet3>

        static void StartTypedClient()
        {
            ChannelFactory<ITypedService> anotherChannelFactory = new ChannelFactory<ITypedService>(new BasicHttpBinding());
            anotherChannelFactory.Open();
            ITypedService typedProxy = anotherChannelFactory.CreateChannel(epa);

            try
            {
                HttpRequestMessageProperty reqProps = new HttpRequestMessageProperty();
                reqProps.SuppressEntityBody = false;
                reqProps.Headers.Add("CustomHeader", "Test Value");
                reqProps.Headers.Add(HttpRequestHeader.UserAgent, "my user agent");
                using (OperationContextScope scope = new OperationContextScope((IContextChannel)typedProxy))
                {
                    OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, reqProps);
                    typedProxy.ProcessTypedInput("this is a typed string message");
                }
                Console.WriteLine("sent typed message to service");
            }
            catch (Exception e)
            {
                Console.WriteLine("received an exception for the typed message scenario: " + e.ToString());
            }

        }
        // <snippet0>
        public void ProcessMessage(Message input)
        {
            try
            {
                Console.WriteLine("ProcessMessage: Message received: " + input.GetBody<string>());
                HttpRequestMessageProperty reqProp = (HttpRequestMessageProperty)input.Properties[HttpRequestMessageProperty.Name];
                string customString = reqProp.Headers.Get("CustomHeader");
                string userAgent = reqProp.Headers[HttpRequestHeader.UserAgent];
                Console.WriteLine();
                Console.WriteLine("ProcessMessage: Got custom header: {0}, User-Agent: {1}", customString, userAgent);
            }
            catch (Exception e)
            {
                Console.WriteLine("ProcessMessage: got exception: " + e.ToString());
            }
        }
        // </snippet0>
        public void ProcessTypedInput(string input)
        {
            try
            {
                Console.WriteLine("ProcessTypedInput: Message received: " + input);
                HttpRequestMessageProperty reqProp = (HttpRequestMessageProperty)(OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name]);
                string customString = reqProp.Headers.Get("CustomHeader");
                string userAgent = reqProp.Headers[HttpRequestHeader.UserAgent];

                Console.WriteLine();
                Console.WriteLine("ProcessTypedInput: Got custom header: {0}, User-Agent: {1} ", customString, userAgent);
            }
            catch (Exception e)
            {
                Console.WriteLine("ProcessTypedInput: got exception: " + e.ToString());
            }
        }
    }
}

