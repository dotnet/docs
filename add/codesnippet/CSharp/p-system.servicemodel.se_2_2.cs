        private void Snippet3()
        {
            using (CalculatorClient client = new CalculatorClient())
            {
                client.ClientCredentials.HttpDigest.ClientCredential = new NetworkCredential("test user", "password");
            }
        }