using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;


namespace Examples
{
    public class Program
    {
        static void Main()
        {
            //<snippet1>
            Uri baseAddress = new Uri("http://cohowinery.com/services");
            ServiceHost sh = new ServiceHost(typeof(CalculatorService), baseAddress );
            sh.Credentials.ServiceCertificate.SetCertificate(
            StoreLocation.LocalMachine, StoreName.My,
            X509FindType.FindBySubjectName, "cohowinery.com");
            //</snippet1>
        }
    }

    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int a, int b);
    }

    public class CalculatorService : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
