		public static void CreateMessageAttachment1(string server, string textMessage)
		{
			// Create a message and set up the recipients.
			MailMessage message = new MailMessage(
			   "jane@contoso.com",
			   "ben@contoso.com",
			   "A text message for you.",
			   "Message: ");

			// Attach the message string to this e-mail message.
			Attachment data = new Attachment(textMessage, MediaTypeNames.Text.Plain);
			ContentDisposition disposition = data.ContentDisposition;
			// Suggest a file name for the attachment.
			disposition.FileName = "message" + DateTime.Now.ToString();
			message.Attachments.Add(data);
			//Send the message.
			SmtpClient client = new SmtpClient(server);
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

	    try {
        client.Send(message);
      }
      catch (Exception ex) {
        Console.WriteLine("Exception caught in CreateMessageAttachment1(): {0}", 
                    ex.ToString() );
			}
			// Display the values in the ContentDisposition for the attachment.
			Console.WriteLine("Content disposition");
			Console.WriteLine(disposition.ToString());
			Console.WriteLine("File {0}", disposition.FileName);
			Console.WriteLine("Size {0}", disposition.Size);
			Console.WriteLine("Creation {0}", disposition.CreationDate);
			Console.WriteLine("Modification {0}", disposition.ModificationDate);
			Console.WriteLine("Read {0}", disposition.ReadDate);
			Console.WriteLine("Inline {0}", disposition.Inline);
			Console.WriteLine("Parameters: {0}", disposition.Parameters.Count);
			foreach (DictionaryEntry d in disposition.Parameters)
			{
				Console.WriteLine("{0} = {1}", d.Key, d.Value);
			}
			data.Dispose();
		}