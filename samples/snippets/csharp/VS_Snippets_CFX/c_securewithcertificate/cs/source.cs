//<snippet0>
using System;
using System.ServiceModel;
using System.Net.Security;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;
//</snippet0>

namespace Samples1
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface ICalculator
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        double Add(double a, double b);
    }
    [MessageContract(ProtectionLevel = ProtectionLevel.Sign)]

    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
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
                Console.ReadLine();
            }

            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();
            }
        }

        private void Run()
        {
            //<snippet9>
            //<snippet1>
            // Create a binding and set the security mode to Message.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            //</snippet1>

            //<snippet2>
            Type contractType = typeof(ICalculator);
            Type implementedContract = typeof(Calculator);
            //</snippet2>

            //<snippet3>
            Uri baseAddress = new Uri("http://localhost:8044/base");
            //</snippet3>

            //<snippet4>
            ServiceHost sh = new ServiceHost(implementedContract, baseAddress);
            //</snippet4>

            //<snippet5>
            sh.AddServiceEndpoint(contractType, b, "Calculator");
            //</snippet5>

            //<snippet6>
            ServiceMetadataBehavior sm = new ServiceMetadataBehavior();
            sm.HttpGetEnabled = true;
            sh.Description.Behaviors.Add(sm);
            //</snippet6>

            //<snippet7>
            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine ,StoreName.My,
                X509FindType.FindBySubjectName ,"localhost");
            //</snippet7>

            //<snippet8>
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            //</snippet8>
            sh.Close();
            //</snippet9>
        }
    }
}
