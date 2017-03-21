		public static void CreateMessageWithMultipleViews(string server, string recipients)
		{
			// Create a message and set up the recipients.
			MailMessage message = new MailMessage(
				"jane@contoso.com",
				recipients,
				"This e-mail message has multiple views.",
				"This is some plain text.");

			// Construct the alternate body as HTML.
			string body = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
			body += "<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">";
			body += "</HEAD><BODY><DIV><FONT face=Arial color=#ff0000 size=2>this is some HTML text";
			body += "</FONT></DIV></BODY></HTML>";

			ContentType mimeType = new System.Net.Mime.ContentType("text/html");
			// Add the alternate body to the message.
			
			AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
			message.AlternateViews.Add(alternate);

			// Send the message.
			SmtpClient client = new SmtpClient(server);
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

      try {
			  client.Send(message);
			}
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateMessageWithMultipleViews(): {0}", 
                    ex.ToString() );			  
      }
			// Display the values in the ContentType for the attachment.
			ContentType c = alternate.ContentType;
			Console.WriteLine("Content type");
			Console.WriteLine(c.ToString());
			Console.WriteLine("Boundary {0}", c.Boundary);
			Console.WriteLine("CharSet {0}", c.CharSet);
			Console.WriteLine("MediaType {0}", c.MediaType);
			Console.WriteLine("Name {0}", c.Name);
			Console.WriteLine("Parameters: {0}", c.Parameters.Count);
			foreach (DictionaryEntry d in c.Parameters)
			{
				Console.WriteLine("{0} = {1}", d.Key, d.Value);
			}
			Console.WriteLine();
			alternate.Dispose();
		}
