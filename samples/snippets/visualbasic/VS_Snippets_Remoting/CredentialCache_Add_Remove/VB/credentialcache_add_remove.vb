' System.Net.CredentialCache.Add;System.Net.CredentialCache.CredentialCache();
' System.Net.CredentialCache.Remove;System.Net.CredentialCache.

 'This program demonstrates the  'Remove' method, 'Add' method and 'CredentialCache()'
'constructor of the CredentialCache class.It takes an URL  creates a 'WebRequest' object for the Url. 
'The program stores a known set of credentials in a credential cache and removes a credential when it 
'is no longer needed.

Imports System
Imports System.Net
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
            Console.WriteLine(ControlChars.Cr + " CredentialCache_Add_Remove " + ChrW(60) + "Url" + ChrW(62) + " " + ChrW(60) + "User Name" + ChrW(62) + " " + ChrW(60) + "Password" + ChrW(62) + " " + ChrW(60) + "Domain Name" + ChrW(62))
            Console.WriteLine(ControlChars.Cr + " Example: CredentialCache_Add_Remove http://www.microsoft.com  Catherine cath" + ChrW(36) + " microsoft")
        Else
            If args.Length = 5 Then
                GetPage(args(1), args(2), args(3), args(4))
            Else
                Console.WriteLine(ControlChars.Cr + "Invalid arguments.")
                Return
            End If
        End If 
        Console.WriteLine(" Press any key to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main
    
    Public Shared Sub GetPage(url As String, userName As String, password As String, domainName As String)

        Try
            ' <Snippet1>
            ' <Snippet2>
            Dim myCredentialCache As New CredentialCache
            'Dummy names used as credentials here. Expected to be replaced by credentials applicable locally.
            myCredentialCache.Add(New Uri("http://www.microsoft.com/"), "Basic", New NetworkCredential("user1", "passwd1", "domain1"))
            myCredentialCache.Add(New Uri("http://www.msdn.com/"), "Basic", New NetworkCredential("user2", "passwd2", "domain2"))
            myCredentialCache.Add(New Uri(url), "Basic", New NetworkCredential(userName, password, domainName))
            Console.WriteLine(ControlChars.Cr + "Added your credentials to the program's CredentialCache")
            ' </Snippet2>
            ' <Snippet3>
            ' Create a webrequest with the specified url .
            Dim myWebRequest As WebRequest = WebRequest.Create(url)
            myWebRequest.Credentials = myCredentialCache
            Console.WriteLine(ControlChars.Cr + "Linked CredentialCache to your request.")
            ' Send the request and wait for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            ' </Snippet1>

            'Process the response here

            Console.Write("Response received successfully.")
            'Call 'Remove' method to dispose credentials for current Uri as they would not be; 
            'required in any of the future requests.
            myCredentialCache.Remove(myWebRequest.RequestUri, "Basic")
            Console.WriteLine(ControlChars.Cr + "Your credentials have now been removed from the program's CredentialCache")
            myWebResponse.Close()
            ' </Snippet3>
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
End Class 'CredentialCacheSnippet