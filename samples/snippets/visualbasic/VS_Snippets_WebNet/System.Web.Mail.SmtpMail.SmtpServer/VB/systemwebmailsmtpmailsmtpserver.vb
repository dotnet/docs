Imports System
Imports System.Web.Mail

Namespace MyNameSpace
Module Module1
   Public Sub Main()
      '<Snippet1>
      ' This example assigns the name of the mail relay server on the 
      ' local network to the SmtpServer property.
      SmtpMail.SmtpServer = "RelayServer.Contoso.com"
      '</Snippet1>
   End Sub
End Module
End Namespace