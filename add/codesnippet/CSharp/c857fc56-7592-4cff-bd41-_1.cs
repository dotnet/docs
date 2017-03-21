        SignatureDescription signatureDescription = 
            new SignatureDescription();
        signatureDescription.DeformatterAlgorithm =
            "System.Security.Cryptography.DSASignatureDeformatter";

        AsymmetricSignatureDeformatter asymmetricDeformatter =
            signatureDescription.CreateDeformatter(dsa);