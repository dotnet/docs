//<snippet0>
//<snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
//</snippet1>

namespace Samples
{
    public sealed class CustomBindingCreator
    {
        //<snippet2>
        // This method creates a CustomBinding based on a WSFederationHttpBinding which does not use secure conversation.
        public static CustomBinding CreateFederationBindingWithoutSecureSession(WSFederationHttpBinding inputBinding)
        {
            // This CustomBinding starts out identical to the specified WSFederationHttpBinding.
            CustomBinding outputBinding = new CustomBinding(inputBinding.CreateBindingElements());
            // Find the SecurityBindingElement for message security.
            SecurityBindingElement security = outputBinding.Elements.Find<SecurityBindingElement>();
            // If the security mode is message, then the secure session settings are the protection token parameters.
            SecureConversationSecurityTokenParameters secureConversation;
            if (WSFederationHttpSecurityMode.Message == inputBinding.Security.Mode)
            {
                SymmetricSecurityBindingElement symmetricSecurity = security as SymmetricSecurityBindingElement;
                secureConversation = symmetricSecurity.ProtectionTokenParameters as SecureConversationSecurityTokenParameters;
            }
            // If the security mode is message, then the secure session settings are the endorsing token parameters.
            else if (WSFederationHttpSecurityMode.TransportWithMessageCredential == inputBinding.Security.Mode)
            {
                TransportSecurityBindingElement transportSecurity = security as TransportSecurityBindingElement;
                secureConversation = transportSecurity.EndpointSupportingTokenParameters.Endorsing[0] as SecureConversationSecurityTokenParameters;
            }
            else
            {
                throw new NotSupportedException(String.Format("Unhandled security mode {0}.", inputBinding.Security.Mode));
            }
            // Replace the secure session SecurityBindingElement with the bootstrap SecurityBindingElement.
            int securityIndex = outputBinding.Elements.IndexOf(security);
            outputBinding.Elements[securityIndex] = secureConversation.BootstrapSecurityBindingElement;
            // Return modified binding.
            return outputBinding;
        }
        //</snippet2>
        // It is a good practice to create a private constructor for a class that only
        // defines static methods.
        private CustomBindingCreator() { }
        static void Main()
        {
            // Code not shown.
        }
    }
    //</snippet0>
}
