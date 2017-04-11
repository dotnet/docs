using System;
using System.ServiceModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;



namespace Samples
{

    [ServiceContract]
    interface ICalculator
    {
	[OperationContract]
	int Add(int x, int y);
    }


    //<snippet1>
    [ServiceContract]
    interface IMyService {

    //Define the contract operations.

    }

    class MyService : IMyService {

    //Implement the IMyService operations.

    }
    //</snippet1>


    public class Test0
    {
        public static void Main()
        {
        }

        private void CreateNetTcpBinding()
        {
            //<snippet4>
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Message;
            Type c = typeof(ICalculator);
            Uri a = new Uri("net.tcp://MyMachineName/tcpBase");
            Uri[] baseAddresses = new Uri[] { a };
            ServiceHost sh = new ServiceHost(typeof(MyService), baseAddresses);
            sh.AddServiceEndpoint(c, b, "Aloha");
            sh.Credentials.ServiceCertificate.SetCertificate(
                "CN=Administrator,CN=Users,DC=johndoe,DC=nttest,DC=microsoft,DC=com");
            sh.Open();

            //</snippet4>
        }

    }
    public class Test1
    {
        public static void Main()
        {
        }

        private void CreateNetTcpBinding()
        {
            //<snippet5>
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Message;
            Type c = typeof(ICalculator);
            Uri a = new Uri("net.tcp://MyMachineName/tcpBase");
            Uri[] baseAddresses = new Uri[] { a };
            ServiceHost sh = new ServiceHost(typeof(MyService), baseAddresses);
            sh.AddServiceEndpoint(c, b, "Aloha");
            sh.Credentials.ServiceCertificate.SetCertificate(
                "CN=Administrator,CN=Users,DC=johndoe,DC=nttest,DC=microsoft,DC=com",
                StoreLocation.LocalMachine,
                StoreName.My);
            sh.Open();
            //</snippet5>
        }

    }
    public class Test
    {
        public static void Main()
        {
        }

	private void CreateNetTcpBinding()
        {
            //<snippet2>
	    NetTcpBinding b = new NetTcpBinding();
	    b.Security.Mode = SecurityMode.Message;
	    Type c = typeof(ICalculator);
	    Uri a = new Uri("net.tcp://MyMachineName/tcpBase");
	    Uri[] baseAddresses = new Uri[] { a };
	    ServiceHost sh = new ServiceHost(typeof(MyService), baseAddresses);
	    sh.AddServiceEndpoint(c, b, "Aloha");
	    sh.Credentials.ServiceCertificate.SetCertificate(
		    StoreLocation.LocalMachine,
		    StoreName.My,
		    X509FindType.FindByThumbprint,
		    "af1f50b20cd413ed9cd00c315bbb6dc1c08da5e6");
	    sh.Open();
	    
            //</snippet2>
        }
    }
    public class Test6
    {
        public static void Main()
        {
        }

	private void CreateNetTcpBinding()
        {
        //<snippet7>
        //<snippet6>
	    NetTcpBinding b = new NetTcpBinding();
	    b.Security.Mode = SecurityMode.Message;
	    Type c = typeof(ICalculator);
	    Uri a = new Uri("net.tcp://MyMachineName/tcpBase");
	    Uri[] baseAddresses = new Uri[] { a };
	    ServiceHost sh = new ServiceHost(typeof(MyService), baseAddresses);
	    sh.AddServiceEndpoint(c, b, "Aloha");
	    sh.Credentials.ServiceCertificate.SetCertificate(
		    StoreLocation.LocalMachine,
		    StoreName.My,
		    X509FindType.FindByThumbprint,
		    "af1f50b20cd413ed9cd00c315bbb6dc1c08da5e6");
	    sh.Open();
        //</snippet6>
        X509Certificate2 cert = sh.Credentials.ServiceCertificate.Certificate;
        //</snippet7>
        }
    }
}
