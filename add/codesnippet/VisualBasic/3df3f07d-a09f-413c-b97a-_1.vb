        Public Function VerifyHash(ByVal rsaParams As RSAParameters, ByVal signedData() As Byte, ByVal signature() As Byte) As Boolean
            Dim rsaCSP As New RSACryptoServiceProvider()
            Dim hash As New SHA1Managed()
            Dim hashedData() As Byte
            Dim dataOK As Boolean

            rsaCSP.ImportParameters(rsaParams)
            dataOK = rsaCSP.VerifyData(signedData, CryptoConfig.MapNameToOID("SHA1"), signature)
            hashedData = hash.ComputeHash(signedData)
            Return rsaCSP.VerifyHash(hashedData, CryptoConfig.MapNameToOID("SHA1"), signature)
        End Function 'VerifyHash