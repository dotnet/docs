		public static void CreateTestMessage1(string server, int port)
		{
			string to = "jane@contoso.com";
			string from = "ben@contoso.com";
			string subject = "Using the new SMTP client.";
			string body = @"Using this new feature, you can send an e-mail message from an application very easily.";
			MailMessage message = new MailMessage(from, to, subject, body);
			SmtpClient client = new SmtpClient(server, port);
			// Credentials are necessary if the server requires the client 
			// to authenticate before it will send e-mail on the client's behalf.
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

      try {
			  client.Send(message);
      }
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateTestMessage1(): {0}", 
                    ex.ToString() );
      }              
		}