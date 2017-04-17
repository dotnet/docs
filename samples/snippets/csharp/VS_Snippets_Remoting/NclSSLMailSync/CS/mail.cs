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
// <snippet1>
		public static void CreateTestMessage(string server)
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
                        client.EnableSsl = true;
			client.Send(message);
		}
		// </snippet1>



		public static void Main(string[] args)
		{
		    CreateTestMessage(args[0]);
		}
	}



}

