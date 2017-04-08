// Snippet for S_UENamedPipeTransportBindingElement.
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Security;
using System.Text;
using System.Xml;

namespace Snippets
{
    class Snippet
    {

        static void Main()
        {
            // protected
            // NamedPipeTransportBindingElement bElementClone =
            //  new NamedPipeTransportBindingElement(bElement); 

            // <Snippet3>
            // <Snippet2>
            // <Snippet0>
            // <Snippet1>
            NamedPipeTransportBindingElement bElement =
                new NamedPipeTransportBindingElement();
            // </Snippet1>

            NamedPipeConnectionPoolSettings connectionPoolSettings =
                bElement.ConnectionPoolSettings;
            // </Snippet0>
            // </Snippet2>
            // </Snippet3>

            // <Snippet4>
            string scheme = 
                bElement.Scheme;
            // </Snippet4>

            // <Snippet5>
            BindingElement bElementCopy =
                bElement.Clone();
            // </Snippet5>

            // <Snippet8>
            BasicHttpBinding binding = new BasicHttpBinding();
            ISecurityCapabilities b =
                binding.GetProperty<ISecurityCapabilities>
                (new BindingParameterCollection());

            bool SupportsServerAuthentication =
                b.SupportsServerAuthentication;
            // </Snippet8>

        }

        static void RunClient()
        {
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new NamedPipeTransportBindingElement());
            CustomBinding customBinding = new CustomBinding();
            BindingParameterCollection bpCollection =
                new BindingParameterCollection();

            // <Snippet6>
            BindingContext bContext = new BindingContext(customBinding, bpCollection);
            IChannelFactory<IOutputChannel> factory =
                binding.BuildChannelFactory<IOutputChannel>(bContext);
            // </Snippet6>

            // <Snippet7>
            IChannelListener<IOutputChannel> listener =
                binding.BuildChannelListener<IOutputChannel>(bContext);
            // </Snippet7>

        }

    }

}
