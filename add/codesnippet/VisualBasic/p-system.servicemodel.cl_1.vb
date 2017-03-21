            ' Specify client credentials on the client. 
            ' Code to set the UserName and Password is not shown here.
            Dim CalculatorClient As New CalculatorClient("myBinding")
            CalculatorClient.ClientCredentials.UserName.UserName = ReturnUserName()
            CalculatorClient.ClientCredentials.UserName.Password = ReturnPassword()