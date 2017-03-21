Dim MyMessage As MailMessage = new MailMessage()
MyMessage.Attachments.Add(New MailAttachment(fileName1))
MyMessage.Attachments.Add(New MailAttachment(fileName2, MailEncoding.UUEncode))