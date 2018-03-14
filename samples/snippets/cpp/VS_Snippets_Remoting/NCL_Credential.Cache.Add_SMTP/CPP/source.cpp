//The following sample initializes a CredentialCache with multiple security credentials
//and later uses NTLM credentials with SmtpClient
 
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Mail;

void main()
{
// <Snippet1>
        SmtpClient^ client = gcnew SmtpClient("ContosoMail", 45);
        MailAddress^ from = gcnew MailAddress("sender@SenderMailServerName.com", "Sender Name");
        MailAddress^ to = gcnew MailAddress("recepient@RecepientMailServerName.com", "Recepient Name");
        MailMessage^ message = gcnew MailMessage(from, to);

        message->Body = "This is a test email message sent by an application. ";
        message->Subject = "Test Email using Credentials";

        NetworkCredential^ myCreds = gcnew NetworkCredential("username", "password", "domain");
        CredentialCache^ myCredentialCache = gcnew CredentialCache();        
        try 
        {
            myCredentialCache->Add("ContoscoMail", 35, "Basic", myCreds);
            myCredentialCache->Add("ContoscoMail", 45, "NTLM", myCreds);
                    
            client->Credentials = myCredentialCache->GetCredential("ContosoMail", 45, "NTLM");
            client->Send(message);
            Console::WriteLine("Goodbye.");
        }
		    catch(Exception^ e)
		    {
			      Console::WriteLine("Exception is raised. ");
			      Console::WriteLine("Message: {0} ",e->Message);
		    }
// </Snippet1>
           
}

