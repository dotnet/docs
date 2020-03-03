' The following sample initializes a CredentialCache with multiple security credentials
' and later uses NTLM credentials with SmtpClient
 
Imports System.Net
Imports System.Net.Mail

Class SMTP_CredentailCache_Sample

    Shared Sub Main()
' <Snippet1>
        Dim client As New SmtpClient("ContosoMail", 45)
        Dim from As New MailAddress("sender@SenderMailServerName.com", "Sender Name")
        Dim sendTo As New MailAddress("recepient@RecepientMailServerName.com", "Recepient Name")
        Dim message As New MailMessage(from, sendTo)

        message.Body = "This is a test email message sent by an application. "
        message.Subject = "Test Email using Credentials"

        Dim myCreds As New NetworkCredential("username", "password", "domain")
        DIm myCredentialCache As New CredentialCache()

        Try 
            myCredentialCache.Add("ContoscoMail", 35, "Basic", myCreds)
            myCredentialCache.Add("ContoscoMail", 45, "NTLM", myCreds)

            client.Credentials = myCredentialCache.GetCredential("ContosoMail", 45, "NTLM")
            client.Send(message)
            Console.WriteLine("Goodbye.")
		Catch e As Exception
			Console.WriteLine("Exception is raised. ")
			Console.WriteLine($"Message: {e.Message} ")
        End Try
' </Snippet1>
           
    End Sub
End Class
