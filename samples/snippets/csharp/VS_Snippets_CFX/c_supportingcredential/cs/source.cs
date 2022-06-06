//<snippet0>
using System.Security.Permissions;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.IO;
using System.IdentityModel.Claims;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;
//</snippet0>

namespace Samples
{
    public class Test
    {
        static void Main()
        {
            try
            {
                Test t = new Test();
                t.CreateSecurityBindingElement();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private SecurityBindingElement CreateSecurityBindingElement()
        {
            // Create an issued token parameters object.
            IssuedSecurityTokenParameters issuedSecTok =
                new IssuedSecurityTokenParameters();

            // Create a security binding element with the parameter object.
            SymmetricSecurityBindingElement secBindingEle =
                SecurityBindingElement.CreateIssuedTokenBindingElement(issuedSecTok);

            // Create a Kerberos token parameter object and set the inclusion
            // mode to AlwaysToRecipient. Add the object as an endorsing token for
            // all operations of the endpoint.
            KerberosSecurityTokenParameters kstp = new KerberosSecurityTokenParameters();
            kstp.InclusionMode = SecurityTokenInclusionMode.AlwaysToRecipient;
            secBindingEle.EndpointSupportingTokenParameters.Endorsing.Add(kstp);

            // Create a username token parameter object and set its
            // RequireDerivedKeys to false.
            UserNameSecurityTokenParameters userNameParams =
                new UserNameSecurityTokenParameters();
            userNameParams.RequireDerivedKeys = false;

            // Create a collection object for supporting tokens.
            SupportingTokenParameters stp = new SupportingTokenParameters();

            // Add the previously created supporting tokens.
            stp.Endorsing.Add(issuedSecTok);
            stp.SignedEncrypted.Add(userNameParams);

            // Create a generic dictionary item, a KeyValuePair object
            // that includes all supporting token parameters. Then add
            // it to the dictionary for operation-scope supporting tokens.
            KeyValuePair<string, SupportingTokenParameters> x =
                new KeyValuePair<string, SupportingTokenParameters>("1", stp);
            secBindingEle.OperationSupportingTokenParameters.Add(x);

            // See all dictionary items for the supporting tokens.
            Console.WriteLine("Reading Kevalue pairs");
            foreach (KeyValuePair<string, SupportingTokenParameters> kvp
                in secBindingEle.OperationSupportingTokenParameters)
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }

            Console.ReadLine();

            return secBindingEle;
        }

        //<snippet1>
        public static Binding CreateMultiFactorAuthenticationBinding()
        {
            HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();

            // The message security binding element will be configured to require 2 tokens:
            // 1) A user name/password encrypted with the service token.
            // 2) A client certificate used to sign the message.

            // Instantiate a binding element that will require the user name/password token
            // in the message (encrypted with the server certificate).
            SymmetricSecurityBindingElement messageSecurity = SecurityBindingElement.CreateUserNameForCertificateBindingElement();

            // Create supporting token parameters for the client X.509 certificate.
            X509SecurityTokenParameters clientX509SupportingTokenParameters = new X509SecurityTokenParameters();
            // Specify that the supporting token is passed in the message send by the client to the service.
            clientX509SupportingTokenParameters.InclusionMode = SecurityTokenInclusionMode.AlwaysToRecipient;
            // Turn off derived keys.
            clientX509SupportingTokenParameters.RequireDerivedKeys = false;
            // Augment the binding element to require the client's X.509 certificate as an
            // endorsing token in the message.
            messageSecurity.EndpointSupportingTokenParameters.Endorsing.Add(clientX509SupportingTokenParameters);

            // Create a CustomBinding based on the constructed security binding element.
            return new CustomBinding(messageSecurity, httpTransport);
        }
        //</snippet1>

        private void AuthenticateWithUserName()
        {
            //<snippet2>
            CalculatorClient client = new CalculatorClient("default");
            //</snippet2>

            //<snippet3>
            client.ClientCredentials.UserName.Password = ReturnPassword();
            //</snippet3>

            //<snippet4>
            client.ClientCredentials.UserName.UserName = ReturnUsername();
            //</snippet4>

            //<snippet5>
            double value1 = client.Add(100, 15.99);
            //</snippet5>

            //<snippet6>
            client.Close();
            //</snippet6>
        }

        private string ReturnUsername()
        {
            return "hah";
        }

        private string ReturnPassword()
        {
            return "hah";
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute()]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/Divide", ReplyAction = "http://tempuri.org/ICalculator/DivideResponse")]
        double Divide(double a, double b);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/CalculateTax", ReplyAction = "http://tempuri.org/ICalculator/CalculateTaxResponse")]
        double Add(double a, double b);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
    {
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
    {

        public CalculatorClient()
        {
        }

        public CalculatorClient(string endpointConfigurationName)
            :
                base(endpointConfigurationName)
        {
        }

        public CalculatorClient(string endpointConfigurationName, string remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(binding, remoteAddress)
        {
        }

        public double Divide(double a, double b)
        {
            return base.Channel.Divide(a, b);
        }

        public double Add(double a, double b)
        {
            return base.Channel.Add(a, b);
        }
    }
}
