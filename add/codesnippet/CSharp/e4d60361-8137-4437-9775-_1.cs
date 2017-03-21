        CspParameters parameters = new CspParameters();
        parameters.KeyContainerName = "TestContainer";
        Object[] argsArray = new Object[] {parameters};

        // Instantiate the RSA provider instance accessing the TestContainer
        // key container.
        RSACryptoServiceProvider rsaProvider = (RSACryptoServiceProvider) 
            CryptoConfig.CreateFromName("RSA",argsArray);