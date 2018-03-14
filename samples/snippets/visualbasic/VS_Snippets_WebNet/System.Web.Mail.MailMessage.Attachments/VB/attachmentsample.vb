Imports System
Imports System.Web.Mail
Imports System.Text


Namespace AttachmentSample
    Module AttachmentSampleVB
        Public Sub Main(args As string())
            Dim fileName1 As String = args(0)
            Dim fileName2 As String = args(1)
            '<Snippet1>
Dim MyMessage As MailMessage = new MailMessage()
MyMessage.Attachments.Add(New MailAttachment(fileName1))
MyMessage.Attachments.Add(New MailAttachment(fileName2, MailEncoding.UUEncode))
            '</Snippet1>
        End Sub
    End Module
End Namespace