		// The following example sends a summary of a log file as the message
		// and the log as an e-mail attachment.
		public static void SendErrorLog(string server, string recipientList)
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
			// Make a contentType indicating that the log data
			// that is attached is plain text.
			ContentType ct = new ContentType(MediaTypeNames.Text.Plain);
			// Attach the log file stream to the e-mail message.
			Attachment data = new Attachment(fs, ct);
			ContentDisposition disposition = data.ContentDisposition;
			// Suggest a file name for the attachment.
			disposition.FileName = "log" + DateTime.Now.ToString() + ".txt";
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
        Console.WriteLine("Exception caught in SendErrorLog: {0}", 
                    ex.ToString() );
      }
			data.Dispose();
			// Close the log file.
			fs.Close();
		}