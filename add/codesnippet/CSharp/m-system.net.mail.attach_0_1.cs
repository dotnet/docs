		public static void CreateMessageInlineAttachment2(string server, string
		textMessage)
		{
			// Create a message and set up the recipients.
			MailMessage message = new MailMessage(
			   "jane@contoso.com",
			   "ben@contoso.com",
			   "A text message for you.",
			   "Message: ");

			// Attach the message string to this e-mail message.
			Attachment data = new Attachment(textMessage);
			// Send textMessage as part of the e-mail body.
			message.Attachments.Add(data);
			ContentType content = data.ContentType;
			content.MediaType = MediaTypeNames.Text.Plain;
			//Send the message.
			// Include credentials if the server requires them.
			SmtpClient client = new SmtpClient(server);
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

	    try { 
        client.Send(message);
      }
      catch (Exception ex) {
        Console.WriteLine("Exception caught in CreateMessageInlineAttachment2: {0}", 
                    ex.ToString() );
      }
			data.Dispose();
		}