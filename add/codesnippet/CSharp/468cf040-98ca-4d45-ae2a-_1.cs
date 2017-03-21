		// The following example sends a summary of a log file as the message
		// and the log as an e-mail attachment.
		public static void SendNamedAndTypedErrorLog(string server, string recipientList)
		{
			// Create a message from logMailer@contoso.com to recipientList.
			MailMessage message = new MailMessage(
			   "logMailer@contoso.com", recipientList);

			message.Subject = "Error Log report";
			string fileName = "log.txt";
			// Get the file stream for the error log.
			// Requires the System.IO namespace.
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			StreamReader s = new StreamReader(fs);
			int errors = 0;
			while (s.ReadLine() != null)
			{
				// Process each line from the log file here.
				errors++;
			}
			// The e-mail message summarizes the data found in the log.
			message.Body = String.Format("{0} errors in log as of {1}",
				errors, DateTime.Now);
			// Close the stream reader. This also closes the file.
			s.Close();
			// Re-open the file at the beginning to make the attachment.
			fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			// Create a name for the log data file.
			string name = "log" + DateTime.Now.ToString() + ".txt";
			// Create the attachment, name it, and specify the MIME type.
			Attachment data = new Attachment(fs, name, MediaTypeNames.Text.Plain);
			// Add the attachment to the message.
			message.Attachments.Add(data);
			// Send the message.
			// Include credentials if the server requires them.
			SmtpClient client = new SmtpClient(server);
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

	    try { 
        client.Send(message);
      }
      catch (Exception ex) {
        Console.WriteLine("Exception caught in SendNamedAndTypedErrorLog: {0}", 
                    ex.ToString() );
      }
			data.Dispose();
			// Close the log file.
			fs.Close();
		}