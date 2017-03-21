            SymmetricSecurityBindingElement b =
                SecurityBindingElement.
                CreateAnonymousForCertificateBindingElement();

            BindingElementCollection outputBindings = 
                new BindingElementCollection();
            
            b.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128;
            b.MessageProtectionOrder = 
                MessageProtectionOrder.SignBeforeEncrypt;
            b.ProtectionTokenParameters = 
                new KerberosSecurityTokenParameters();