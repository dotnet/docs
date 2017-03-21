        private void Snippet3()
        {
            using (CalculatorClient client = new CalculatorClient())
            {
                client.ClientCredentials.Windows.ClientCredential = new NetworkCredential("test user", "password");
            }
        }