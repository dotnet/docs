            ' Call the constructor  to create an instance of NetworkCredential with the
            ' specified user name and password.
            Dim myCredentials As New NetworkCredential(username, passwd)
            ' Create a WebRequest with the specified URL. 
            Dim myWebRequest As WebRequest = WebRequest.Create(url)
            myCredentials.Domain = domain
            myWebRequest.Credentials = myCredentials
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Credentials Domain : {0} , UserName : {1} , Password : {2}", myCredentials.Domain, myCredentials.UserName, myCredentials.Password)
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Request to Url is sent.Waiting for response...")
            ' Send the request and wait for a response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            ' Process the response.
            Console.WriteLine(ControlChars.Cr + "Response received successfully.")
            ' Release the resources of the response object.
            myWebResponse.Close()