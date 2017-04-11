Imports System
Imports System.Web.Mail
Imports System.Text

Namespace MyNameSpace
Module Module1
   Public Sub Main()
      '<Snippet1>
      Dim MyMessage As MailMessage = New MailMessage()
      MyMessage.BodyEncoding = Encoding.ASCII
      '</Snippet1>
   End Sub
End Module
End Namespace