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