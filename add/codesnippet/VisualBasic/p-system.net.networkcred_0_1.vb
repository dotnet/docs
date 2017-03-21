            ' Create an empty instance of the NetworkCredential class.
            Dim myCredentials As New NetworkCredential("", "", "")
            myCredentials.Domain = domain
            myCredentials.UserName = username
            myCredentials.Password = passwd
            
            ' Create a WebRequest with the specified URL. 
            Dim myWebRequest As WebRequest = WebRequest.Create(url)
            myWebRequest.Credentials = myCredentials
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "User Credentials:- Domain : {0} , UserName : {1} , Password : {2}", myCredentials.Domain, myCredentials.UserName, myCredentials.Password)
            
            ' Send the request and wait for a response.
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Request to Url is sent.Waiting for response...Please wait ...")
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            ' Process the response.
            Console.WriteLine(ControlChars.Cr + "Response received sucessfully")
            ' Release the resources of the response object.
            myWebResponse.Close()