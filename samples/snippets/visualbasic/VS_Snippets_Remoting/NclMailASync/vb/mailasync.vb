'NclMailASync

'<snippet1>

Imports System
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Threading
Imports System.ComponentModel
Namespace Examples.SmptExamples.Async
    Public Class SimpleAsynchronousExample
        Private Shared mailSent As Boolean = False
        Private Shared Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
            ' Get the unique identifier for this asynchronous operation.
            Dim token As String = CStr(e.UserState)

            If e.Cancelled Then
                Console.WriteLine("[{0}] Send canceled.", token)
            End If
            If e.Error IsNot Nothing Then
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString())
            Else
                Console.WriteLine("Message sent.")
            End If
            mailSent = True
        End Sub
        Public Shared Sub Main(ByVal args() As String)
            ' Command line argument must the the SMTP host.
            Dim client As New SmtpClient(args(0))
            ' Specify the e-mail sender.
            '<snippet2>
            ' Create a mailing address that includes a UTF8 character
            ' in the display name.
            Dim [from] As New MailAddress("jane@contoso.com", "Jane " & ChrW(&HD8) & " Clayton", System.Text.Encoding.UTF8)
            '</snippet2>
            ' Set destinations for the e-mail message.
            Dim [to] As New MailAddress("ben@contoso.com")
            ' Specify the message content.
            '<snippet3>
            Dim message As New MailMessage([from], [to])
            message.Body = "This is a test e-mail message sent by an application. "
            ' Include some non-ASCII characters in body and subject.
            Dim someArrows As New String(New Char() {ChrW(&H2190), ChrW(&H2191), ChrW(&H2192), ChrW(&H2193)})
            message.Body += Environment.NewLine & someArrows
            message.BodyEncoding = System.Text.Encoding.UTF8
            message.Subject = "test message 1" & someArrows
            message.SubjectEncoding = System.Text.Encoding.UTF8
            '</snippet3>
            ' Set the method that is called back when the send operation ends.
            AddHandler client.SendCompleted, AddressOf SendCompletedCallback
            ' The userState can be any object that allows your callback 
            ' method to identify this send operation.
            ' For this example, the userToken is a string constant.
            Dim userState As String = "test message1"
            client.SendAsync(message, userState)
            Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.")
            Dim answer As String = Console.ReadLine()
            ' If the user canceled the send, and mail hasn't been sent yet,
            ' then cancel the pending operation.
            If answer.StartsWith("c") AndAlso mailSent = False Then
                client.SendAsyncCancel()
            End If
            ' Clean up.
            message.Dispose()
            Console.WriteLine("Goodbye.")
        End Sub
    End Class
End Namespace
'</snippet1>