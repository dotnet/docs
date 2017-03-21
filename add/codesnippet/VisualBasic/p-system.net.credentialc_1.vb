            ' Assuming "Windows Authentication" has been set as; 
            ' Directory Security settings for default web site in IIS.
            Dim url As String = "http://localhost"
            ' Create a 'HttpWebRequest' object with the specified url. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Assign the credentials of the logged in user or the user being impersonated.
            myHttpWebRequest.Credentials = CredentialCache.DefaultCredentials
            ' Send the 'HttpWebRequest' and wait for response.            
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine("Authentication successful")
            Console.WriteLine("Response received successfully")