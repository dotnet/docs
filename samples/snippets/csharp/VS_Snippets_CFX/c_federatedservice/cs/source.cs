//<snippet0>
//<snippet1>
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Security.Permissions;
namespace Samples
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

  //</snippet1>
  public sealed class IssuedTokenServiceCredentialsConfiguration
  {
	//<snippet2>
	// This method configures the IssuedTokenAuthentication property of a ServiceHost.
	public static void ConfigureIssuedTokenServiceCredentials(
        ServiceHost sh, bool allowCardspaceTokens, IList<X509Certificate2> knownissuers,
        X509CertificateValidationMode certMode, X509RevocationMode revocationMode, SamlSerializer ser )
	{
	  // Allow CardSpace tokens.
	  sh.Credentials.IssuedTokenAuthentication.AllowUntrustedRsaIssuers = allowCardspaceTokens;
	
	  // Set up known issuer certificates.
	  foreach(X509Certificate2 cert in knownissuers)
		sh.Credentials.IssuedTokenAuthentication.KnownCertificates.Add ( cert );

	  // Set issuer certificate validation and revocation checking modes.
	  sh.Credentials.IssuedTokenAuthentication.CertificateValidationMode =
          X509CertificateValidationMode.PeerOrChainTrust;
      sh.Credentials.IssuedTokenAuthentication.RevocationMode = X509RevocationMode.Online;
      sh.Credentials.IssuedTokenAuthentication.TrustedStoreLocation = StoreLocation.LocalMachine;

	  // Set the SamlSerializer, if one is specified.
	  if ( ser != null )
		sh.Credentials.IssuedTokenAuthentication.SamlSerializer = ser;
	}
	//</snippet2>
	
	// It is a good practice to create a private constructor for a class that only
	// defines static methods.
	private IssuedTokenServiceCredentialsConfiguration() { }
	}

    class Program
    {
        static void Main()
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                //<snippet5>
                serviceHost.Credentials.ClientCertificate.Authentication.CertificateValidationMode =
                    X509CertificateValidationMode.Custom;
                serviceHost.Credentials.ClientCertificate.Authentication.CustomCertificateValidator =
                    new MyX509CertificateValidator("CN=Contoso.com");
                //</snippet5>

                serviceHost.Open();
                Console.WriteLine("Service started, press ENTER to stop ...");
                Console.ReadLine();

                serviceHost.Close();
            }
        }
    }

    //<snippet4>
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
    //</snippet4>

  //</snippet0>
}
