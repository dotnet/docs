#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mail;

#endregion

namespace AttachmentSample
{
    class AttachmentSampleCS
    {
        static void Main(string[] args)
        {
            string fileName1 = args[0];
            string fileName2 = args[1];
// <Snippet1>
MailMessage MyMessage = new MailMessage();
MyMessage.Attachments.Add(new MailAttachment(fileName1));
MyMessage.Attachments.Add(new MailAttachment(fileName2, MailEncoding.UUEncode));
// </Snippet1>
        }
    }
}
