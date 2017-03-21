            SecurityBindingElement security = SecurityBindingElement.CreateMutualCertificateBindingElement();

            // Use a secure session.
            security = SecurityBindingElement.CreateSecureConversationBindingElement(security, true);