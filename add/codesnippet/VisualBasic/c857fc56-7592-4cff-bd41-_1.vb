        Dim signatureDescription As New SignatureDescription
        signatureDescription.DeformatterAlgorithm = _
            "System.Security.Cryptography.DSASignatureDeformatter"

        Dim asymmetricDeformatter As AsymmetricSignatureDeformatter
        asymmetricDeformatter = SignatureDescription.CreateDeformatter(dsa)