MailMessage MyMessage = new MailMessage();
MyMessage.Attachments.Add(new MailAttachment(fileName1));
MyMessage.Attachments.Add(new MailAttachment(fileName2, MailEncoding.UUEncode));