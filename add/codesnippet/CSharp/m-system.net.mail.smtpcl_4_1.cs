		public static void CreateTestMessage3()
		{
			MailAddress to = new MailAddress("jane@contoso.com");
			MailAddress from = new MailAddress("ben@contoso.com");
			MailMessage message = new MailMessage(from, to);
			message.Subject = "Using the new SMTP client.";
			message.Body = @"Using this new feature, you can send an e-mail message from an application very easily.";
			// Use the application or machine configuration to get the 
			// host, port, and credentials.
			SmtpClient client = new SmtpClient();
			Console.WriteLine("Sending an e-mail message to {0} at {1} by using the SMTP host={2}.",
				to.User, to.Host, client.Host);
      try {
			  client.Send(message);
			}
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateTestMessage3(): {0}", 
                    ex.ToString() );			  
		  }
		}