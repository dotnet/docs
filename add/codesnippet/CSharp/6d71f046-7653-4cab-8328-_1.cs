            AsymmetricSecurityBindingElement abe =
                (AsymmetricSecurityBindingElement)SecurityBindingElement.
                CreateMutualCertificateBindingElement(
                MessageSecurityVersion.
                WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10);

            abe.SetKeyDerivation(false);