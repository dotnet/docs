            ' Create a webrequest with the specified url .
            Dim myWebRequest As WebRequest = WebRequest.Create(url)
            myWebRequest.Credentials = myCredentialCache
            Console.WriteLine(ControlChars.Cr + "Linked CredentialCache to your request.")
            ' Send the request and wait for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()

            'Process the response here

            Console.Write("Response received successfully.")
            'Call 'Remove' method to dispose credentials for current Uri as they would not be; 
            'required in any of the future requests.
            myCredentialCache.Remove(myWebRequest.RequestUri, "Basic")
            Console.WriteLine(ControlChars.Cr + "Your credentials have now been removed from the program's CredentialCache")
            myWebResponse.Close()