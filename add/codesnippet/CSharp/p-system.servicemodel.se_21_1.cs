            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType = 
                MessageCredentialType.UserName;


            CalculatorClient client = new CalculatorClient("default");

            client.ClientCredentials.UserName.Password = ReturnPassword();

            client.ClientCredentials.UserName.UserName = ReturnUsername();