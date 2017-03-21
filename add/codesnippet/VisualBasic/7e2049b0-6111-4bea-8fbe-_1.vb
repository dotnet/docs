        Function CreateProofToken(ByVal proofKey() As Byte) As BinarySecretSecurityToken
            Return New BinarySecretSecurityToken(proofKey)

        End Function