using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
namespace HowToReferenceCertificates
{
    public class Test
    {
        static void Main()
        { }

        //<snippet1>
        public Binding CreateClientBinding()
        {
            AsymmetricSecurityBindingElement abe =
                (AsymmetricSecurityBindingElement)SecurityBindingElement.
                CreateMutualCertificateBindingElement(
                MessageSecurityVersion.
                WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10);

            abe.SetKeyDerivation(false);

            X509SecurityTokenParameters istp =
               abe.InitiatorTokenParameters as X509SecurityTokenParameters;
            if (istp != null)
            {
                istp.X509ReferenceStyle =
                X509KeyIdentifierClauseType.IssuerSerial;
            }
            X509SecurityTokenParameters rstp =
            abe.RecipientTokenParameters as X509SecurityTokenParameters;
            if (rstp != null)
            {
                rstp.X509ReferenceStyle =
                X509KeyIdentifierClauseType.IssuerSerial;
            }

            HttpTransportBindingElement transport =
                new HttpTransportBindingElement();

            return new CustomBinding(abe, transport);
        }
        //</snippet1>
    }
}