        private void Snippet2()
        {
            using (CalculatorClient client = new CalculatorClient())
            {
                client.ClientCredentials.HttpDigest.ClientCredential.UserName = "test";
                client.ClientCredentials.HttpDigest.ClientCredential.Password = "password";
            }
        }