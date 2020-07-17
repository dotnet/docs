using System;
using System.ServiceModel;

namespace Samples
{

    //<snippet1>
    [ServiceContract]
    interface IMyService
    {

       //Define the contract operations.
    }

    class MyService : IMyService
    {

    //Implement the IMyService operations.
    }
    //</snippet1>

    public class Test
    {
        public static void Main()
        {
        }

	private void CreateNetTcpBinding()
        {
            //<snippet2>
            NetTcpBinding portsharingBinding = new NetTcpBinding();
            portsharingBinding.PortSharingEnabled = true;
            //</snippet2>
            //<snippet3>
            ServiceHost host = new ServiceHost( typeof( MyService ) );
            host.AddServiceEndpoint( typeof( IMyService ), portsharingBinding,"net.tcp://localhost/MyService" );

            //</snippet3>
        }

        private void EnablePortSharing()
        {
        }
    }
}
