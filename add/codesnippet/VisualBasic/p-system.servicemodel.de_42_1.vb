			' Create a client object with the given client endpoint configuration.
		   Dim client As New CalculatorClient()
		  Try
				client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation
			Catch timeProblem As TimeoutException
			  Console.WriteLine("The service operation timed out. " & timeProblem.Message)
			  Console.ReadLine()
			  client.Abort()
			Catch commProblem As CommunicationException
			  Console.WriteLine("There was a communication problem. " & commProblem.Message + commProblem.StackTrace)
			  Console.ReadLine()
			  client.Abort()
			End Try