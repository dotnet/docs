        Dim securityElement As New SecurityElement("DSASignature")

        ' Create new security elements for the four algorithms.
        securityElement.AddChild(new SecurityElement( _
            "Key", _
            "System.Security.Cryptography.DSACryptoServiceProvider"))
        securityElement.AddChild(New SecurityElement( _
            "Digest", _
            "System.Security.Cryptography.SHA1CryptoServiceProvider"))
        securityElement.AddChild(new SecurityElement( _
            "Formatter", _
            "System.Security.Cryptography.DSASignatureFormatter"))
        securityElement.AddChild(new SecurityElement( _
            "Deformatter", _
            "System.Security.Cryptography.DSASignatureDeformatter"))

        Dim signatureDescription As New SignatureDescription(securityElement)