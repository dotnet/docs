' <Snippet1>
Imports System
Imports System.Web.Mail
 
Namespace SendMail
   Public Class usage
      Public Sub DisplayUsage()
         ' Display usage instructions in case of error.
         Console.WriteLine("Usage SendMail.exe <to> <from> <subject> <body>")
         Console.WriteLine("<to> the addresses of the email recipients")
         Console.WriteLine("<from> your email address")
         Console.WriteLine("<subject> subject of your email")
         Console.WriteLine("<body> the text of the email")
         Console.WriteLine("Example:")
         Console.WriteLine("SendMail.exe SomeOne@contoso.com;SomeOther@contoso.com Me@contoso.com Hi hello")
     End Sub
   End Class

   Public Class Start
      '  The main entry point for the application.
      Public Shared Sub Main(ByVal args As String())
         Try
            Try
               Dim Message As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage()
               Message.To = args(0)
               Message.From = args(1)
               Message.Subject = args(2)
               Message.Body = args(3)
               Try
                  SmtpMail.SmtpServer = "your mail server name goes here"
                  SmtpMail.Send(Message)
               Catch ehttp As System.Web.HttpException
                  Console.WriteLine("0", ehttp.Message)
                  Console.WriteLine("Here is the full error message")
                  Console.Write("0", ehttp.ToString())
               End Try
            Catch e As IndexOutOfRangeException
               ' Display usage instructions if error in arguments.
               Dim use As usage = New usage()
               use.DisplayUsage()
            End Try
         Catch e As System.Exception
            ' Display text of unknown error.
            Console.WriteLine("Unknown Exception occurred 0", e.Message)
            Console.WriteLine("Here is the Full Error Message")
            Console.WriteLine("0", e.ToString())
         End Try
      End Sub
   End Class
End Namespace
' </Snippet1>
			
		
	
