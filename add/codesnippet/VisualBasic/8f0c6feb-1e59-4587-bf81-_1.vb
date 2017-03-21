         Dim from As String = "from@microsoft.com"
         Dim mailto As String = "to@microsoft.com"
         Dim subject As String = "UtilMailMessage001"
         Dim body As String = "UtilMailMessage001 - success"
         SmtpMail.SmtpServer = "MyMailServer"
         SmtpMail.Send(from, mailto, subject, body)