		public static void CreateMessageWithAttachment3(string server, string to)
		{
			// Specify the file to be attached and sent.
			// This example assumes that a file named Data.xls exists in the
			// current working directory.
			string file = "data.xls";
			// Create a message and set up the recipients.
			MailMessage message = new MailMessage(
			   "ReportMailer@contoso.com",
			   to,
			   "Quarterly data report",
			   "See the attached spreadsheet.");

			// Create  the file attachment for this e-mail message.
			Attachment data = new Attachment("Qtr3.xls");
			// Add time stamp information for the file.
			ContentDisposition disposition = data.ContentDisposition;
			disposition.CreationDate = System.IO.File.GetCreationTime(file);
			disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
			disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
			// Add the file attachment to this e-mail message.
			message.Attachments.Add(data);
			//Send the message.
			SmtpClient client = new SmtpClient(server);
			// Add credentials if the SMTP server requires them.
			client.Credentials = (ICredentialsByHost)CredentialCache.DefaultNetworkCredentials;
			// Notify user if an error occurs.
			try
			{
				client.Send(message);
			}
			catch (SmtpException e)
			{
				Console.WriteLine("Error: {0}", e.StatusCode);
			}
			finally
			{
				data.Dispose();
			}
		}