         Dim myMail As New MailMessage()
         myMail.From = "from@microsoft.com"
         myMail.To = "to@microsoft.com"
         myMail.Subject = "UtilMailMessage001"
         myMail.Priority = MailPriority.Low
         myMail.BodyFormat = MailFormat.Html
         myMail.Body = "<html><body>UtilMailMessage001 - success</body></html>"
         Dim myAttachment As New MailAttachment("c:\attach\attach1.txt", MailEncoding.Base64)
         myMail.Attachments.Add(myAttachment)
         SmtpMail.SmtpServer = "MyMailServer"
         SmtpMail.Send(myMail)