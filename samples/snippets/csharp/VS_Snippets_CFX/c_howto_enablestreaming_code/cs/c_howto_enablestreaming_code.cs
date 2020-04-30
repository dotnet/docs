//<snippet0>
//<snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Security.Permissions;
//</snippet1>
namespace Samples
{
    public sealed class EnableStreaming
    {
        private EnableStreaming() { }

        //<snippet2>
        public static Binding CreateStreamingBinding()
        {
            BasicHttpBinding b = new BasicHttpBinding();
            b.TransferMode = TransferMode.Streamed;
            return b;
        }
        //</snippet2>
    }
    public sealed class EnableStreamingCustom
    {
        private EnableStreamingCustom() { }

        //<snippet3>
        public static Binding CreateStreamingBinding()
        {
            TcpTransportBindingElement transport = new TcpTransportBindingElement();
            transport.TransferMode = TransferMode.Streamed;
            BinaryMessageEncodingBindingElement encoder = new BinaryMessageEncodingBindingElement();
            CustomBinding binding = new CustomBinding(encoder, transport);
            return binding;
        }
        //</snippet3>
    }
}
//</snippet0>
