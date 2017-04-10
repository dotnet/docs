using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace UEMessageSecurityMsmq
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            NetMsmqBinding binding = new NetMsmqBinding();
            NetMsmqSecurity security = binding.Security;
            // </Snippet1>

            // <Snippet2>
            MessageSecurityOverMsmq msgSecurity = security.Message;
            // </Snippet2>

            // <Snippet3>
            NetMsmqSecurityMode secMode = security.Mode;
            // </Snippet3>

            // <Snippet4>
            MsmqTransportSecurity trnsSecurity = security.Transport;
            // </Snippet4>

        }
    }
}
