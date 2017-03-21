        public static Binding CreateCustomBinding()
        {
            // Create an empty BindingElementCollection to populate, 
            // then create a custom binding from it.
            BindingElementCollection outputBec = new BindingElementCollection();

            // Create a SymmetricSecurityBindingElement.
            SymmetricSecurityBindingElement ssbe = 
                new SymmetricSecurityBindingElement();

            // Set the algorithm suite to one that uses 128-bit keys.
            ssbe.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128;

               // Set MessageProtectionOrder to SignBeforeEncrypt.
            ssbe.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt;

            // Use a Kerberos token as the protection token.
            ssbe.ProtectionTokenParameters = new KerberosSecurityTokenParameters();
            
            // Add the SymmetricSecurityBindingElement to the BindingElementCollection.
            outputBec.Add ( ssbe );
            outputBec.Add(new TextMessageEncodingBindingElement());
            outputBec.Add(new HttpTransportBindingElement());

            // Create a CustomBinding and return it; otherwise, return null.
            return new CustomBinding(outputBec);
        }