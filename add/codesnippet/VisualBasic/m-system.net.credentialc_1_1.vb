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