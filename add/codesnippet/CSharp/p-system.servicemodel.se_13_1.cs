        private void Snippet2()
        {
            using (CalculatorClient client = new CalculatorClient())
            {
                client.ClientCredentials.Windows.ClientCredential.UserName = "test";
                client.ClientCredentials.Windows.ClientCredential.Password = "password";
            }
        }