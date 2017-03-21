        Dim signatureDescription As New SignatureDescription
        signatureDescription.FormatterAlgorithm = _
            "System.Security.Cryptography.DSASignatureFormatter"

        Dim asymmetricFormatter As AsymmetricSignatureFormatter
        asymmetricFormatter = signatureDescription.CreateFormatter(dsa)