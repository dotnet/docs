using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace WebServiceHostFactorySnippets
{
    public class MyWebServiceHostFactory : WebServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type t, Uri[] baseAddresses)
        {
            return new MyWebServiceHost(t, baseAddresses);
        }
    }

    public class MyWebServiceHost : WebServiceHost
    {
        public MyWebServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses) {}
    }
}
