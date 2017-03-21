        SmtpClient client = new SmtpClient("ContosoMail", 45);
        MailAddress from = new MailAddress("sender@SenderMailServerName.com", "Sender Name");
        MailAddress to = new MailAddress("recepient@RecepientMailServerName.com", "Recepient Name");
        MailMessage message = new MailMessage(from, to);

        message.Body = "This is a test e-mail message sent by an application. ";
        message.Subject = "Test Email using Credentials";

        NetworkCredential myCreds = new NetworkCredential("username", "password", "domain");
        CredentialCache myCredentialCache = new CredentialCache();        
        try 
        {
            myCredentialCache.Add("ContoscoMail", 35, "Basic", myCreds);
            myCredentialCache.Add("ContoscoMail", 45, "NTLM", myCreds);
                    
            client.Credentials = myCredentialCache.GetCredential("ContosoMail", 45, "NTLM");
            client.Send(message);
            Console.WriteLine("Goodbye.");
        }
		    catch(Exception e)
		    {
			      Console.WriteLine("Exception is raised. ");
			      Console.WriteLine("Message: {0} ",e.Message);
		    }