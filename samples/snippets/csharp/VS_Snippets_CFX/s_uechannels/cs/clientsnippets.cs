/*
 *
 *ServiceModel.ChannelFactory`1.#ctor(System.Type) is protected, does
 *not require sample.
 *
 * */

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace client
{
	
   public class Snippets
    {
        public static void Snippet11()
        {
            // <Snippet11>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            BindingParameterCollection paramCollection = new BindingParameterCollection();

            binding.CanBuildChannelFactory<IRequestChannel>(paramCollection);
            // </Snippet11>
        }

        public static void Snippet12()
        {
            // <Snippet12>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            Object[] bindingParameters = new Object[2];

            binding.CanBuildChannelFactory<IRequestChannel>(bindingParameters);
            // </Snippet12>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            Object[] bindingParams = new Object[2];

	    // <Snippet30>
            IChannelFactory<IRequestChannel> factory = binding.BuildChannelFactory<IRequestChannel>(bindingParams);
            factory.Open();
            EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
            IRequestChannel channel = factory.CreateChannel(address);
            channel.Open();
	    // </Snippet30>
	    
            Message request = Message.CreateMessage(MessageVersion.Default, "hello");
            Message reply = channel.Request(request);
            Console.Out.WriteLine(reply.Headers.Action);
            reply.Close();
            channel.Close();
            factory.Close();
            // </Snippet3>
        }

        public static void Snippet13()
        {
            // <Snippet13>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            BindingParameterCollection paramCollection = new BindingParameterCollection();

            binding.CanBuildChannelFactory<IRequestChannel>(paramCollection);
            // </Snippet13>
        }

        public static void Snippet14()
        {
            // <Snippet14>
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new HttpTransportBindingElement());
            Object[] bindingParameters = new Object[2];

            binding.CanBuildChannelFactory<IRequestChannel>(bindingParameters);
            // </Snippet14>
        }

        public static void Snippet16()
        {
            // <Snippet16>
            CustomBinding binding = new CustomBinding();
            HttpTransportBindingElement element = new HttpTransportBindingElement();
            BindingParameterCollection parameters = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, parameters);

            IChannelFactory<IRequestChannel> factory = element.BuildChannelFactory<IRequestChannel>(context);
            factory.Open();
            EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
            IRequestChannel channel = factory.CreateChannel(address);
            channel.Open();
            Message request = Message.CreateMessage(MessageVersion.Default, "hello");
            Message reply = channel.Request(request);
            Console.Out.WriteLine(reply.Headers.Action);
            reply.Close();
            channel.Close();
            factory.Close();
            // </Snippet16>
        }

       public static void Snippet18()
       {
           // <Snippet18>
           CustomBinding binding = new CustomBinding();
           HttpTransportBindingElement element = new HttpTransportBindingElement();
           BindingParameterCollection parameters = new BindingParameterCollection();
           BindingContext context = new BindingContext(binding, parameters);

           bool bFlag = element.CanBuildChannelFactory<IRequestChannel>(context);
           // </Snippet18>
       }

       public static void Snippet21()
       {
	   // <Snippet21>
	       BasicHttpBinding binding = new BasicHttpBinding();
	       EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");

	       ChannelFactory<IRequestChannel> factory =
		       new ChannelFactory<IRequestChannel>(binding, address);

	       IRequestChannel channel = factory.CreateChannel();
	       channel.Open();
	       Message request = Message.CreateMessage(MessageVersion.Soap11, "hello");
	       Message reply = channel.Request(request);
	       Console.Out.WriteLine(reply.Headers.Action);
	       reply.Close();
	       channel.Close();
	       factory.Close();
       }	   
       // </Snippet21>


       public static void Snippet23()
       {
	   // <Snippet23>
	       ChannelFactory<IRequestChannel> factory = new ChannelFactory<IRequestChannel>("MyEndpoint");
	   // </Snippet23>
       }

       public static void Snippet24()
       {
           // <Snippet24>
           EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
           ChannelFactory<IRequestChannel> factory = new ChannelFactory<IRequestChannel>("MyEndpoint", address);
           // </Snippet24>
       }

       public static void Snippet25()
       {
           // <Snippet25>
           ContractDescription contract = new ContractDescription("MyContract");
           EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
           BasicHttpBinding binding = new BasicHttpBinding();
           ServiceEndpoint endpoint = new ServiceEndpoint(contract, binding, address);
           
           ChannelFactory<IRequestChannel> factory = new ChannelFactory<IRequestChannel>(endpoint);
           // </Snippet25>
       }

       public static void Snippet26()
       {
           // <Snippet26>
           BasicHttpBinding binding = new BasicHttpBinding();
           EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
           ChannelFactory<IRequestChannel> factory = new ChannelFactory<IRequestChannel>(binding, address);
           // </Snippet26>
       }

       public static void Snippet27()
       {
           // <Snippet27>
           BasicHttpBinding binding = new BasicHttpBinding();
           EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
           ChannelFactory<IRequestChannel> factory = new ChannelFactory<IRequestChannel>(binding);
           factory.CreateChannel(address);
           // </Snippet27>
       }

       public static void Snippet28()
       {
           // <Snippet28>
           BasicHttpBinding binding = new BasicHttpBinding();
           EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
	   Uri via = new Uri("http://localhost:8000/Via");

	   ChannelFactory<IRequestChannel> factory = new ChannelFactory<IRequestChannel>(binding);

           IRequestChannel channel = factory.CreateChannel(address, via);
           channel.Open();
           Message request = Message.CreateMessage(MessageVersion.Soap11, "hello");
           Message reply = channel.Request(request);
           Console.Out.WriteLine(reply.Headers.Action);
           reply.Close();
           channel.Close();
           factory.Close();
           // </Snippet28>
       }


       public static void Snippet29()
       {
	   // <Snippet29>
	   BasicHttpBinding binding = new BasicHttpBinding();
	   EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
	   Uri via = new Uri("http://localhost:8000/Via");

	   ChannelFactory<IRequestChannel> factory =
		   new ChannelFactory<IRequestChannel>(binding, "http://fsHost/fs/endp");

	   IRequestChannel channel = factory.CreateChannel(address, via);
	   channel.Open();
	   Message request = Message.CreateMessage(MessageVersion.Soap11, "hello");
	   Message reply = channel.Request(request);
	   Console.Out.WriteLine(reply.Headers.Action);
	   reply.Close();
	   channel.Close();
	   factory.Close();
	   // </Snippet29>
       }


       public static void Snippet31()
       {

	       CustomBinding binding = new CustomBinding();
	       binding.Elements.Add(new HttpTransportBindingElement());
	       Object[] bindingParams = new Object[2];

	    // <Snippet31>
	       
	       EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
	       IRequestChannel channel = ChannelFactory<IRequestChannel>.CreateChannel(binding, address);
	       channel.Open();
	    // </Snippet31>

	       Message request = Message.CreateMessage(MessageVersion.Default, "hello");
	       Message reply = channel.Request(request);
	       Console.Out.WriteLine(reply.Headers.Action);
	       reply.Close();
	       channel.Close();
       }

 

       public static void Snippet33()
       {

	       CustomBinding binding = new CustomBinding();
	       binding.Elements.Add(new HttpTransportBindingElement());
	       Object[] bindingParams = new Object[2];

	    // <Snippet33>

	       EndpointAddress address = new EndpointAddress("http://localhost:8000/ChannelApp");
	       Uri uri = new Uri("http://localhost:8000/Via");

	       IRequestChannel channel =
		  ChannelFactory<IRequestChannel>.CreateChannel(binding, address, uri);
	       channel.Open();
	    // </Snippet33>

	       Message request = Message.CreateMessage(MessageVersion.Default, "hello");
	       Message reply = channel.Request(request);
	       Console.Out.WriteLine(reply.Headers.Action);
	       reply.Close();
	       channel.Close();
       }


    }
}
