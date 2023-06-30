using System;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Security.Permissions;

namespace Microsoft.Samples
{
    public class test
    {
        static void Main()
        {
            Console.WriteLine("Starting");
        }
    }

    //<snippet1>
    class MyAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            // Allow MEX requests through.
            if (operationContext.EndpointDispatcher.ContractName == ServiceMetadataBehavior.MexContractName &&
                operationContext.EndpointDispatcher.ContractNamespace == "http://schemas.microsoft.com/2006/04/mex" &&
                operationContext.IncomingMessageHeaders.Action == "http://schemas.xmlsoap.org/ws/2004/09/transfer/Get")
                return true;
            // Code not shown: Perform authorization checks for non-MEX requests
            return false;
        }
    }
    //</snippet1>
}
