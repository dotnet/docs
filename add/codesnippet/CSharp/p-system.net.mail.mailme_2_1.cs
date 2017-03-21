		public static void CreateMessageWithAttachment4(string server, string to)
		{
			// Specify the file to be attached and sent.
			// This example uses a file on a UNC share.
			string file = @"\\share3\c$\reports\data.xls";
			// Create a message and set up the recipients.
			MailMessage message = new MailMessage(
			   "ReportMailer@contoso.com",
			   to,
			   "Quarterly data report",
			   "See the attached spreadsheet.");

			// Create  the file attachment for this e-mail message.
			Attachment data = new Attachment("qtr3.xls", MediaTypeNames.Application.Octet);
			// Add time stamp information for the file.
			ContentDisposition disposition = data.ContentDisposition;
			disposition.CreationDate = System.IO.File.GetCreationTime(file);
			disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
			disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
			disposition.DispositionType = DispositionTypeNames.Attachment;
			// Add the file attachment to this e-mail message.
			message.Attachments.Add(data);
			//Send the message.
			SmtpClient client = new SmtpClient(server);
			// Add credentials if the SMTP server requires them.
			client.Credentials = (ICredentialsByHost)CredentialCache.DefaultNetworkCredentials;
			client.Send(message);
			// Display the message headers.
			string[] keys = message.Headers.AllKeys;
			Console.WriteLine("Headers");
			foreach (string s in keys)
			{
				Console.WriteLine("{0}:", s);
				Console.WriteLine("    {0}", message.Headers[s]);
			}
			data.Dispose();
		}