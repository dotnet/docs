//<snippet0>
using System;
using System.ServiceModel;
using System.Net.Security;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;
//</snippet0>

namespace Microsoft.WCF.Samples1
{
    //<snippet2>
    //<snippet1>
    // Set the ProtectionLevel on the whole service to Sign.
    [ServiceContract(ProtectionLevel = ProtectionLevel.Sign)]
    public interface ICalculator
    //</snippet1>
    {
        // Set the ProtectionLevel on this operation to None.
        [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        double Add(double a, double b);
    }
    //</snippet2>
}
namespace Samples2
{
    //<snippet3>
    [DataContract]
    public class MathFault
    {
        [DataMember]
        public string operation;
        [DataMember]
        public string description;
    }
    //</snippet3>

    //<snippet4>
    public interface ICalculator
    {
        // Set the ProtectionLevel on a FaultContractAttribute.
        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        [FaultContract(
            typeof(MathFault),
            Action = @"http://localhost/Add",
            Name = "AddFault",
            Namespace = "http://contoso.com",
            ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        double Add(double a, double b);
    }
    //</snippet4>
}
namespace Samples3
{
    //<snippet6>
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface ICalculator
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        double Add(double a, double b);

        [OperationContract()]
        [FaultContract(typeof(MathFault),
            ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        double Subtract(double a, double b);

        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        Company GetCompanyInfo();
    }

    [DataContract]
    public class MathFault
    {
        [DataMember]
        public string operation;
        [DataMember]
        public string description;
    }

    //<snippet5>
    [MessageContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public class Company
    {
        [MessageHeader(ProtectionLevel = ProtectionLevel.Sign)]
        public string CompanyName;

        [MessageBodyMember(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        public string CompanyID;
    }
    //</snippet5>

    [MessageContract(ProtectionLevel = ProtectionLevel.Sign)]
    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public Company GetCompanyInfo()
        {
            Company co = new Company();
            co.CompanyName = "www.cohowinery.com";
            return co;
        }
    }

    public class Test
    {
        static void Main()
        {
            Test t = new Test();
            try
            {
                t.Run();
            }
            catch (System.InvalidOperationException inv)
            {
                Console.WriteLine(inv.Message);
            }
        }

        private void Run()
        {
            // Create a binding and set the security mode to Message.
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.Message;

            Type contractType = typeof(ICalculator);
            Type implementedContract = typeof(Calculator);
            Uri baseAddress = new Uri("http://localhost:8044/base");

            // Create the ServiceHost and add an endpoint.
            ServiceHost sh = new ServiceHost(implementedContract, baseAddress);
            sh.AddServiceEndpoint(contractType, b, "Calculator");

            ServiceMetadataBehavior sm = new ServiceMetadataBehavior();
            sm.HttpGetEnabled = true;
            sh.Description.Behaviors.Add(sm);
            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindByIssuerName,
                "ValidCertificateIssuer");

            foreach (ServiceEndpoint se in sh.Description.Endpoints)
            {
                ContractDescription cd = se.Contract;
                Console.WriteLine($"\nContractDescription: ProtectionLevel = {cd.Name}");
                foreach (OperationDescription od in cd.Operations)
                {
                    Console.WriteLine($"\nOperationDescription: Name = {od.Name}");
                    Console.WriteLine($"ProtectionLevel = {od.ProtectionLevel}");
                    foreach (MessageDescription m in od.Messages)
                    {
                        Console.WriteLine($"\t {m.Action}: {m.ProtectionLevel}");
                        foreach (MessageHeaderDescription mh in m.Headers)
                        {
                            Console.WriteLine($"\t\t {mh.Name}: {mh.ProtectionLevel}");

                            foreach (MessagePropertyDescription mp in m.Properties)
                            {
                                Console.WriteLine($"{mp.Name}: {mp.ProtectionLevel}");
                            }
                        }
                    }
                }
            }
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            sh.Close();
        }
    }
    //</snippet6>

    //<snippet7>
    [ServiceContract()]
    public interface IPurchaseOrder
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        int Price();
    }
    //</snippet7>
    namespace NewIPurchaseOrder
    {
        //<snippet8>
        [ServiceContract()]
        public interface IPurchaseOrder
        {
            [OperationContract()]
            int Tax();

            [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
            int Price();
        }
        //</snippet8>
    }
}
