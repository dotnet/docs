Imports System
Imports System.Web.Mail

Namespace MyNameSpace
Module Module1
   Public Sub Main()
      '<Snippet1>
      Dim  MyMessage As MailMessage = New MailMessage()
      MyMessage.From = "john@contoso.com"
      '</Snippet1>
   End Sub
End Module
End Namespace