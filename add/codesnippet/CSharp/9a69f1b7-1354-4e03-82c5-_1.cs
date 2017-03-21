            // Create a SymmetricSecurityBindingElement.
            SymmetricSecurityBindingElement ssbe = 
                new SymmetricSecurityBindingElement();

            // Set the algorithm suite to one that uses 128-bit keys.
            ssbe.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128;

               // Set MessageProtectionOrder to SignBeforeEncrypt.
            ssbe.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt;