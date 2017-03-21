        Try
            Dim myCredentialCache As New CredentialCache
            ' Dummy Credentials used here.             
            myCredentialCache.Add(New Uri("http://microsoft.com/"), "Basic", New NetworkCredential("user1", "passwd1", "domain1"))
            myCredentialCache.Add(New Uri("http://msdn.com/"), "Basic", New NetworkCredential("user2", "passwd2", "domain2"))

            myCredentialCache.Add(New Uri(url), "Basic", New NetworkCredential(userName, password, domainName))
            Dim myWebRequest As WebRequest = WebRequest.Create(url) 'Creates a webrequest with the specified url 
            myWebRequest.Credentials = myCredentialCache
            Dim listCredentials As IEnumerator = myCredentialCache.GetEnumerator()
            Console.WriteLine("Displaying credentials stored in CredentialCache: ")
            While listCredentials.MoveNext()
                Display(CType(listCredentials.Current, NetworkCredential))
            End While
            Console.WriteLine(ControlChars.Cr + "Now Displaying using 'foreach': ")
            ' Can use foreach with CredentialCache(Since GetEnumerator method of IEnumerable has been implemented by 'CredentialCache' class.
            Dim credential As NetworkCredential
            For Each credential In myCredentialCache
                Display(credential)
            Next credential
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse() 'Sends the request and waits for response.
            ' Process the response here
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
    
    Public Shared Sub Display(credential As NetworkCredential)
        Console.WriteLine(ControlChars.Cr + "Username : {0} ,Password : {1} ,Domain : {2}", credential.UserName, credential.Password, credential.Domain)
    End Sub 'Display