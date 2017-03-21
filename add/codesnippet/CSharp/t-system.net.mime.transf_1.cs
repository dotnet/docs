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