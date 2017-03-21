            ' Create an empty instance of the NetworkCredential class.
            Dim myCredentials As New NetworkCredential(userName, password)
            ' Create a WebRequest with the specified URL. 
            Dim myWebRequest As WebRequest = WebRequest.Create(url)
            ' GetCredential returns the same NetworkCredential instance that invoked it, 
            ' irrespective of what parameters were provided to it. 
             myWebRequest.Credentials = myCredentials.GetCredential(New Uri(url), "")
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "User Credentials:- UserName : {0} , Password : {1}", myCredentials.UserName, myCredentials.Password)
            ' Send the request and wait for a response.
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Request to Url is sent.Waiting for response...Please wait ...")
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            ' Process the response.
            Console.WriteLine(ControlChars.Cr + "Response received sucessfully")
            ' Release the resources of the response object.
            myWebResponse.Close()