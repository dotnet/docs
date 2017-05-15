// NclMailSync

using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
namespace Examples.SmptExamples.Sync
{

	public class CtorExamples
	{
		//Display the properties on the service point.
		//ServicePoint p = client.ServicePoint;
		//Console.WriteLine("Connection lease timeout: {0}",
		//p.ConnectionLeaseTimeout);

// <snippet1>
		public static void CreateTestMessage1(string server, int port)
		{
			string to = "jane@contoso.com";
			string from = "ben@contoso.com";
			string subject = "Using the new SMTP client.";
			string body = @"Using this new feature, you can send an e-mail message from an application very easily.";
			MailMessage message = new MailMessage(from, to, subject, body);
			SmtpClient client = new SmtpClient(server, port);
			// Credentials are necessary if the server requires the client 
			// to authenticate before it will send e-mail on the client's behalf.
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

      try {
			  client.Send(message);
      }
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateTestMessage1(): {0}", 
                    ex.ToString() );
      }              
		}
		// </snippet1>

		//<snippet2>
		public static void CreateTestMessage2(string server)
		{
			string to = "jane@contoso.com";
			string from = "ben@contoso.com";
			MailMessage message = new MailMessage(from, to);
			message.Subject = "Using the new SMTP client.";
			message.Body = @"Using this new feature, you can send an e-mail message from an application very easily.";
			SmtpClient client = new SmtpClient(server);
			// Credentials are necessary if the server requires the client 
			// to authenticate before it will send e-mail on the client's behalf.
			client.UseDefaultCredentials = true;

      try {
			  client.Send(message);
			}  
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", 
                    ex.ToString() );			  
      }              
		}
		//</snippet2>

		//<snippet3>
		public static void CreateTimeoutTestMessage(string server)
		{
			string to = "jane@contoso.com";
			string from = "ben@contoso.com";
			string subject = "Using the new SMTP client.";
			string body = @"Using this new feature, you can send an e-mail message from an application very easily.";
			MailMessage message = new MailMessage(from, to, subject, body);
			SmtpClient client = new SmtpClient(server);
			Console.WriteLine("Changing time out from {0} to 100.", client.Timeout);
			client.Timeout = 100;
			// Credentials are necessary if the server requires the client 
			// to authenticate before it will send e-mail on the client's behalf.
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

      try {
			  client.Send(message);
			}  
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}", 
                    ex.ToString() );			  
		  }
		}
		//</snippet3>

		//<snippet4>
		public static void CreateTestMessage3()
		{
			MailAddress to = new MailAddress("jane@contoso.com");
			MailAddress from = new MailAddress("ben@contoso.com");
			MailMessage message = new MailMessage(from, to);
			message.Subject = "Using the new SMTP client.";
			message.Body = @"Using this new feature, you can send an e-mail message from an application very easily.";
			// Use the application or machine configuration to get the 
			// host, port, and credentials.
			SmtpClient client = new SmtpClient();
			Console.WriteLine("Sending an e-mail message to {0} at {1} by using the SMTP host={2}.",
				to.User, to.Host, client.Host);
      try {
			  client.Send(message);
			}
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateTestMessage3(): {0}", 
                    ex.ToString() );			  
		  }
		}
		//</snippet4>

		//<snippet5>
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

		//</snippet5>


		//<snippet6>
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
		//</snippet6>


		//<snippet7>
		public static void CreateTestMessage4(string server)
		{
			MailAddress from = new MailAddress("ben@contoso.com");
			MailAddress to = new MailAddress("Jane@contoso.com");
			MailMessage message = new MailMessage(from, to);
			message.Subject = "Using the SmtpClient class.";
			message.Body = @"Using this feature, you can send an e-mail message from an application very easily.";
			SmtpClient client = new SmtpClient(server);
			Console.WriteLine("Sending an e-mail message to {0} by using SMTP host {1} port {2}.",
				 to.ToString(), client.Host, client.Port);

      try {
			  client.Send(message);
			}
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateTestMessage4(): {0}", 
                    ex.ToString() );			  
		  }
		}
		//</snippet7>

		//<snippet8>
		public static void CreateTestMessage5(string server)
		{
			string to = "jane@contoso.com";
			string from = "ben@contoso.com";
			string subject = "Using the new SMTP client.";
			string body = @"Using this new feature, you can send an e-mail message from an application very easily.";
			SmtpClient client = new SmtpClient(server);
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

      try {
			  client.Send(from, to, subject, body);
			}
			catch (Exception ex) {
			  Console.WriteLine("Exception caught in CreateTestMessage5(): {0}\n", 
                    ex.ToString() );			  
		  }
		}
		//</snippet8>
		//<snippet9>
		public static void CreateBccTestMessage(string server)
		{
			MailAddress from = new MailAddress("ben@contoso.com", "Ben Miller");
			MailAddress to = new MailAddress("jane@contoso.com", "Jane Clayton");
			MailMessage message = new MailMessage(from, to);
			message.Subject = "Using the SmtpClient class.";
			message.Body = @"Using this feature, you can send an e-mail message from an application very easily.";
			MailAddress bcc = new MailAddress("manager1@contoso.com");
			message.Bcc.Add(bcc);
			SmtpClient client = new SmtpClient(server);
			client.Credentials = CredentialCache.DefaultNetworkCredentials;
			Console.WriteLine("Sending an e-mail message to {0} and {1}.", 
			    to.DisplayName, message.Bcc.ToString());
      try {
        client.Send(message);
      }  
      catch (Exception ex) {
        Console.WriteLine("Exception caught in CreateBccTestMessage(): {0}", 
                    ex.ToString() );
  	  }
  	}
		//</snippet9>

		//<snippet10>
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
		//</snippet10>


		//<snippet11>
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
		//</snippet11>

		//<snippet12>
		public static void CreateMessageInlineAttachment(string server, string
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
			disposition.Inline = true;
			//Send the message.
			// Include credentials if the server requires them.
			SmtpClient client = new SmtpClient(server);
			client.Credentials = CredentialCache.DefaultNetworkCredentials;

	    try {
        client.Send(message);
      }
      catch (Exception ex) {
        Console.WriteLine("Exception caught in CreateMessageInlineAttachment: {0}", 
                    ex.ToString() );
      }
			data.Dispose();
		}
		//</snippet12>

		//<snippet13>
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
		//</snippet13>

		//<snippet14>
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
		//</snippet14>

		//<snippet15>
		// The following example sends a summary of a log file as the message
		// and the log as an e-mail attachment.
		public static void SendNamedErrorLog(string server, string recipientList)
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
			// Make a ContentType indicating that the log data
			// that is attached is plain text and is named.
			ContentType ct = new ContentType();
			ct.MediaType = MediaTypeNames.Text.Plain;
			ct.Name = "log" + DateTime.Now.ToString() + ".txt";
			// Create the attachment.
			Attachment data = new Attachment(fs, ct);
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
        Console.WriteLine("Exception caught in SendNamedErrorLog: {0}", 
                    ex.ToString() );
      }
			data.Dispose();
			// Close the log file.
			fs.Close();
			return;
		}
		//</snippet15>

		//<snippet16>
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
		//</snippet16>
		//<snippet17>
		public static Attachment SendAttachedMessage(string server)
		{
			// Set up the sender information.
			String from = Environment.UserDomainName + "." +
				Environment.UserName +
				"@contoso.com";
			Console.WriteLine("From: {0}", from);
			// Have the user enter the message recipient.
			Console.Write("To: ");
			string recipient = Console.ReadLine();
			// Check for recipient data.
			// A real application would add error checking here for a valid e-mail 
			// address format. This example accepts any input.
			if (recipient.Length == 0)
				return null;
			// Get the subject.
			Console.Write("Subject: ");
			string subject = Console.ReadLine();
			// Get the message content.
			Console.WriteLine("Enter the message. Press return on a blank line to finish:");
			StringBuilder sb = new StringBuilder();
			string line;
			while (true)
			{
				line = Console.ReadLine();
				if (line.Length > 0)
				{
					// Store the message and the end-of-line characters.
					sb.AppendFormat("{0},{1}", line, Environment.NewLine);
				}
				else
					break;
			}

			// Create a message and set up the recipients.
			MailMessage message = new MailMessage(from, recipient);
			message.Subject = subject;
			// Attach the message string to this e-mail message.
			// Set the encoding to the computer's current encoding.
			Attachment data = new Attachment(sb.ToString(),
				MediaTypeNames.Text.Plain);

			// Add the attachment to the message.
			message.Attachments.Add(data);
			//Send the message. Supply credentials if necessary.
			SmtpClient client = new SmtpClient(server);
			client.Credentials = CredentialCache.DefaultNetworkCredentials;
			Console.WriteLine("Ready to send. Press enter to send. Type any character to quit:");
			string answer = Console.ReadLine();
			if (answer.Length == 0)
			{

	      try { 
          client.Send(message);
        }
        catch (Exception ex) {
          Console.WriteLine("Exception caught in SendAttachedMessage: {0}", 
                      ex.ToString() );
        }
				Console.WriteLine("Message sent.");
			}
			else
			{
				Console.WriteLine("Send canceled.");
			}
			return data;
		}
		//</snippet17>

		//<snippet18>
		public static void CreateMessageWithFile(string server, string to)
		{
			// Create a message and set up the recipients.
			MailMessage message = new MailMessage("ReportMailer@contoso.com", to);
			message.Subject = "Monthly Expense report";
			message.Body = "Please review the attached report.";
			// Attach a file to this e-mail message.
			Attachment data = new Attachment("data.xls", MediaTypeNames.Application.Octet);
			AttachmentCollection attachments = message.Attachments;
			attachments.Add(data);
			SmtpClient client = new SmtpClient(server);
			client.Credentials = (ICredentialsByHost)CredentialCache.DefaultNetworkCredentials;

	    try {
        client.Send(message);
      }
      catch (Exception ex) {
        Console.WriteLine("Exception caught in CreateMessageWithFile: {0}", 
                    ex.ToString() );
		  }
		}
		//</snippet18>

		//<snippet19>
		public static void DisplayFileAttachment(Attachment a)
		{
			Console.WriteLine("Content Disposition {0}", a.ContentDisposition.ToString());
			Console.WriteLine("Content Type {0}", a.ContentType.ToString());
			Console.WriteLine("Name {0}", a.Name);
		}
		//</snippet19>

		//<snippet20>
		public static void DisplayStringAttachment(Attachment a)
		{
			Console.WriteLine("Content: {0}", a.ContentType);
			Console.WriteLine("Encoding {0}", a.TransferEncoding);
			Console.WriteLine("Content Disposition {0}", a.ContentDisposition.ToString());
			Console.WriteLine("Content Type {0}", a.ContentType.ToString());
		}
		//</snippet20>


		//<snippet21>
		public static void DisplayStreamAttachment(Attachment a)
		{
			Stream s = a.ContentStream;
			StreamReader reader = new StreamReader(s);
			Console.WriteLine("Content: {0}", reader.ReadToEnd());
			Console.WriteLine("Content Type {0}", a.ContentType.ToString());
			Console.WriteLine("Transfer Encoding {0}", a.TransferEncoding);
			// Note that you cannot close the reader before the e-mail is sent. 
			// Closing the reader before sending the e-mail will close the 
			// ContentStream and cause an SmtpException.
			reader = null;
		}
		//</snippet21>

		//<snippet22>
		public static void CreateMessageWithAttachment2(string server, string to)
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
			Attachment data = new Attachment(file);
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

	    try {
        client.Send(message);
      }
      catch (Exception ex) {
        Console.WriteLine("Exception caught in CreateMessageWithAttachment2: {0}", 
                    ex.ToString() );
      }
			finally {
			 data.Dispose();
			} 
		}
		//</snippet22>

		//<snippet23>
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
		//</snippet23>

		//<snippet24>
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
		//</snippet24>

