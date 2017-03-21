		public static void CreateBccTestMessage(string server)
		{
			MailAddress from = new MailAddress("ben@contoso.com", "Ben Miller");
			MailAddress to = new MailAddress("jane@contoso.com", "Jane Clayton");
			MailMessage message = new MailMessage(from, to);
			message.Subject = "Using the SmtpClient class.";
			message.Body = @"Using this feature, you can send an e-mail message from an application very easily.";
			MailAddress bcc = new MailAddress("manager1@contoso.com");
			message.Bcc.Add(bcc);
			SmtpClient client = new SmtpClient(server);
			client.Credentials = CredentialCache.DefaultNetworkCredentials;
			Console.WriteLine("Sending an e-mail message to {0} and {1}.", 
			    to.DisplayName, message.Bcc.ToString());
      try {
        client.Send(message);
      }  
      catch (Exception ex) {
        Console.WriteLine("Exception caught in CreateBccTestMessage(): {0}", 
                    ex.ToString() );
  	  }
  	}