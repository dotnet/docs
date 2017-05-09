using System;
using System.Web.Mail;

namespace SMTPMailSendExample
{
    class Class1
    {
        static void Main()
        {
         Send1();
         Send2();
      }

      public static void Send1()
      {
         //<Snippet1>
         MailMessage myMail = new MailMessage();
         myMail.From = "from@microsoft.com";
         myMail.To = "to@microsoft.com";
         myMail.Subject = "UtilMailMessage001";
         myMail.Priority = MailPriority.Low;
         myMail.BodyFormat = MailFormat.Html;
         myMail.Body = "<html><body>UtilMailMessage001 - success</body></html>";
     MailAttachment myAttachment = new MailAttachment("c:\attach\attach1.txt", MailEncoding.Base64);
     myMail.Attachments.Add(myAttachment);
         SmtpMail.SmtpServer = "MyMailServer";
         SmtpMail.Send(myMail);
         //</Snippet1>
      }

      public static void Send2()
      {
         //<Snippet2>
         string from = "from@microsoft.com";
         string to = "to@microsoft.com";
         string subject = "UtilMailMessage001";
         string body = "UtilMailMessage001 - success";
         SmtpMail.SmtpServer = "MyMailServer";
         SmtpMail.Send(from, to, subject, body);
         //</Snippet2>
      }
    }
}
