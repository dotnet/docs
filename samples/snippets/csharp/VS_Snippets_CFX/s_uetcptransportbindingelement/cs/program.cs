// Snippet for S_UETcpTransportBindingElement
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
            // <Snippet3>
            // <Snippet0>
            // <Snippet1>
            TcpTransportBindingElement bElement =
                new TcpTransportBindingElement();
            // </Snippet1>

            TcpConnectionPoolSettings connectionPoolSettings =
                bElement.ConnectionPoolSettings;
            // </Snippet0>
            // </Snippet3>

            // <Snippet4>
            int listenBacklog = bElement.ListenBacklog;
            // </Snippet4>

            // <Snippet5>
            bool portSharingEnabled = bElement.PortSharingEnabled;
            // </Snippet5>

            // <Snippet6>
            string scheme = bElement.Scheme;
            // </Snippet6>

            // <Snippet7>
            bool teredoEnabled = bElement.TeredoEnabled;
            // </Snippet7>

            // <Snippet8>
            BindingElement bElementClone = bElement.Clone();
            // </Snippet8>

            // <Snippet11>
            BasicHttpBinding binding = new BasicHttpBinding();
            ISecurityCapabilities b =
                binding.GetProperty<ISecurityCapabilities>
                (new BindingParameterCollection());

            bool SupportsServerAuthentication =
                b.SupportsServerAuthentication;
            // </Snippet11>

        }

        static void RunClient()
        {
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new TcpTransportBindingElement());
            CustomBinding customBinding = new CustomBinding();
            BindingParameterCollection bpCollection =
                new BindingParameterCollection();

            // <Snippet9>
            BindingContext bContext = new BindingContext(customBinding, bpCollection);
            IChannelFactory<IOutputChannel> factory =
                binding.BuildChannelFactory<IOutputChannel>(bContext);
            // </Snippet9>

            // <Snippet10>
            IChannelListener<IOutputChannel> listener =
                binding.BuildChannelListener<IOutputChannel>(bContext);
            // </Snippet10>

        }

    }

}
