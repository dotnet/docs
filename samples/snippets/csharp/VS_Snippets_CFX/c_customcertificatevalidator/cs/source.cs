//<snippet3>
using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
    }

    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                //<snippet1>
                serviceHost.Credentials.ClientCertificate.Authentication.CertificateValidationMode =
                    X509CertificateValidationMode.Custom;
                serviceHost.Credentials.ClientCertificate.Authentication.CustomCertificateValidator =
                    new MyX509CertificateValidator("CN=Contoso.com");
                //</snippet1>

                serviceHost.Open();
                Console.WriteLine("Service started, press ENTER to stop ...");
                Console.ReadLine();

                serviceHost.Close();
            }
        }
    }

    //<snippet2>
    public class MyX509CertificateValidator : X509CertificateValidator
    {
        string allowedIssuerName;

        public MyX509CertificateValidator(string allowedIssuerName)
        {
            if (allowedIssuerName == null)
            {
                throw new ArgumentNullException("allowedIssuerName");
            }

            this.allowedIssuerName = allowedIssuerName;
        }

        public override void Validate(X509Certificate2 certificate)
        {
            // Check that there is a certificate.
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate");
            }

            // Check that the certificate issuer matches the configured issuer.
            if (allowedIssuerName != certificate.IssuerName.Name)
            {
                throw new SecurityTokenValidationException
                  ("Certificate was not issued by a trusted issuer");
            }
        }
    }
    //</snippet2>
}
//</snippet3>
