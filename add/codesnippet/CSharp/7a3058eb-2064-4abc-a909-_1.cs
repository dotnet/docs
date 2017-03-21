        SecurityElement securityElement = new SecurityElement("DSASignature");

        // Create new security elements for the four algorithms.
        securityElement.AddChild(new SecurityElement(
            "Key",
            "System.Security.Cryptography.DSACryptoServiceProvider"));
        securityElement.AddChild(new SecurityElement(
            "Digest",
            "System.Security.Cryptography.SHA1CryptoServiceProvider")); 
        securityElement.AddChild(new SecurityElement(
            "Formatter",
            "System.Security.Cryptography.DSASignatureFormatter"));
        securityElement.AddChild(new SecurityElement(
            "Deformatter",
            "System.Security.Cryptography.DSASignatureDeformatter"));

        SignatureDescription signatureDescription = 
            new SignatureDescription(securityElement);