//<snippet0>
//<snippet1>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
//</snippet1>

namespace Samples
{
    public sealed class CustomBindingCreator
    {
	    private CustomBindingCreator(){}

        //<snippet2>
        // This method creates a CustomBinding using a SymmetricSecurityBindingElement.
        // It is largely equivalent to doing the following:

            // WSHttpBinding b = new WSHttpBinding ( SecurityMode.Message );
            // b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            // b.Security.Message.NegotiateServiceCredential = false;
            // b.Security.Message.EstablishSecureSession = false;

	    // It differs in that it uses MessageProtectionOrder.SignBeforeEncrypt rather
        // than MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature.
        //<snippet3>
        public static Binding CreateCustomBinding()
        {
            // Create an empty BindingElementCollection to populate,
            // then create a custom binding from it.
            BindingElementCollection outputBec = new BindingElementCollection();

            // <snippet6>
            // <snippet5>
            // <snippet4>
            // Create a SymmetricSecurityBindingElement.
            SymmetricSecurityBindingElement ssbe =
                new SymmetricSecurityBindingElement();
            // </snippet4>

            // Set the algorithm suite to one that uses 128-bit keys.
            ssbe.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128;

               // Set MessageProtectionOrder to SignBeforeEncrypt.
            ssbe.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt;
            // </snippet5>

            // Use a Kerberos token as the protection token.
            ssbe.ProtectionTokenParameters = new KerberosSecurityTokenParameters();
            // </snippet6>

            // Add the SymmetricSecurityBindingElement to the BindingElementCollection.
            outputBec.Add ( ssbe );
            outputBec.Add(new TextMessageEncodingBindingElement());
            outputBec.Add(new HttpTransportBindingElement());

            // Create a CustomBinding and return it; otherwise, return null.
            return new CustomBinding(outputBec);
        }
        //</snippet3>
        //</snippet2>
    }

    public class CustomBindingCreator2
    {
        private CustomBindingCreator2() { }

        public static Binding CreateCustomBinding()
        {
            //<snippet20>
            // Create an empty CustomBinding to populate
            CustomBinding binding = new CustomBinding();
            // Create a SymmetricSecurityBindingElement.
            SymmetricSecurityBindingElement ssbe =
                SecurityBindingElement.CreateSspiNegotiationBindingElement(true);
            // Add the SymmetricSecurityBindingElement to the BindingElementCollection.
            binding.Elements.Add(ssbe);
            binding.Elements.Add(new TextMessageEncodingBindingElement());
            binding.Elements.Add(new HttpTransportBindingElement());
            return new CustomBinding(binding);
            //</snippet20>
        }
    }

    public class MultipleTokensBinding
    {
        private MultipleTokensBinding() { }

        //<snippet7>
        // This method creates a CustomBinding that includes two tokens of a given type.
        //<snippet8>
        public static Binding CreateCustomBinding(EndpointAddress issuerEndpointAddress1, Binding issuerBinding1, EndpointAddress issuerEndpointAddress2, Binding issuerBinding2)
        {
            //<snippet9>
            // Create an empty BindingElementCollection to populate,
            // then create a custom binding from it.
            BindingElementCollection bec = new BindingElementCollection();
            //</snippet9>

            //<snippet10>
            SecurityBindingElement sbe = SecurityBindingElement.CreateMutualCertificateBindingElement();
            //</snippet10>

            //<snippet11>
            SupportingTokenParameters supportParams = new SupportingTokenParameters();
            //</snippet11>

            //<snippet12>
            // Two supporting SAML tokens are being added.
            supportParams.SignedEndorsing.Add(new IssuedSecurityTokenParameters("samlTokenType", issuerEndpointAddress1, issuerBinding1));
            supportParams.SignedEndorsing.Add(new IssuedSecurityTokenParameters("samlTokenType", issuerEndpointAddress2, issuerBinding2));
            //</snippet12>

            //<snippet13>
            ((SymmetricSecurityBindingElement)sbe).OperationSupportingTokenParameters.Add("*", supportParams);
            //</snippet13>

            //<snippet14>
            bec.Add(sbe);
            bec.Add(new TextMessageEncodingBindingElement());
            bec.Add(new HttpTransportBindingElement());
            //</snippet14>

            //<snippet15>
            // Create a CustomBinding and return it; otherwise, return null.
            return new CustomBinding(bec);
            //</snippet15>
        }
        //</snippet8>
        //</snippet7>
    }
}
//</snippet0>
