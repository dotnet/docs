using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet0>
            // <Snippet1>
            var be = new BinaryMessageEncodingBindingElement();
            // </Snippet1>
            // <Snippet2>
            be.MaxReadPoolSize = 16;
            // </Snippet2>
            // <Snippet3>
            be.MaxSessionSize = 2048;
            // </Snippet3>
            // <Snippet4>
            be.MaxWritePoolSize = 16;
            // </Snippet4>
            // <Snippet5>
            be.MessageVersion = MessageVersion.Default;
            // </Snippet5>
            // <Snippet6>
            XmlDictionaryReaderQuotas quotas = be.ReaderQuotas;
            // </Snippet6>

            // <Snippet7>
            var binding = new CustomBinding();
            var bpCol = new BindingParameterCollection();
            var context = new BindingContext(binding, bpCol);
            be.BuildChannelFactory<IDuplexChannel>(context);
            // </Snippet7>

            // <Snippet8>
            var binding2 = new CustomBinding();
            var bpCol2 = new BindingParameterCollection();
            var context2 = new BindingContext(binding2, bpCol2);
            be.BuildChannelListener<IDuplexChannel>(context2);
            // </Snippet8>

            // <Snippet9>
            be.CanBuildChannelListener<IDuplexChannel>(context2);
            // </Snippet9>
            // <Snippet10>
            BindingElement bindingElement = be.Clone();
            // </Snippet10>
            // <Snippet11>
            MessageEncoderFactory mef = be.CreateMessageEncoderFactory();
            // </Snippet11>
            // <Snippet12>
            MessageVersion mv = be.GetProperty<MessageVersion>(context);
            // </Snippet12>
            // </Snippet0>
        }
    }
}
