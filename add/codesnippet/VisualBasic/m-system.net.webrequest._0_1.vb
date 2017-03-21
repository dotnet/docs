            ' Create a new 'Uri' object with the specified string.
            Dim myUri As New Uri("http://www.contoso.com")
            ' Create a new request to the above mentioned URL.	
            Dim myWebRequest As WebRequest = WebRequest.Create(myUri)
            '  Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()