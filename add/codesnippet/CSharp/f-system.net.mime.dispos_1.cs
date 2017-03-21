		public static void CreateMessageInlineAttachment3(string server, string
		textMessage)
		{
			// Create a message and set up the recipients.
			MailMessage message = new MailMessage(
			   "jane@contoso.com",
			   "ben@contoso.com",
			   "An inline text message for you.",
			   "Message: ");

			// Attach the message string to this e-mail message.
			Attachment data = new Attachment(textMessage, MediaTypeNames.Text.Plain);
			// Send textMessage as part of the e-mail body.
			message.Attachments.Add(data);
			ContentDisposition disposition = data.ContentDisposition;
			disposition.DispositionType = DispositionTypeNames.Inline;
			//Send the message.
			// Include credentials if the server requires them.
			SmtpClient client = new SmtpClient(server);
			client.Credentials = (ICredentialsByHost)CredentialCache.DefaultNetworkCredentials;
			client.Send(message);
			data.Dispose();
		}