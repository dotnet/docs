		public static void CreateCopyMessage(string server)
		{
			MailAddress from = new MailAddress("ben@contoso.com", "Ben Miller");
			MailAddress to = new MailAddress("jane@contoso.com", "Jane Clayton");
			MailMessage message = new MailMessage(from, to);
			// message.Subject = "Using the SmtpClient class.";
			message.Subject = "Using the SmtpClient class.";
			message.Body = @"Using this feature, you can send an e-mail message from an application very easily.";
			// Add a carbon copy recipient.
			MailAddress copy = new MailAddress("Notification_List@contoso.com");
			message.CC.Add(copy);
			SmtpClient client = new SmtpClient(server);
			// Include credentials if the server requires them.
			client.Credentials = CredentialCache.DefaultNetworkCredentials;
			Console.WriteLine("Sending an e-mail message to {0} by using the SMTP host {1}.",
				 to.Address, client.Host);
	
	    try {
        client.Send(message);
      }
      catch (Exception ex) {
        Console.WriteLine("Exception caught in CreateCopyMessage(): {0}", 
                    ex.ToString() );
  	  }
    }