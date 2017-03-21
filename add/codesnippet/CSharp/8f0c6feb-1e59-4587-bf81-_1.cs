         string from = "from@microsoft.com";
         string to = "to@microsoft.com";
         string subject = "UtilMailMessage001";
         string body = "UtilMailMessage001 - success";
         SmtpMail.SmtpServer = "MyMailServer";
         SmtpMail.Send(from, to, subject, body);