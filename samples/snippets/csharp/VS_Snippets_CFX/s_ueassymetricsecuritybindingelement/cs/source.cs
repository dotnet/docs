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
            //<snippet5>
            //<snippet4>
            //<snippet3>
            //<snippet2>
            AsymmetricSecurityBindingElement abe =
                (AsymmetricSecurityBindingElement)SecurityBindingElement.
                CreateMutualCertificateBindingElement(
                MessageSecurityVersion.
                WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10);
            //</snippet2>

            abe.SetKeyDerivation(false);
            //</snippet3>
            
            X509SecurityTokenParameters istp =
               abe.InitiatorTokenParameters as X509SecurityTokenParameters;
            if (istp != null)
            {
                istp.X509ReferenceStyle =
                X509KeyIdentifierClauseType.IssuerSerial;
            }
            //</snippet4>
            X509SecurityTokenParameters rstp =
            abe.RecipientTokenParameters as X509SecurityTokenParameters;
            if (rstp != null)
            {
                rstp.X509ReferenceStyle =
                X509KeyIdentifierClauseType.IssuerSerial;
            }
            //</snippet5>

            HttpTransportBindingElement transport = 
                new HttpTransportBindingElement();
 
            return new CustomBinding(abe, transport);
        }
        //</snippet1>
    }
}