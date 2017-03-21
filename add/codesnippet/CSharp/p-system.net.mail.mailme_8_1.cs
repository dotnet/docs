		public static void CreateMessageWithAttachment(string server)
		{
			// Specify the file to be attached and sent.
			// This example assumes that a file named Data.xls exists in the
			// current working directory.
			string file = "data.xls";
			// Create a message and set up the recipients.
			MailMessage message = new MailMessage(
			   "jane@contoso.com",
			   "ben@contoso.com",
			   "Quarterly data report.",
			   "See the attached spreadsheet.");

			// Create  the file attachment for this e-mail message.
			Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
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
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

      try {
			  client.Send(message);
			}
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}", 
                    ex.ToString() );			  
			}
			// Display the values in the ContentDisposition for the attachment.
			ContentDisposition cd = data.ContentDisposition;
			Console.WriteLine("Content disposition");
			Console.WriteLine(cd.ToString());
			Console.WriteLine("File {0}", cd.FileName);
			Console.WriteLine("Size {0}", cd.Size);
			Console.WriteLine("Creation {0}", cd.CreationDate);
			Console.WriteLine("Modification {0}", cd.ModificationDate);
			Console.WriteLine("Read {0}", cd.ReadDate);
			Console.WriteLine("Inline {0}", cd.Inline);
			Console.WriteLine("Parameters: {0}", cd.Parameters.Count);
			foreach (DictionaryEntry d in cd.Parameters)
			{
				Console.WriteLine("{0} = {1}", d.Key, d.Value);
			}
			data.Dispose();
		}