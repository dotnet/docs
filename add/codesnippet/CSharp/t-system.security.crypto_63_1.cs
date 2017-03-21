            // Create a new CspParameters object.
            CspParameters cspParams = new CspParameters();

            // Specify an exchange key.
            cspParams.KeyNumber = (int) KeyNumber.Exchange;

            // Initialize the RSACryptoServiceProvider  
            // with the CspParameters object.
            RSACryptoServiceProvider RSACSP = new RSACryptoServiceProvider(cspParams);