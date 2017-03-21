        BinarySecretSecurityToken CreateProofToken(byte[] proofKey)
        {
            return new BinarySecretSecurityToken(proofKey);
        }