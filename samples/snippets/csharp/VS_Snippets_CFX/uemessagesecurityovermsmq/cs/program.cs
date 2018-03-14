using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace UEMessageSecurityOverMsmq
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            NetMsmqBinding binding = new NetMsmqBinding();
            NetMsmqSecurity security = binding.Security;
            MessageSecurityOverMsmq msOverMsmq = security.Message;
            // </Snippet1>

            // <Snippet2>
            msOverMsmq.AlgorithmSuite = SecurityAlgorithmSuite.Basic128;
            // </Snippet2>

            // <Snippet3>
            msOverMsmq.ClientCredentialType = MessageCredentialType.Certificate;
            // </Snippet3>
        }
    }
}
