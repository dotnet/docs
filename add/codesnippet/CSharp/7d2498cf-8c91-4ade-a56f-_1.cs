        SignatureDescription signatureDescription = 
            new SignatureDescription();
        signatureDescription.FormatterAlgorithm =
            "System.Security.Cryptography.DSASignatureFormatter";

        AsymmetricSignatureFormatter asymmetricFormatter =
            signatureDescription.CreateFormatter(dsa);