//<snippet25>
		public static void CreateMessageAttachment5(string server, string textMessage)
		{
			// Create a message and set up the recipients.
			MailMessage message = new MailMessage(
			   "jane@contoso.com",
			   "ben@contoso.com",
			   "A text message for you.",
			   "Message: ");

			// Attach the message string to this e-mail message.
			Attachment data = new Attachment(textMessage,
				                         MediaTypeNames.Text.Plain);
//			data.SetContent(textMessage,
//				MediaTypeNames.Text.Plain,
//				System.Text.Encoding.UTF8);
			ContentDisposition disposition = data.ContentDisposition;
			// Suggest a file name for the attachment.
			disposition.FileName = "message" + DateTime.Now.ToString();
			message.Attachments.Add(data);
			//Send the message.
			SmtpClient client = new SmtpClient(server);
			client.Credentials = (ICredentialsByHost)CredentialCache.DefaultNetworkCredentials;
			client.Send(message);
			data.Dispose();
		}
		//</snippet25>

		//<snippet26>
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
		//</snippet26>


		//<snippet27>
		public static void RetryIfBusy(string server)
		{
			MailAddress from = new MailAddress("ben@contoso.com");
			MailAddress to = new MailAddress("jane@contoso.com");
			MailMessage message = new MailMessage(from, to);
			// message.Subject = "Using the SmtpClient class.";
			message.Subject = "Using the SmtpClient class.";
			message.Body = @"Using this feature, you can send an e-mail message from an application very easily.";
			// Add a carbon copy recipient.
			MailAddress copy = new MailAddress("Notifications@contoso.com");
			message.CC.Add(copy);
			SmtpClient client = new SmtpClient(server);
			// Include credentials if the server requires them.
			client.Credentials = (ICredentialsByHost)CredentialCache.DefaultNetworkCredentials;
			Console.WriteLine("Sending an e-mail message to {0} using the SMTP host {1}.",
				 to.Address, client.Host);
			try
			{
				client.Send(message);
			}
			catch (SmtpFailedRecipientsException ex)
			{
				for (int i = 0; i < ex.InnerExceptions.Length; i++)
				{
					SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
					if (status == SmtpStatusCode.MailboxBusy ||
						status == SmtpStatusCode.MailboxUnavailable)
					{
						Console.WriteLine("Delivery failed - retrying in 5 seconds.");
						System.Threading.Thread.Sleep(5000);
						client.Send(message);
					}
					else
					{
						Console.WriteLine("Failed to deliver message to {0}", 
						    ex.InnerExceptions[i].FailedRecipient);
					}
				}
			}
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in RetryIfBusy(): {0}", 
                        ex.ToString() );
            }
        }
		//</snippet27>

