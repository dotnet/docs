' System.Net.CredentialCache.GetCredential

 'This program demonstrates the 'GetCredential' method of the CredentialCache class.It takes an URL 
'creates a 'WebRequest' object for the Url. The program stores a known set of credentials in a credential cache.
''GetCredential' will then retrieve the credentials for the requested Uri.

Imports System
Imports System.Net
Imports System.Collections
Imports Microsoft.VisualBasic
Imports System.Environment


Class CredentialCacheSnippet
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Sub Main(args() As String)
        If args.Length < 5 Then
            Console.WriteLine(ControlChars.Cr + " Usage:")
            Console.WriteLine(ControlChars.Cr + " CredentialCache_GetCredential " + ChrW(60) + "url" + ChrW(62) + " " + ChrW(60) + "User Name" + ChrW(62) + " " + ChrW(60) + "Password" + ChrW(62) + " " + ChrW(60) + "Domain Name" + ChrW(62))
            Console.WriteLine(ControlChars.Cr + " Example: CredentialCache_GetCredential http://www.microsoft.com  Catherine cath" + ChrW(36) + " microsoft")
        Else
            If args.Length = 5 Then
                GetPage(args(1), args(2), args(3), args(4))
            Else
                Console.WriteLine(ControlChars.Cr + "Invalid arguments.")
                Return
            End If
        End If 
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main
    
' <Snippet1>
    Public Shared Sub GetPage(url As String, userName As String, password As String, domainName As String)
        Try
            Dim myCredentialCache As New CredentialCache()
            ' Dummy names used as credentials    
            myCredentialCache.Add(New Uri("http://microsoft.com/"), "Basic", New NetworkCredential("user1", "passwd1", "domain1"))
            myCredentialCache.Add(New Uri("http://msdn.com/"), "Basic", New NetworkCredential("user2", "passwd2", "domain2"))
            myCredentialCache.Add(New Uri(url), "Basic", New NetworkCredential(userName, password, domainName))
            ' Creates a webrequest with the specified url. 
            Dim myWebRequest As WebRequest = WebRequest.Create(url)
            ' Call 'GetCredential' to obtain the credentials specific to our Uri.
            Dim myCredential As NetworkCredential = myCredentialCache.GetCredential(New Uri(url), "Basic")
            Display(myCredential)
            myWebRequest.Credentials = myCredential 'Associating only our credentials            
            ' Sends the request and waits for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            ' Process response here.
            Console.WriteLine(ControlChars.Cr + "Response Received.")
            myWebResponse.Close()

        Catch e As WebException
            If Not (e.Response Is Nothing) Then
                Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Failed to obtain a response. The following error occured : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
            Else
                Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Failed to obtain a response. The following error occured : {0}", e.Status)
            End If
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage

    Public Shared Sub Display(ByVal credential As NetworkCredential)
        Console.WriteLine("The credentials are: ")
        Console.WriteLine(ControlChars.Cr + "Username : {0} ,Password : {1} ,Domain : {2}", credential.UserName, credential.Password, credential.Domain)
    End Sub 'Display
' </Snippet1>
End Class 'CredentialCacheSnippet