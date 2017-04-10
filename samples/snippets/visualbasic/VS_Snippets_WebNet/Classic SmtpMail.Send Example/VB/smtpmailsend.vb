Imports System
Imports System.Web.Mail


Namespace SMTPMailSendExample
   Class Class1

      Shared Sub Main()
         Send1()
         Send2()
      End Sub 'Main


      Public Shared Sub Send1()
         '<Snippet1>
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
         '</Snippet1>
      End Sub 'Send1

      Public Shared Sub Send2()
         '<Snippet2>
         Dim from As String = "from@microsoft.com"
         Dim mailto As String = "to@microsoft.com"
         Dim subject As String = "UtilMailMessage001"
         Dim body As String = "UtilMailMessage001 - success"
         SmtpMail.SmtpServer = "MyMailServer"
         SmtpMail.Send(from, mailto, subject, body)
         '</Snippet2>
      End Sub 'Send2
   End Class 'Class1
End Namespace 'SMTPMailSendExample