// silly snippets to get code coverage in exceptions!
		//<snippet28>
		public static SmtpException GenerateDefaultSmtpException()
		{
			return new SmtpException();
		}

		//</snippet28>

		//<snippet29>
		public static SmtpException GenerateSmtpException(string message)
		{
			return new SmtpException(message);
		}

		//</snippet29>

		//<snippet30>
		public static SmtpException GenerateSmtpException(SmtpStatusCode status)
		{
			return new SmtpException(status);
		}
		//</snippet30>

		//<snippet31>
		public static SmtpException GenerateSmtpException(SmtpStatusCode status, string message)
		{
			return new SmtpException(status, message);
		}
		//</snippet31>

		//<snippet32>
		public static SmtpException GenerateSmtpException(string message, Exception innerException)
		{
			return new SmtpException(message, innerException);
		}
		//</snippet32>


		public static void CreateSampleDispositions()
		{
			//<snippet33>
			ContentDisposition c1 = new ContentDisposition();
			Console.WriteLine(c1.ToString());
			//</snippet33>

			//<snippet34>
			ContentDisposition c2 = new ContentDisposition("attachment");
			Console.WriteLine(c2.ToString());
			//</snippet34>

			ContentDisposition c3 = new ContentDisposition("Attachment; filename = myFile;");
			Console.WriteLine(c3.ToString());
		}

		public static void DumpMailAddress(MailAddress a)
		{
			Console.WriteLine("Display: {0} Host: {1} User: {2} Address: {3}",
				a.DisplayName, a.Host, a.User, a.Address);
		}
		public static void CreateSampleAddresses()
		{
			MailAddress a1 = new MailAddress("Ben Miller <ben@contoso.com>");
			Console.WriteLine(a1.ToString());
			DumpMailAddress(a1);

			// WRONG but legal: Should not include angle brackets.
			MailAddress a2 = new MailAddress("<ben@contoso.com>");
			Console.WriteLine(a2.ToString());
			DumpMailAddress(a2);

			MailAddress a3 = new MailAddress("ben.address1@contoso.com");
			Console.WriteLine(a3.ToString());
			DumpMailAddress(a3);

// Use a constructor that takes an address and the display name separately.
// Throwing a format exception
//    MailAddress a4 = new MailAddress("tom@contoso.com", "Tom Smith");
//    Console.WriteLine(a4.ToString());
//    DumpMailAddress(a4);

// WRONG: Should not include angle brackets.
//    MailAddress a5 = new MailAddress("<tom@contoso.com   >   ", "Tom Smith");
			//   Console.WriteLine(a5.ToString());
//    DumpMailAddress(a5);

// WRONG but legal: Should not include display name as part of address.
			MailAddress a6 = new MailAddress("Tom Smith<tom@contoso.com>", "Bill Jones");
			Console.WriteLine(a6.ToString());
			DumpMailAddress(a6);

			MailAddress a7 = new MailAddress("tom@contoso.com", "      Tom Smith          ");
			Console.WriteLine(a7.ToString());
			DumpMailAddress(a7);

		}

		public static void DisplayContentType(ContentType c)
		{
			Console.WriteLine("Boundary {0}", c.Boundary);
			Console.WriteLine("Charset {0}", c.CharSet);
			Console.WriteLine("MediaType {0}", c.MediaType);
			Console.WriteLine("Name {0}", c.Name);
			Console.WriteLine("Parameters: {0}", c.Parameters.Count);
			foreach (DictionaryEntry d in c.Parameters)
			{
				Console.WriteLine("{0} = {1}", d.Key, d.Value);
			}
		}




		public static void CreateContentTypes()
		{
			ContentType c1 = new ContentType();
			Console.WriteLine("---c1 {0}", c1.ToString());
			DisplayContentType(c1);
			ContentType c2 = new ContentType("text/html");
			Console.WriteLine("---c2 {0}", c2.ToString());
			DisplayContentType(c2);
			ContentType c3 = new ContentType("application/x-myPrivateSubtype; name=data.xyz; charset=us-ascii");
			Console.WriteLine("---c3 {0}", c3.ToString());
			DisplayContentType(c3);

		}



		// The first argument is the mail server
		// the second argument is the recipient.
		// The second argument is the sender.
		public static void Main(string[] args)
		{

      string server = "www.contoso.com";
      int port = 21;      
      
      Console.WriteLine("Usage:\n   mail server recipients sender\n");
        
      Console.WriteLine("\ncall CreateTestMessage1({0})", args[0]);
      CreateTestMessage1(args[0], port);

      Console.WriteLine("\ncall CreateTestMessage2({0})", args[0]);
			CreateTestMessage2(args[0]);
			
      Console.WriteLine("\ncall CreateTestMessage2({0})", args[0]);
      CreateTimeoutTestMessage(args[0]);
      
      Console.WriteLine("\ncall CreateTestMessage3()");
			CreateTestMessage3();

      Console.WriteLine("\ncall CreateMessageWithMultipleViews({0},{1})", args[0], args[1]);
      CreateMessageWithMultipleViews(args[0], args[1]);
			// CreateMessageWithMultipleViews("smarthost","sharriso@microsoft.com");

      Console.WriteLine("\ncall CreateMessageWithAttachment({0})", args[0]);
      CreateMessageWithAttachment(args[0]);

      Console.WriteLine("\ncall CreateTestMessage4({0})", args[0]);
			CreateTestMessage4(args[0]);
			
      Console.WriteLine("\ncall CreateTestMessage5({0})", args[0]);
			CreateTestMessage5(args[0]);
			
      Console.WriteLine("\ncall CreateBccTestMessage({0})", args[0]);
			CreateBccTestMessage(args[0]);
			
			// CreateMessageInlineAttachment3("smarthost", "string  textMessage");
			//CreateCopyMessage("sharriso1");
			//  CreateMessageWithMultipleRecipients("sharriso1");
			//CreateTestMessageY("sharriso1");
			//CreateMessageWithAttachment("smarthost");
			//CreateContentTypes();
			// CreateMessageWithMultipleRecipients("smarthost");
			//CreateSampleAddresses();
			// CreateMessageAttachment1("smarthost", "This is an attached message.");
			//CreateMessageInlineAttachment("sharriso1", "How cool is this?");
			//CreateMessageInlineAttachment2("smarthost", "This is an attached message.");
			//SendErrorLog("smarthost", "sharriso@microsoft.com");
			//Attachment log = SendNamedErrorLog("smarthost", "sharriso@microsoft.com");
			//SendNamedAndTypedErrorLog("smarthost", "sharriso@microsoft.com");
			//Attachment a = SendAttachedMessage("smarthost");
			//DisplayStringAttachment(a);

			//  CreateMessageWithFile("smarthost", "sharriso@microsoft.com");
			// CreateMessageWithAttachment2("smarthost", "sharriso@microsoft.com");
			//    CreateMessageWithAttachment3("xx","sharriso@microsoft.com");
			//  CreateMessageWithAttachment4("smarthost", "sharriso@microsoft.com");
			//     CreateMessageAttachment5("sharriso1", "string textMessage");
			//CreateSampleDispositions();

      Console.WriteLine("\ncall RetryIfBusy({0})", args[0]);
			RetryIfBusy(args[0]);
		}
	}



}

