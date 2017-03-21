            SecurityBindingElement security = SecurityBindingElement.CreateMutualCertificateBindingElement();

            // Use a secure session.
            security = SecurityBindingElement.CreateSecureConversationBindingElement(security, true);

            // Specify whether derived keys are required.
            security.SetKeyDerivation(true);