            // Create a client object with the given client endpoint configuration.
           CalculatorClient client = new CalculatorClient();
          try
            {
                client.ClientCredentials.Windows.AllowedImpersonationLevel 
                    = TokenImpersonationLevel.Impersonation;
            }
            catch (TimeoutException timeProblem)
            {
              Console.WriteLine("The service operation timed out. " + timeProblem.Message);
              Console.ReadLine();
              client.Abort();
            }
            catch (CommunicationException commProblem)
            {
              Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
              Console.ReadLine();
              client.Abort();
            }